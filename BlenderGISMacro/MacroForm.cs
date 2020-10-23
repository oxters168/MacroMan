using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlenderGISMacro
{
    public partial class MacroForm : Form
    {
        private List<VK> keysDown = new List<VK>();
        private CancellationTokenSource backgroundProcess;
        private double startTime = 0;
        private double currentTime = 0;

        public MacroForm()
        {
            InitializeComponent();
            KeyboardHook.CreateHook();
            KeyboardHook.onKeyDown += KeyboardHook_onKeyDown;
            KeyboardHook.onKeyUp += KeyboardHook_onKeyUp;

            backgroundProcess = new CancellationTokenSource();
            FrameRunner(backgroundProcess.Token);

            startTime = DateTime.Now.Ticks / 10000000d;
        }

        private void MacroForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyboardHook.DestroyHook();
            backgroundProcess.Cancel();
        }

        private void OnUpdate()
        {
            currentTime = DateTime.Now.Ticks / 10000000d;

            //label1.Text = MouseOperations.GetCursorPosition().ToString();
            label1.Text = (currentTime - startTime) + "   " + ToComboString(keysDown);
            MoveMouseWithButtons();

            //ExternAPI.PostMessage(Process.GetCurrentProcess().MainWindowHandle, (uint)WM.KEYDOWN, (int)VK.A, 0);
        }

        private void MoveMouseWithButtons()
        {
            var currentMousePosition = MouseOperations.GetCursorPosition();
            int xOffset = 0, yOffset = 0;
            if (keysDown.Contains(VK.DOWN))
                yOffset = 10;
            if (keysDown.Contains(VK.UP))
                yOffset = -10;
            if (keysDown.Contains(VK.LEFT))
                xOffset = -10;
            if (keysDown.Contains(VK.RIGHT))
                xOffset = 10;
            if (xOffset != 0 || yOffset != 0)
                MouseOperations.SetCursorPosition(new MouseOperations.MousePoint() { X = currentMousePosition.X + xOffset, Y = currentMousePosition.Y + yOffset });
        }

        private static string ToComboString(List<VK> keys)
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

        private async void FrameRunner(CancellationToken cancellationToken)
        {
            while (true)
            {
                OnUpdate();
                if (cancellationToken.IsCancellationRequested)
                    break;

                await Task.Delay(10);
            }
        }
        private void KeyboardHook_onKeyDown(VK key)
        {
            if (!keysDown.Contains(key))
                keysDown.Add(key);
        }
        private void KeyboardHook_onKeyUp(VK key)
        {
            keysDown.Remove(key);
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

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            //Applications

            //comboBox1.Items.Clear();
            //comboBox1.Items.AddRange(Process.GetProcesses().Distinct(new ProcessMainHandlerComparer()).Select(process => process.Id + " " + process.ProcessName + " " + process.MainWindowTitle).ToArray());
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
        }
    }
}
