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
            Hide(); // schowanie obecnie pokazywanego okna
            Application.OpenForms[0].Show(); // pokaznie okna pulpitu
        }

        // zakończenie działania programu, po zamknięciu okna
        private void ProjektNr2_Palacz53262_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // generator tablic do sortowania
        // dane wejściowe: wielkość zwracanej tablicy i maksymalna długość elementów tablicy
        public static string[] mpGeneratorTablicString(ushort mpRozmiarTablicy, ushort mpMaxDlugoscElementowTablicy) 
        {
            string[] mpTablicaStringów = new string[mpRozmiarTablicy]; // zadeklarowanie pustej tablicy
            Random mpR = new Random(); // generator liczb losowych
            for (ushort mpI = 0; mpI < mpTablicaStringów.Length; mpI++) // iterowanie przez całą tablicę
            {
                string mpNapis = ""; // zadeklarowanie pustego napisu
                for (ushort mpJ = 0; mpJ < mpR.Next(mpMaxDlugoscElementowTablicy); mpJ++) // tworzenie wyrazu o losowej wielkości (maksymalna wielkość wynosi 20)
                    mpNapis += (char)(mpR.Next(32, 126)); // dodawanie do napisu losowego znaku z zakresu ascii (z pominięciem znaków sterujących)
                mpTablicaStringów[mpI] = mpNapis; // przypisanie wartości napisu do aktualnie iterowanego elementu tablicy
            }
            return mpTablicaStringów;
        }

        private void mpBTNWynikiTabelarycznie_Click(object sender, EventArgs e)
        {
            mpErrorProvider1.Clear(); // wyczyszczenie błędów wyświetlanych przez kontrolkę errorProvider
            ushort mpLicznik = 0; // licznik operacji dominujących
            ushort mpRozmiarTablicy; // wczytanie zormiaru tablicy
            if(!ushort.TryParse(mpTXTRozmiarTablicy.Text,out mpRozmiarTablicy))
            {
                mpErrorProvider1.SetError(mpTXTRozmiarTablicy, "Proszę wpisać liczbę naturalną");
                return;
            }
            ushort mpProbaBadawcza; // wczytanie próby badawczej
            if(!ushort.TryParse(mpTXTProbaBadawcza.Text,out mpProbaBadawcza))
            {
                mpErrorProvider1.SetError(mpTXTProbaBadawcza, "Proszę wpisać liczbę naturalną");
                return;
            }
            ushort mpMaxRozmiarElementowTablic; // pobranie maksymalnego rozmiaru elementów tablicy
            if (!ushort.TryParse(mpTXTMaxWielkoscElementowTablicy.Text, out mpMaxRozmiarElementowTablic))
            {
                mpErrorProvider1.SetError(mpTXTMaxWielkoscElementowTablicy, "Proszę wpisać liczbę naturalną");
                return;
            }
            string[] mpT = mpGeneratorTablicString(mpRozmiarTablicy, mpMaxRozmiarElementowTablic);
        }
    }
}
