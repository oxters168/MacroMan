using MacroMan.MacroActions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroMan
{
    public partial class MacroForm : Form
    {
        private CancellationTokenSource tickProcessToken, macroSequenceToken;
        private double startTime = 0;
        private double currentTime = 0;
        private const int milliDelay = 10;
        private MacroType faux;

        private bool prevShortcut;
        private bool isRunning;

        private string currentFileName = null;

        public static VirtualKey[] runSequenceShortcut = new VirtualKey[] { VirtualKey.SPACE };

        public MacroForm()
        {
            InitializeComponent();

            tickProcessToken = new CancellationTokenSource();
            FrameRunner(tickProcessToken.Token);

            startTime = DateTime.Now.Ticks / 10000000d;

            macrosComboBox.DataSource = Enum.GetValues(typeof(Macro));
            SetupStaticComboboxes();
            RefreshFauxDisplay();
            RefreshStartConditionControls();

            foreach (ToolStripMenuItem menuItem in menuStrip1.Items)
                ((ToolStripDropDownMenu)menuItem.DropDown).ShowImageMargin = false;
        }
        private async void FrameRunner(CancellationToken cancellationToken)
        {
            while (true)
            {
                OnUpdate();
                if (cancellationToken.IsCancellationRequested)
                    break;

                await Task.Delay(milliDelay);
            }
        }
        private void MacroForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tickProcessToken.Cancel();
        }

        private void OnUpdate()
        {
            currentTime = DateTime.Now.Ticks / 10000000d;

            PlayOnShortcut();
        }

        private void PlayOnShortcut()
        {
            bool shortcutPressed = true;
            for (int i = 0; i < runSequenceShortcut.Length; i++)
                shortcutPressed &= KeyboardOperations.IsKeyPressed(runSequenceShortcut[i]);

            if (shortcutPressed && !prevShortcut)
            {
                ToggleSequence();
                prevShortcut = true;
            }
            else if (!shortcutPressed)
                prevShortcut = false;
        }

        private static string ToComboString(List<VirtualKey> keys)
        {
            string currentCombo = "";
            for (int i = 0; i < keys.Count; i++)
            {
                currentCombo += keys[i];
                if (i < keys.Count - 1)
                    currentCombo += " + ";
            }
            return currentCombo;
        }

        private Macro GetCurrentMacroType()
        {
            return (Macro)macrosComboBox.SelectedItem;
        }
        private int GetCurrentActionId()
        {
            return (int)macroActionComboBox.SelectedItem;
        }
        private int GetCurrentPropertyId()
        {
            return (int)macroPropertiesListBox.SelectedItem;
        }
        private bool IsCurrentPropertyPointer()
        {
            var fauxType = MacroType.GetMacroType(faux);
            int propertyId = GetCurrentPropertyId();
            MacroProperty prop = faux.GetProperty(propertyId);

            string propStart = GetCurrentPropertyPointerStart();
            return (fauxType == Macro.Boolean || fauxType == Macro.Integer || fauxType == Macro.Clipboard) && prop.name.Contains(propStart + "_source_") && (DataSource)faux.GetProperty(propStart + "_source").value == DataSource.Macro;
        }
        private bool IsCurrentPropertyMacroId()
        {
            int propertyId = GetCurrentPropertyId();
            MacroProperty prop = faux.GetProperty(propertyId);

            return prop.name.Contains("macro_id");
        }
        private string GetCurrentPropertyPointerStart()
        {
            int propertyId = GetCurrentPropertyId();
            MacroProperty prop = faux.GetProperty(propertyId);
            return prop.name.Split('_')[0];

            //return prop.name.Contains("first") ? "first" : prop.name.Contains("second") ? "second" : "result";
        }

        private void MacroForm_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        /*private void comboBox1_DropDown(object sender, EventArgs e)
        {
            //Applications
            comboBox1.DataSource = Process.GetProcesses().Distinct(new ProcessMainHandlerComparer()).ToList();
            comboBox1.DisplayMember = "ProcessName";
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            //Processes
            comboBox2.DataSource = Process.GetProcesses();
            comboBox2.DisplayMember = "Id";
        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            //Windows
            comboBox3.DataSource = Process.GetProcesses().Where(process => !string.IsNullOrEmpty(process.MainWindowTitle)).ToList();
            comboBox3.DisplayMember = "MainWindowTitle";
        }
        public class ProcessMainHandlerComparer : IEqualityComparer<Process>
        {
            public bool Equals(Process x, Process y)
            {
                return x.MainWindowHandle == y.MainWindowHandle;
            }

            public int GetHashCode(Process obj)
            {
                return obj.MainWindowHandle.GetHashCode();
            }
        }*/

        private void SetupStaticComboboxes()
        {
            startConditionFirstSourceComboBox.DataSource = Enum.GetValues(typeof(DataSource));
            startConditionSecondSourceComboBox.DataSource = Enum.GetValues(typeof(DataSource));
            startConditionOperationComboBox.DataSource = Enum.GetValues(typeof(BooleanOperations));
        }
        private void RefreshStartConditionControls()
        {
            bool hasStartCondition = faux != null && faux.startingCondition != null;
            hasStartConditionCheckBox.Checked = hasStartCondition;
            startConditionFirstValueComboBox.Enabled = hasStartCondition;
            startConditionFirstSourceComboBox.Enabled = hasStartCondition;
            startConditionFirstValueTextBox.Enabled = hasStartCondition;
            startConditionFirstMacroIdComboBox.Enabled = hasStartCondition;
            startConditionOperationComboBox.Enabled = hasStartCondition;
            startConditionSecondValueComboBox.Enabled = hasStartCondition;
            startConditionSecondSourceComboBox.Enabled = hasStartCondition;
            startConditionSecondValueTextBox.Enabled = hasStartCondition;
            startConditionSecondMacroIdComboBox.Enabled = hasStartCondition;

            if (hasStartCondition)
            {
                startConditionOperationComboBox.SelectedItem = (BooleanOperations)faux.startingCondition.GetProperty("operation").value;

                var firstSource = (DataSource)faux.startingCondition.GetProperty("first_source").value;
                startConditionFirstSourceComboBox.SelectedItem = firstSource;
                bool firstSourceIsMacro = firstSource == DataSource.Macro;
                startConditionFirstMacroIdComboBox.Enabled = firstSourceIsMacro;

                startConditionFirstValueTextBox.Enabled = !firstSourceIsMacro;
                startConditionFirstValueTextBox.Visible = !firstSourceIsMacro;

                startConditionFirstValueComboBox.Enabled = firstSourceIsMacro;
                startConditionFirstValueComboBox.Visible = firstSourceIsMacro;
                if (firstSource == DataSource.Macro)
                {
                    var allMacros = MacroType.GetCachedMacros();

                    var macro = MacroType.GetMacro((int)faux.startingCondition.GetProperty("first_source_macro_id").value);

                    startConditionFirstMacroIdComboBox.DataSource = allMacros;
                    startConditionFirstMacroIdComboBox.SelectedItem = macro;

                    if (macro != null)
                    {
                        var propertyOptions = macro.GetProperties();
                        var propId = faux.startingCondition.GetProperty("first_source_id").value;
                        int selectedIndex = -1;
                        for (int i = 0; i < propertyOptions.Length; i++)
                        {
                            if ((int)propId == (int)propertyOptions.GetValue(i))
                            {
                                selectedIndex = i;
                                break;
                            }
                        }

                        startConditionFirstValueComboBox.DataSource = propertyOptions;
                        startConditionFirstValueComboBox.SelectedIndex = selectedIndex;
                    }
                }

                var secondSource = (DataSource)faux.startingCondition.GetProperty("second_source").value;
                startConditionSecondSourceComboBox.SelectedItem = secondSource;
                bool secondSourceIsMacro = secondSource == DataSource.Macro;
                startConditionSecondMacroIdComboBox.Enabled = secondSourceIsMacro;

                startConditionSecondValueTextBox.Enabled = !secondSourceIsMacro;
                startConditionSecondValueTextBox.Visible = !secondSourceIsMacro;

                startConditionSecondValueComboBox.Enabled = secondSourceIsMacro;
                startConditionSecondValueComboBox.Visible = secondSourceIsMacro;
                if (secondSource == DataSource.Macro)
                {
                    var allMacros = MacroType.GetCachedMacros(); //We create a new instance of allMacros since not doing so causes the comboboxes to change together when one changes

                    var macro = MacroType.GetMacro((int)faux.startingCondition.GetProperty("second_source_macro_id").value);
                    startConditionSecondMacroIdComboBox.DataSource = allMacros;
                    startConditionSecondMacroIdComboBox.SelectedItem = macro;

                    if (macro != null)
                    {
                        var propertyOptions = macro.GetProperties();
                        var propId = faux.startingCondition.GetProperty("second_source_id").value;
                        int selectedIndex = -1;
                        for (int i = 0; i < propertyOptions.Length; i++)
                        {
                            if ((int)propId == (int)propertyOptions.GetValue(i))
                            {
                                selectedIndex = i;
                                break;
                            }
                        }

                        startConditionSecondValueComboBox.DataSource = propertyOptions;
                        startConditionSecondValueComboBox.SelectedIndex = selectedIndex;
                    }
                }
            }

        }
        private void hasStartConditionCheckBox_Click(object sender, EventArgs e)
        {
            if (hasStartConditionCheckBox.Checked)
                faux.startingCondition = (BooleanMacro)MacroType.GenerateFauxMacro(Macro.Boolean);
            else
                faux.startingCondition = null;

            RefreshFauxDisplay();
            RefreshStartConditionControls();
        }
        private void startConditionFirstValueComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            faux.startingCondition.SetPropertyValue("first_source_id", (int)startConditionFirstValueComboBox.SelectedItem);
        }
        private void startConditionSecondValueComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            faux.startingCondition.SetPropertyValue("second_source_id", (int)startConditionSecondValueComboBox.SelectedItem);
        }
        private void startConditionOperationComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            faux.startingCondition.SetPropertyValue("operation", (int)startConditionOperationComboBox.SelectedItem);
        }
        private void startConditionFirstSourceComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (faux != null && faux.startingCondition != null)
            {
                faux.startingCondition.SetPropertyValue("first_source", (int)startConditionFirstSourceComboBox.SelectedItem);
                RefreshStartConditionControls();
            }
        }
        private void startConditionFirstMacroIdComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            faux.startingCondition.SetPropertyValue("first_source_macro_id", ((MacroType)startConditionFirstMacroIdComboBox.SelectedItem).GetId());
            RefreshStartConditionControls();
        }
        private void startConditionSecondSourceComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (faux != null && faux.startingCondition != null)
            {
                faux.startingCondition.SetPropertyValue("second_source", (int)startConditionSecondSourceComboBox.SelectedItem);
                RefreshStartConditionControls();
            }
        }
        private void startConditionSecondMacroIdComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            faux.startingCondition.SetPropertyValue("second_source_macro_id", ((MacroType)startConditionSecondMacroIdComboBox.SelectedItem).GetId());
            RefreshStartConditionControls();
        }

        private void startConditionFirstValueTextBox_TextChanged(object sender, EventArgs e)
        {
            object value = startConditionFirstValueTextBox.Text;
            try
            {
                value = Convert.ToInt32(startConditionFirstValueTextBox.Text);
            }
            catch (Exception) { }

            var source = (DataSource)faux.startingCondition.GetProperty("first_source").value;
            if (source == DataSource.Self)
                faux.startingCondition.SetPropertyValue("first_value", value);
            else
                faux.startingCondition.SetPropertyValue("first_source_id", value);
        }
        private void startConditionSecondValueTextBox_TextChanged(object sender, EventArgs e)
        {
            object value = startConditionSecondValueTextBox.Text;
            try
            {
                value = Convert.ToInt32(startConditionSecondValueTextBox.Text);
            }
            catch (Exception) { }

            var source = (DataSource)faux.startingCondition.GetProperty("second_source").value;
            if (source == DataSource.Self)
                faux.startingCondition.SetPropertyValue("second_value", value);
            else
                faux.startingCondition.SetPropertyValue("second_source_id", value);
        }

        private void RefreshFauxDisplay()
        {
            if (faux != null)
            {
                Macro fauxType = MacroType.GetMacroType(faux);

                macroTypeLabel.Text = fauxType.ToString();
                macroNameTextBox.Text = faux.name;
                macroIdLabel.Text = faux.GetId() >= 0 ? "id: " + faux.GetId() : "id: -";

                int propertyListIndex = macroPropertiesListBox.SelectedIndex;

                macroPropertiesListBox.DataSource = MacroType.GetShownProperties(fauxType);
                macroActionComboBox.DataSource = MacroType.GetActions(fauxType);

                if (propertyListIndex >= 0 && propertyListIndex < macroPropertiesListBox.Items.Count)
                    macroPropertiesListBox.SelectedIndex = propertyListIndex;

                macroActionComboBox.SelectedIndex = faux.GetAction();
            }

            //addToListButton.Enabled = faux != null;
            macroDataSplitContainer.Visible = faux != null;
            macroDataSplitContainer.Enabled = faux != null;
            macroTypeLabel.Visible = faux != null;
            macroTypeLabel.Enabled = faux != null;

            RefreshStartConditionControls();
            RefreshGotoMacroControls();
        }
        private void RefreshPropertyOptions()
        {
            var fauxType = MacroType.GetMacroType(faux);
            int propertyId = GetCurrentPropertyId();
            Array propertyOptions = MacroType.GetPropertyOptions(fauxType, propertyId);
            bool hasOptions = propertyOptions != null;
            propertyOptionsComboBox.Enabled = hasOptions;
            propertyOptionsComboBox.Visible = hasOptions;
            propertyValueTextBox.Enabled = !hasOptions;
            propertyValueTextBox.Visible = !hasOptions;
            propertyOptionsComboBox.DataSource = propertyOptions;

            MacroProperty prop = faux.GetProperty(propertyId);
            if (hasOptions)
            {
                int selectedIndex = -1;
                for (int i = 0; i < propertyOptions.Length; i++)
                {
                    if ((int)prop.value == (int)propertyOptions.GetValue(i))
                    {
                        selectedIndex = i;
                        break;
                    }
                }
                propertyOptionsComboBox.SelectedIndex = selectedIndex;
            }
            else if (IsCurrentPropertyPointer())
            {
                int selectedIndex = -1;
                if (IsCurrentPropertyMacroId())
                {
                    propertyOptions = MacroType.GetCachedMacros();
                    selectedIndex = Array.IndexOf(propertyOptions, MacroType.GetMacro((int)prop.value));
                }
                else
                {
                    string propStart = GetCurrentPropertyPointerStart();
                    int macroId = (int)faux.GetProperty(propStart + "_source_macro_id").value;
                    propertyOptions = MacroType.GetMacro(macroId)?.GetProperties();
                    if (propertyOptions != null)
                        selectedIndex = Array.IndexOf(propertyOptions.Cast<int>().ToArray(), prop.value);
                }

                propertyOptionsComboBox.Enabled = true;
                propertyOptionsComboBox.Visible = true;
                propertyValueTextBox.Enabled = false;
                propertyValueTextBox.Visible = false;
                propertyOptionsComboBox.DataSource = propertyOptions;
                propertyOptionsComboBox.SelectedIndex = selectedIndex;
            }
            else
                propertyValueTextBox.Text = prop.value.ToString();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            macrosComboBox.DroppedDown = true;
        }
        private void macrosComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            faux = MacroType.GenerateFauxMacro(GetCurrentMacroType());
            addToListButton.Enabled = true;
            macroNameTextBox.Enabled = true;
            RefreshFauxDisplay();
        }

        private void AddMacro(MacroType macro)
        {
            MacroType newMacro = MacroType.GenerateMacro(MacroType.GetMacroType(macro), macro);
            macrosListBox.Items.Add(newMacro);
            addToListButton.Enabled = false;
            RefreshFauxDisplay();
        }
        private void addToListButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(faux.name) && MacroType.GetMacro(faux.name) == null)
            {
                MacroType newMacro = faux;
                faux = null;
                AddMacro(newMacro);
            }
            else
                MessageBox.Show("Name cannot be empty or repeated", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void macroPropertiesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPropertyOptions();
        }
        private void macrosListBox_DoubleClick(object sender, EventArgs e)
        {
            SelectMacroFromList();
        }

        private void SelectMacroFromList()
        {
            if (macrosListBox.SelectedIndex >= 0)
            {
                faux = (MacroType)macrosListBox.SelectedItem;
                addToListButton.Enabled = false;
                macroNameTextBox.Enabled = false;
                //RefreshPropertyOptions();
                RefreshFauxDisplay();
            }
        }

        private void macroNameTextBox_TextChanged(object sender, EventArgs e)
        {
            macroNameLabel.Visible = string.IsNullOrEmpty(macroNameTextBox.Text);
            faux.name = macroNameTextBox.Text;
        }
        private void propertyOptionsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int setPropertyValue;

            int propertyId = GetCurrentPropertyId();
            if (IsCurrentPropertyPointer() && IsCurrentPropertyMacroId())
                setPropertyValue = ((MacroType)propertyOptionsComboBox.SelectedItem).GetId();
            else
                setPropertyValue = (int)propertyOptionsComboBox.SelectedItem;

            faux.SetPropertyValue(propertyId, setPropertyValue);
        }
        private void propertyValueTextBox_TextChanged(object sender, EventArgs e)
        {
            int propertyId = GetCurrentPropertyId();
            PropertyType propertyType = faux.GetProperty(propertyId).type;
            string originalText = propertyValueTextBox.Text;
            try
            {
                if (propertyType == PropertyType.boolean)
                    faux.SetPropertyValue(propertyId, Convert.ToBoolean(originalText) ? 1 : 0);
                else if (propertyType == PropertyType.floating_point)
                    faux.SetPropertyValue(propertyId, Convert.ToSingle(originalText));
                else if (propertyType == PropertyType.integer)
                    faux.SetPropertyValue(propertyId, Convert.ToInt32(originalText));
                else if (propertyType == PropertyType.stringed_value)
                    faux.SetPropertyValue(propertyId, originalText);
                else
                    faux.SetPropertyValue(propertyId, MacroType.StringToDynamicType(originalText));
            }
            catch (Exception) { }
        }
        private void macroActionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            faux.SetAction(GetCurrentActionId());
        }

        private void ShiftMacroSelection(int amount)
        {
            if (macrosListBox.SelectedIndex >= 0)
            {
                int currentIndex = macrosListBox.SelectedIndex;
                currentIndex += amount;
                if (currentIndex <= 0)
                    currentIndex = 0;
                else if (currentIndex > macrosListBox.Items.Count - 1)
                    currentIndex = macrosListBox.Items.Count - 1;
                var toBeMoved = macrosListBox.SelectedItem;
                macrosListBox.Items.Remove(toBeMoved);
                macrosListBox.Items.Insert(currentIndex, toBeMoved);
                macrosListBox.SelectedIndex = currentIndex;
            }
        }
        private void RemoveMacroSelection()
        {
            if (macrosListBox.SelectedIndex >= 0)
            {
                var macro = macrosListBox.SelectedItem;
                macrosListBox.Items.Remove(macro);
                MacroType.RemoveFromCache((MacroType)macro);

                if (faux == macro)
                    faux = null;

                RefreshFauxDisplay();
            }
        }

        private void shiftMacroUpButton_Click(object sender, EventArgs e)
        {
            ShiftMacroSelection(-1);
        }
        private void shiftMacroDownButton_Click(object sender, EventArgs e)
        {
            ShiftMacroSelection(1);
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            RemoveMacroSelection();
        }

        private void macrosListBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool alreadyHasSelection = macrosListBox.SelectedIndex >= 0;
            if (e.KeyCode == Keys.Up)
            {
                if (e.Shift)
                    ShiftMacroSelection(-1);
                else if (macrosListBox.Items.Count > 0)
                {
                    if (!alreadyHasSelection)
                        macrosListBox.SelectedIndex = macrosListBox.Items.Count - 1;
                    else if (macrosListBox.SelectedIndex > 0)
                        macrosListBox.SelectedIndex -= 1;
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                if (e.Shift)
                    ShiftMacroSelection(1);
                else if (macrosListBox.Items.Count > 0)
                {
                    if (!alreadyHasSelection)
                        macrosListBox.SelectedIndex = 0;
                    else if (macrosListBox.SelectedIndex < macrosListBox.Items.Count - 1)
                        macrosListBox.SelectedIndex += 1;
                }
            }

            if (e.KeyCode == Keys.Delete)
            {
                RemoveMacroSelection();
            }

            if (e.Control && e.KeyCode == Keys.D)
            {
                if (alreadyHasSelection)
                {
                    AddMacro((MacroType)macrosListBox.SelectedItem);
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                SelectMacroFromList();
            }

            e.Handled = true;
        }

        private void macrosListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("Changed");
        }

        private void RefreshGotoMacroControls()
        {
            MacroType macro = null;
            if (faux != null)
                macro = MacroType.GetMacro(faux.nextMacroId);

            gotoMacroCheckBox.Checked = macro != null;
            gotoMacroComboBox.Enabled = macro != null;
            var allMacros = MacroType.GetCachedMacros();
            gotoMacroComboBox.DataSource = allMacros;
            gotoMacroComboBox.SelectedItem = macro;
        }
        private void gotoMacroCheckBox_Click(object sender, EventArgs e)
        {
            var allMacros = MacroType.GetCachedMacros();
            if (gotoMacroCheckBox.Checked)
                faux.nextMacroId = allMacros.Length > 0 ? allMacros.First().GetId() : -1;
            else
                faux.nextMacroId = -1;

            RefreshGotoMacroControls();
        }
        private void gotoMacroComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            faux.nextMacroId = ((MacroType)gotoMacroComboBox.SelectedItem).GetId();
        }

        private void ToggleSequence()
        {
            if (!isRunning)
                RunSequence();
            else if (!macroSequenceToken.IsCancellationRequested)
                macroSequenceToken.Cancel();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            ToggleSequence();
        }

        private void integersDatabaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DatabaseBrowser browser = new DatabaseBrowser();
            browser.SetupData(ValuesDatabase.IntegersToDataTable, (id, value, name) => { ValuesDatabase.SetInteger(id, (int)value, (string)name); }, ValuesDatabase.SaveIntegersTo, ValuesDatabase.LoadIntegers, ValuesDatabase.IntegersExt);
            browser.Text = "Integers";
            browser.ShowDialog();
        }
        private void stringsDatabaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DatabaseBrowser browser = new DatabaseBrowser();
            browser.SetupData(ValuesDatabase.StringsToDataTable, (id, value, name) => { ValuesDatabase.SetString(id, (string)value, (string)name); }, ValuesDatabase.SaveStringsTo, ValuesDatabase.LoadStrings, ValuesDatabase.StringsExt);
            browser.Text = "Strings";
            browser.ShowDialog();
        }
        private void preferencesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var preferences = new Preferences();
            preferences.ShowDialog();
        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }

        private void RefreshMacros()
        {
            macrosListBox.Items.Clear();
            macrosListBox.Items.AddRange(MacroType.GetCachedMacros());
            faux = null;
            RefreshFauxDisplay();
        }

        private SaveFileDialog DefaultSaveDialog()
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Macro Man file (*.mman)|*.mman|All files (*.*)|*.*";
            saveDialog.AddExtension = true;
            saveDialog.CheckPathExists = true;
            string initialDirectory = Environment.CurrentDirectory;
            if (currentFileName != null)
            {
                initialDirectory = currentFileName;
            }
            saveDialog.InitialDirectory = initialDirectory;
            return saveDialog;
        }
        private OpenFileDialog DefaultOpenDialog()
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "Macro Man file (*.mman)|*.mman|All files (*.*)|*.*";
            openDialog.AddExtension = true;
            openDialog.CheckPathExists = true;
            openDialog.CheckFileExists = true;
            string initialDirectory = Environment.CurrentDirectory;
            if (currentFileName != null)
            {
                initialDirectory = currentFileName;
            }
            openDialog.InitialDirectory = initialDirectory;
            return openDialog;
        }
        private MacroType[] GetMacroSequence()
        {
            var sequence = new MacroType[macrosListBox.Items.Count];
            for (int i = 0; i < sequence.Length; i++)
                sequence[i] = (MacroType)macrosListBox.Items[i];
            return sequence;
        }
        private void RefreshTitle()
        {
            string title = "Macro Man";
            if (!string.IsNullOrEmpty(currentFileName))
                title += " [" + Path.GetFileNameWithoutExtension(currentFileName) + "]";
            Text = title;
        }
        private void InitiateSave()
        {
            var sequence = GetMacroSequence();
            if (sequence.Length > 0)
            {
                var saveDialog = DefaultSaveDialog();
                var result = saveDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    currentFileName = saveDialog.FileName;
                    MacroType.SaveSequenceTo(currentFileName, sequence);
                    RefreshTitle();
                }
            }
            else
                MessageBox.Show("Cannot save an empty sequence", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFileName))
                MacroType.SaveSequenceTo(currentFileName, GetMacroSequence());
            else
                InitiateSave();
        }
        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InitiateSave();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openDialog = DefaultOpenDialog();
            var result = openDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentFileName = openDialog.FileName;
                MacroType.LoadToCache(currentFileName);
                RefreshTitle();
                RefreshMacros();
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MacroType.ClearCache();
            currentFileName = null;
            faux = null;
            RefreshTitle();
            RefreshMacros();
            RefreshFauxDisplay();
        }

        private async void RunSequence()
        {
            if (macrosListBox.Items.Count > 0)
            {
                playButton.Text = "◼";

                isRunning = true;
                macroSequenceToken = new CancellationTokenSource();

                macrosListBox.Enabled = false;
                shiftMacroDownButton.Enabled = false;
                shiftMacroUpButton.Enabled = false;
                deleteButton.Enabled = false;
                macrosListBox.SelectedIndex = -1;

                MacroType[] sequence = new MacroType[macrosListBox.Items.Count];
                for (int i = 0; i < sequence.Length; i++)
                    sequence[i] = (MacroType)macrosListBox.Items[i];

                try
                {
                    await MacroType.Execute(macroSequenceToken.Token, sequence);
                }
                catch (Exception) { }

                macrosListBox.Enabled = true;
                shiftMacroDownButton.Enabled = true;
                shiftMacroUpButton.Enabled = true;
                deleteButton.Enabled = true;
                isRunning = false;

                playButton.Text = "➤";
            }
        }
    }
}
