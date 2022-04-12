using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularze_nawigacja
{
    public partial class ProjektNr2_Palacz53262 : Form
    {
        public ProjektNr2_Palacz53262()
        {
            InitializeComponent();
        }

        private void mpBTNPowrot_Click(object sender, EventArgs e)
        {
            Pulpit mpPulpit = new Pulpit();
            Hide();
            mpPulpit.FormClosed += new FormClosedEventHandler(delegate { Close(); });
        }
    }
}
