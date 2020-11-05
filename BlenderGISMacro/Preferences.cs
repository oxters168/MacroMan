using MacroMan.MacroActions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MacroMan
{
    public partial class Preferences : Form
    {
        private ListBox.ObjectCollection virtualKeyCollection;

        public Preferences()
        {
            InitializeComponent();

            virtualKeyCollection = new ListBox.ObjectCollection(toggleSequenceShortcutCheckedListBox, ((VirtualKey[])Enum.GetValues(typeof(VirtualKey))).Cast<object>().ToArray());
            toggleSequenceShortcutCheckedListBox.Items.AddRange(virtualKeyCollection);

            sequenceFrameDelayTextBox.Text = MacroType.sequencePlayDelay.ToString();
            RefreshShortcutLabel();
            RefreshShortcutListBox();
        }

        private void RefreshShortcutListBox()
        {
            for (int i = 0; i < virtualKeyCollection.Count; i++)
            {
                var keyOfCollection = (VirtualKey)virtualKeyCollection[i];
                int index = Array.IndexOf(MacroForm.runSequenceShortcut, keyOfCollection);
                toggleSequenceShortcutCheckedListBox.SetItemChecked(i, index >= 0);
            }
        }
        private void RefreshShortcutLabel()
        {
            string output = string.Empty;
            for (int i = 0; i < MacroForm.runSequenceShortcut.Length; i++)
            {
                var key = MacroForm.runSequenceShortcut[i];
                output += key;
                if (i < MacroForm.runSequenceShortcut.Length - 1)
                    output += " + ";
            }
            runSequenceShortcutLabel.Text = output;
        }

        private void ApplyShortcut()
        {
            VirtualKey[] shortcut = new VirtualKey[toggleSequenceShortcutCheckedListBox.CheckedItems.Count];
            for (int i = 0; i < toggleSequenceShortcutCheckedListBox.CheckedItems.Count; i++)
            {
                var key = (VirtualKey)toggleSequenceShortcutCheckedListBox.CheckedItems[i];
                shortcut[i] = key;
            }
            MacroForm.runSequenceShortcut = shortcut;

            RefreshShortcutLabel();
        }
        private void toggleSequenceShortcutCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyShortcut();
        }
        private void toggleSequenceShortcutCheckedListBox_DoubleClick(object sender, EventArgs e)
        {
            ApplyShortcut();
        }
        private void toggleSequenceShortcutCheckedListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ApplyShortcut();
        }

        private void sequenceFrameDelayTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int delay = Convert.ToInt32(sequenceFrameDelayTextBox.Text);
                if (delay < 0)
                    delay = 0;
                MacroType.sequencePlayDelay = delay;
            }
            catch (Exception) { }

            sequenceFrameDelayTextBox.Text = MacroType.sequencePlayDelay.ToString();
        }
    }
}
