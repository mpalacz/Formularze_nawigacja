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
    public partial class Pulpit : Form
    {
        public Pulpit()
        {
            InitializeComponent();
        }

        private void mpBTNLaboratoria_Click(object sender, EventArgs e)
        {
            // deklaracja zmiennej referencyjnej do nowego formularza
            Laboratoria mpLaboratoria = new Laboratoria();
            // ukrycie bieżącego formularza, czyli Pulpitu
            Hide();
            // odsłonięcie nowego formularza
            mpLaboratoria.Show();
        }

        private void mpBTNProjektNr2_Click(object sender, EventArgs e)
        {
            // deklaracja zmiennej referencyjnej do nowego formularza
            ProjektNr2_Palacz53262 mpProjektNr2_Palacz53262 = new ProjektNr2_Palacz53262();
            // ukrycie bieżącego formularza, czyli Pulpitu
            Hide();
            // odsłonięcie nowego formularza
            mpProjektNr2_Palacz53262.Show();
        }
    }
}
