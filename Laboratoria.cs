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
    public partial class Laboratoria : Form
    {
        // deklaracja zmiennej tablicowej (referencyjnej)
        int[] mpT;
        public Laboratoria()
        {
            InitializeComponent();
        }

        private void mpBTNWynikiTabelaryczne_Click(object sender, EventArgs e)
        {
            // zgaszenie kontrolki mpErrorProvider1
            mpErrorProvider1.Dispose();
            // licznik operacji dominujących 
            ushort mpLicznikOD = 0;
            // uaktywnienie przycisku poleceń dla "obejrzenia" posortowanej tablicy
            mpBTNPoSortowaniu.Enabled = true;
            // sprawdzenie, czy został wybrany algorytm sortowania
            if(mpCMBAlgorytmySortowania.SelectedIndex < 0)
            {
                // sygnalizacja błędu
                mpErrorProvider1.SetError(mpBTNWynikiTabelaryczne, "ERROR: musisz wybrać algorytm sortowania");
                return; // przerwanie dalszej obsługi zdarzenia Click
            }
            // pobranie maksymalnego rozmiaru tablicy do sortowania
            ushort mpMaxRozmiarTablicy;
            if (!ushort.TryParse(mpTXTRozmiar.Text, out mpMaxRozmiarTablicy))
            {
                // był błąd i musimy go zasygnalizować
                mpErrorProvider1.SetError(mpTXTRozmiar, "ERROR: wystąpił niedozwolony znak w zapisie tablicy do sortowania");
                return; // przerwanie dalszej obsługi zdarzenia Click
            }
            // pobranie liczności próby badawczej
            ushort mpLicznoscProbBadawczych;
            if (!ushort.TryParse(mpTXTMinimalnaProbaBadawcza.Text, out mpLicznoscProbBadawczych))
            {
                mpErrorProvider1.SetError(mpTXTMinimalnaProbaBadawcza, "ERROR: wystąpił niedozwolony znak w zapisie wielkości minimalnej próby badawczej");
                return; // przerwanie dalszej obsługi zdarzenia Click
            }
            // pobranie granicprzedziału wartości elementów tablicy T
            int mpDolnaGranicaPrzedzialu, mpGornaGranicaPrzedzialu;
            if(!int.TryParse(mpTXTDolnaGranica.Text, out mpGornaGranicaPrzedzialu){
                mpErrorProvider1.SetError(mpTXTDolnaGranica, "ERROR: wystąpił niedozwolony znak w zapisie dolnej granicy przedziału wartości elementów tablicy T");
                return;
            }
            if (!int.TryParse(mpTXTGornaGranica.Text, out mpDolnaGranicaPrzedzialu){
                mpErrorProvider1.SetError(mpTXTGornaGranica, "ERROR: wystąpił niedozwolony znak w zapisie górnej granicy przedziału wartości elementów tablicy T");
                return;
            }
            // utworzenie egzemplarza tablicy do sortowania
            mpT = new int[mpMaxRozmiarTablicy];
            // deklaracja pomocniczych tablic dla przechowywania wyników prowadzonego eksperymentu
            ushort[] mpDaneZPomiaru = new ushort[mpMaxRozmiarTablicy];
            ushort[] mpWynikiAnalityczne = new ushort[mpMaxRozmiarTablicy];
            ushort[] mpTablicowyLicznikOD = new ushort[mpLicznoscProbBadawczych];
            // deklaracje zmiennych pomocniczych
            float mpSredniaOD, mpSumaOD;
            // powtarzanie eksperymentu dla każdego rozmiaru tablicy T
            for(ushort mpL = 1;mpL< mpMaxRozmiarTablicy; mpL++)
            {
                // dla każdego rozmiaru tablicy powtarzamy wielokrotnie proces
                // sortowania i zbierania danych o liczbie wykonanych operacji dominujących
                for(ushort mpK = 1; mpK < mpLicznoscProbBadawczych; mpK++)
                {
                    // dla każdego powtórzenia sortowania tablicy "generujemy" losowo jej zawartość
                    for (ushort mpI = 0; mpI < mpL; mpI++)
                        mpT[mpI] = new Random().Next(mpDolnaGranicaPrzedzialu, mpGornaGranicaPrzedzialu);
                    // sortowanie elementów tablicy i zbieranie danych o liczbie wykonanych operacji dominujących
                    // rozpoznanie wybranego algorytmu sortowania
                    switch (mpCMBAlgorytmySortowania.SelectedIndex)
                    {
                        case 0:
                            mpLicznikOD = MPAlgorytmySortowania.mpSelectSort(ref mpT, mpL);
                            break;
                        case 1:
                            mpLicznikOD = MPAlgorytmySortowania.mpInsertionSort(ref mpT, mpL);
                            break;
                        case 2:
                            mpLicznikOD = MPAlgorytmySortowania.mpQuickSort(ref mpT, 0, (ushort)(mpL - 1));
                            break;
                    }
                    // przechowanie licznika wykonanych operacji dominujących
                    mpTablicowyLicznikOD[mpK] = mpLicznikOD;
                }
                // zsumowanie wykonanych operacji dominujących
                mpSumaOD = 0;
                for (ushort mpJ = 0; mpJ < mpLicznoscProbBadawczych; mpJ++)
                    mpSumaOD += mpTablicowyLicznikOD[mpJ];
                // obliczenie średniej arytmetycznej wykonanych operacji dominujących
                mpSredniaOD = mpSumaOD / mpLicznoscProbBadawczych;
                // przechowanie średniej arytmetycznej wykonanych operacji dominujących w tablicy mpDaneZPomiaru
                mpDaneZPomiaru[mpL] = (ushort)(mpSredniaOD);
                // wyznaczenie i przechowanie w tablicy mpWynikiAnalityczne kosztu czasowego obliczonego według zworu analitycznego
                switch (mpCMBAlgorytmySortowania.SelectedIndex)
                {
                    case 0:
                    case 1:
                        mpWynikiAnalityczne[mpL] = (ushort)(mpL * (mpL - 1) / 2);
                        break;
                    case 2:
                        mpWynikiAnalityczne[mpL] = (ushort)(mpL * (Math.Log(mpL) / Math.Log(2) + 1));
                        break;
                }
            }
            // wpisanie uzyskanych danych z przeprowadzonego pomiaru do kontrolki DataGridView
            mpDGVTabelaWynikow.Rows.Clear();
            for(ushort mpI = 0; mpI < mpMaxRozmiarTablicy; mpI++)
            {
                mpDGVTabelaWynikow.Rows.Add();
                mpDGVTabelaWynikow.Rows[mpI].Cells[0].Value = mpI;
                mpDGVTabelaWynikow.Rows[mpI].Cells[1].Value = mpDaneZPomiaru[mpI];
                mpDGVTabelaWynikow.Rows[mpI].Cells[2].Value = mpWynikiAnalityczne[mpI];
            }
        }
    }
}
