using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private List<KeyboardHook.VK> keysDown = new List<KeyboardHook.VK>();
        private CancellationTokenSource backgroundProcess;

        public MacroForm()
        {
            InitializeComponent();
            KeyboardHook.CreateHook();
            KeyboardHook.onKeyDown += KeyboardHook_onKeyDown;
            KeyboardHook.onKeyUp += KeyboardHook_onKeyUp;

            backgroundProcess = new CancellationTokenSource();
            FrameRunner(backgroundProcess.Token);
        }

        private void MacroForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyboardHook.DestroyHook();
            backgroundProcess.Cancel();
        }

        private void OnUpdate()
        {
            //label1.Text = MouseOperations.GetCursorPosition().ToString();
            //label1.Text = ToComboString(keysDown);
            //MoveMouseWithButtons();
        }

        private void MoveMouseWithButtons()
        {
            var currentMousePosition = MouseOperations.GetCursorPosition();
            int xOffset = 0, yOffset = 0;
            if (keysDown.Contains(KeyboardHook.VK.VK_DOWN))
                yOffset = 10;
            if (keysDown.Contains(KeyboardHook.VK.VK_UP))
                yOffset = -10;
            if (keysDown.Contains(KeyboardHook.VK.VK_LEFT))
                xOffset = -10;
            if (keysDown.Contains(KeyboardHook.VK.VK_RIGHT))
                xOffset = 10;
            if (xOffset != 0 || yOffset != 0)
                MouseOperations.SetCursorPosition(new MouseOperations.MousePoint() { X = currentMousePosition.X + xOffset, Y = currentMousePosition.Y + yOffset });
        }

        private static string ToComboString(List<KeyboardHook.VK> keys)
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
        private void KeyboardHook_onKeyDown(KeyboardHook.VK key)
        {
            if (!keysDown.Contains(key))
                keysDown.Add(key);
        }
        private void KeyboardHook_onKeyUp(KeyboardHook.VK key)
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
    }
}
