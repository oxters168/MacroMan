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

        public MacroForm()
        {
            InitializeComponent();

            backgroundProcess = new CancellationTokenSource();
            FrameRunner(backgroundProcess.Token);

            startTime = DateTime.Now.Ticks / 10000000d;

            macrosComboBox.DataSource = Enum.GetValues(typeof(Macro));
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

        #region Reorderable stuff
        //Sauce: https://stackoverflow.com/questions/805165/reorder-a-winforms-listbox-using-drag-and-drop
        private void macrosListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.macrosListBox.SelectedItem == null)
                return;
            this.macrosListBox.DoDragDrop(this.macrosListBox.SelectedItem, DragDropEffects.Move);
        }
        private void macrosListBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void macrosListBox_DragDrop(object sender, DragEventArgs e)
        {
            Point point = macrosListBox.PointToClient(new Point(e.X, e.Y));
            int index = this.macrosListBox.IndexFromPoint(point);
            if (index < 0)
                index = this.macrosListBox.Items.Count - 1;
            object data = e.Data.GetData(typeof(DateTime));
            this.macrosListBox.Items.Remove(data);
            this.macrosListBox.Items.Insert(index, data);
        }
        #endregion

        private void macrosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Macro currentMacroType = (Macro)macrosComboBox.SelectedItem;
            macroPropertiesListBox.DataSource = MacroType.GetProperties(currentMacroType);
            macroActionComboBox.DataSource = MacroType.GetActions(currentMacroType);
        }

        private void macroNameTextBox_TextChanged(object sender, EventArgs e)
        {
            macroNameLabel.Visible = string.IsNullOrEmpty(macroNameTextBox.Text);
        }
    }
}
