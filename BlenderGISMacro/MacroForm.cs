﻿using System;
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
        private List<VirtualKey> keysDown = new List<VirtualKey>();
        private CancellationTokenSource backgroundProcess;
        private double startTime = 0;
        private double currentTime = 0;
        private const int milliDelay = 10;

        public MacroForm()
        {
            InitializeComponent();
            //Hooker.CreateHook();
            //Hooker.onKeyDown += KeyboardHook_onKeyDown;
            //Hooker.onKeyUp += KeyboardHook_onKeyUp;

            backgroundProcess = new CancellationTokenSource();
            FrameRunner(backgroundProcess.Token);

            startTime = DateTime.Now.Ticks / 10000000d;
        }

        private void MacroForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Hooker.DestroyHook();
            backgroundProcess.Cancel();
        }

        private void OnUpdate()
        {
            currentTime = DateTime.Now.Ticks / 10000000d;

            //label1.Text = MouseOperations.GetCursorPosition().ToString();
            label1.Text = (currentTime - startTime) + "   " + ToComboString(keysDown);
            MoveMouseWithButtons();

            //ExternAPI.PostMessage(Process.GetCurrentProcess().MainWindowHandle, (uint)WM.KEYDOWN, (int)VK.A, 0);
            if (KeyboardOperations.IsKeyPressed(VirtualKey.LCONTROL) && KeyboardOperations.IsKeyPressed(VirtualKey.LSHIFT))
                KeyboardOperations.SetToggleState(VirtualKey.CAPITAL, true);
        }

        private void MoveMouseWithButtons()
        {
            var currentMousePosition = MouseOperations.GetCursorPosition();
            int xOffset = 0, yOffset = 0;
            if (KeyboardOperations.IsKeyPressed(VirtualKey.DOWN))
                yOffset = 10;
            if (KeyboardOperations.IsKeyPressed(VirtualKey.UP))
                yOffset = -10;
            if (KeyboardOperations.IsKeyPressed(VirtualKey.LEFT))
                xOffset = -10;
            if (KeyboardOperations.IsKeyPressed(VirtualKey.RIGHT))
                xOffset = 10;
            if (xOffset != 0 || yOffset != 0)
                MouseOperations.SetCursorPosition(new MouseOperations.MousePoint() { X = currentMousePosition.X + xOffset, Y = currentMousePosition.Y + yOffset });
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
        private void KeyboardHook_onKeyDown(VirtualKey key)
        {
            if (!keysDown.Contains(key))
                keysDown.Add(key);
        }
        private void KeyboardHook_onKeyUp(VirtualKey key)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                var handle = ((Process)comboBox3.SelectedItem).MainWindowHandle;
                WindowOperations.BringToFront(handle);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KeyboardOperations.KeyPress(VirtualKey.CAPITAL);
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                var handle = ((Process)comboBox3.SelectedItem).MainWindowHandle;
                WindowOperations.Minimize(handle);
            }
        }

        private void maximizeBtn_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                var handle = ((Process)comboBox3.SelectedItem).MainWindowHandle;
                WindowOperations.ShowMaximized(handle);
            }
        }

        private void unminimizeBtn_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                var handle = ((Process)comboBox3.SelectedItem).MainWindowHandle;
                WindowOperations.Unminimize(handle);
            }
        }

        private void unmaximizeBtn_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                var handle = ((Process)comboBox3.SelectedItem).MainWindowHandle;
                WindowOperations.ShowNormal(handle);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                var handle = ((Process)comboBox3.SelectedItem).MainWindowHandle;

                int x = 0;
                int y = 0;
                int width = 0;
                int height = 0;
                try
                {
                    x = Convert.ToInt32(textBox1.Text);
                    y = Convert.ToInt32(textBox2.Text);
                    width = Convert.ToInt32(textBox3.Text);
                    height = Convert.ToInt32(textBox4.Text);
                }
                catch (Exception) { }

                WindowOperations.SetRect(handle, new Rectangle() { X = x, Y = y, Width = width, Height = height });
            }

        }

        #region Reorderable stuff
        //Sauce: https://stackoverflow.com/questions/805165/reorder-a-winforms-listbox-using-drag-and-drop
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.listBox1.SelectedItem == null)
                return;
            this.listBox1.DoDragDrop(this.listBox1.SelectedItem, DragDropEffects.Move);
        }
        private void listBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            Point point = listBox1.PointToClient(new Point(e.X, e.Y));
            int index = this.listBox1.IndexFromPoint(point);
            if (index < 0)
                index = this.listBox1.Items.Count - 1;
            object data = e.Data.GetData(typeof(DateTime));
            this.listBox1.Items.Remove(data);
            this.listBox1.Items.Insert(index, data);
        }
        #endregion
    }
}
