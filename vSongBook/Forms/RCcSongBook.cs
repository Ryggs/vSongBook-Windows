using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vSongBook
{
    public partial class RCcSongBook : Form
    {
        int prevs = 0;
        public RCcSongBook()
        {
            InitializeComponent();
        }

        private void newSongTab()
        {
            Form svf;
            svf = new CcSongView();
            prevs = prevs + 1;
            svf.Text = "Search Tab " + prevs;
            //tabParent.TabPages.Add(svf);
        }

        private void CcSongBook_Load(object sender, EventArgs e)
        {
            newSongTab();
        }

        private void menuItemNewTab_Click(object sender, EventArgs e)
        {
            newSongTab();
        }

        private void btnNewTab_Click(object sender, EventArgs e)
        {
            newSongTab();
        }

        private void tabParent_Load(object sender, EventArgs e)
        {

        }

    }
}
