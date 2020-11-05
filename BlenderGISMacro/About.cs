using System.Windows.Forms;

namespace MacroMan
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void githubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/oxters168/MacroMan");
        }
    }
}
