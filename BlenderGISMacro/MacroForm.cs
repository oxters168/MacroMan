using MacroMan.MacroActions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroMan
{
    public partial class MacroForm : Form
    {
        private CancellationTokenSource backgroundProcess;
        private double startTime = 0;
        private double currentTime = 0;
        private const int milliDelay = 10;
        private MacroType faux;

        private bool prevShortcut;

        private VirtualKey[] runShortcut = new VirtualKey[] { VirtualKey.SPACE };

        public MacroForm()
        {
            InitializeComponent();

            backgroundProcess = new CancellationTokenSource();
            FrameRunner(backgroundProcess.Token);

            startTime = DateTime.Now.Ticks / 10000000d;

            macrosComboBox.DataSource = Enum.GetValues(typeof(Macro));
            RefreshFauxDisplay();
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
            backgroundProcess.Cancel();
        }

        private void OnUpdate()
        {
            currentTime = DateTime.Now.Ticks / 10000000d;

            PlayOnShortcut();
        }

        private void PlayOnShortcut()
        {
            bool shortcutPressed = true;
            for (int i = 0; i < runShortcut.Length; i++)
                shortcutPressed &= KeyboardOperations.IsKeyPressed(runShortcut[i]);

            if (shortcutPressed && !prevShortcut)
            {
                RunSequence();
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

        private void RefreshFauxDisplay()
        {
            if (faux != null)
            {
                macroNameTextBox.Text = faux.name;
                macroIdLabel.Text = faux.GetId() >= 0 ? "id: " + faux.GetId() : "id: -";

                Macro fauxType = MacroType.GetMacroType(faux);

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
        }
        private void RefreshPropertyOptions()
        {
            int propertyId = GetCurrentPropertyId();
            Array propertyOptions = MacroType.GetPropertyOptions(GetCurrentMacroType(), propertyId);
            bool hasOptions = propertyOptions != null;
            propertyOptionsPanel.Enabled = hasOptions;
            propertyOptionsPanel.Visible = hasOptions;
            propertyValuePanel.Enabled = !hasOptions;
            propertyValuePanel.Visible = !hasOptions;
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
            RefreshFauxDisplay();
        }

        private void AddMacro(MacroType macro)
        {
            MacroType newMacro = MacroType.GenerateMacro(GetCurrentMacroType(), macro);
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
            faux = (MacroType)macrosListBox.SelectedItem;
            addToListButton.Enabled = false;
            RefreshFauxDisplay();
        }

        private void macroNameTextBox_TextChanged(object sender, EventArgs e)
        {
            macroNameLabel.Visible = string.IsNullOrEmpty(macroNameTextBox.Text);
            faux.name = macroNameTextBox.Text;
        }
        private void propertyOptionsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int propertyId = GetCurrentPropertyId();
            faux.SetPropertyValue(propertyId, (int)propertyOptionsComboBox.SelectedItem);
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

            e.Handled = true;
        }

        private void macrosListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("Changed");
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            RunSequence();
        }
        private async void RunSequence()
        {
            if (macrosListBox.Items.Count > 0)
            {
                macrosListBox.Enabled = false;

                MacroType[] sequence = new MacroType[macrosListBox.Items.Count];
                for (int i = 0; i < sequence.Length; i++)
                    sequence[i] = (MacroType)macrosListBox.Items[i];
                await MacroType.Execute(sequence);

                macrosListBox.Enabled = true;
            }
        }
    }
}
