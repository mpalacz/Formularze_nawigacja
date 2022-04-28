using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Formularze_nawigacja
{
    public partial class ProjektNr2_Palacz53262 : Form
    {
        // zadeklarowanie tablicy, która zostanie posortowana za pomocą algorytmu Merge Sort
        string[] mpTMergeSort;
        // zadeklarowanie tablicy, która zostanie posortowana za pomocą algorytmu Bucket Sort
        string[] mpTBucketSort;
        public ProjektNr2_Palacz53262()
        {
            InitializeComponent();
            // ustawienie domyślnych rodzajów linii dla wykresu
            mpCMBAnalitycznyKosztCzasowyBucketSortRodzajLinii.SelectedIndex = 0;
            mpCMBAnalitycznyKosztCzasowyMergeSortRodzajLinii.SelectedIndex = 0;
            mpCMBKosztCzasowyBucketSortRodzajLinii.SelectedIndex = 1;
            mpCMBKosztCzasowyMergeSortRodzajLinii.SelectedIndex = 1;
            mpCMBKosztPamieciowyBucketSortRodzajLinii.SelectedIndex = 2;
            mpCMBKosztPamieciowyMergeSortRodzajLinii.SelectedIndex = 2;
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

        private void mpPobieranieDanych(out ushort mpMaxRozmiarTablicy, out ushort mpProbaBadawcza, out ushort mpMaxRozmiarElementowTablic)
        {
            mpMaxRozmiarTablicy = 0;
            mpProbaBadawcza = 0;
            mpMaxRozmiarElementowTablic = 0;
            // wczytanie zormiaru tablicy
            if (!ushort.TryParse(mpTXTMaxRozmiarTablicy.Text, out mpMaxRozmiarTablicy))
            {
                mpErrorProvider1.SetError(mpTXTMaxRozmiarTablicy, "Proszę wpisać liczbę naturalną");
                return;
            }
            // wczytanie próby badawczej
            if (!ushort.TryParse(mpTXTProbaBadawcza.Text, out mpProbaBadawcza))
            {
                mpErrorProvider1.SetError(mpTXTProbaBadawcza, "Proszę wpisać liczbę naturalną");
                return;
            }
            // pobranie maksymalnego rozmiaru elementów tablicy
            if (!ushort.TryParse(mpTXTMaxWielkoscElementowTablicy.Text, out mpMaxRozmiarElementowTablic))
            {
                mpErrorProvider1.SetError(mpTXTMaxWielkoscElementowTablicy, "Proszę wpisać liczbę naturalną");
                return;
            }
        }

        private void mpSortowanie(out ushort mpMaxRozmiarTablicy, out ushort[] mpDaneZPomiaruMergeSort, out ushort[] mpDaneZPomiaruBucketSort, out ushort[] mpWynikiAnalityczneMergeSort,
            out ushort[] mpWynikiAnalityczneBucketSort, out ushort[] mpWynikiKosztuPamieciMergeSort, out ushort[] mpWynikiKosztuPamieciBucketSort)
        {
            mpErrorProvider1.Clear(); // wyczyszczenie błędów wyświetlanych przez kontrolkę errorProvider
            ushort mpLicznikMergeSort = 0; // licznik operacji dominujących algorytmu MergeSort
            ushort mpLicznikBucketSort = 0; // licznik operacji dominujących algorytmu BucketSort
            mpPobieranieDanych(out mpMaxRozmiarTablicy, out ushort mpProbaBadawcza, out ushort mpMaxRozmiarElementowTablic);
            // deklaracja tablic do przechowywania średnich ilości wykonanych operacji dominująch
            mpDaneZPomiaruMergeSort = new ushort[mpMaxRozmiarTablicy];
            mpDaneZPomiaruBucketSort = new ushort[mpMaxRozmiarTablicy];
            // deklaracja talic do przechowywania kosztów czasowych wykonywania algorytmów
            mpWynikiAnalityczneMergeSort = new ushort[mpMaxRozmiarTablicy];
            mpWynikiAnalityczneBucketSort = new ushort[mpMaxRozmiarTablicy];
            // deklaracja tablic do przechowywania kosztów pamięci wykonanych algorytmów
            mpWynikiKosztuPamieciMergeSort = new ushort[mpMaxRozmiarTablicy];
            mpWynikiKosztuPamieciBucketSort = new ushort[mpMaxRozmiarTablicy];
            // przeprowadznie eksperymentu dla każdego rozmiaru tablicy
            for (ushort mpI = 1; mpI < mpMaxRozmiarTablicy; mpI++)
            {
                // wykonywanie eksperytmentu w ilości podanej próby badawczej
                for (ushort mpJ = 1; mpJ < mpProbaBadawcza; mpJ++)
                {
                    // generowanie tablic do sortowania 
                    mpTMergeSort = mpGeneratorTablicString(mpI, mpMaxRozmiarElementowTablic);
                    mpTBucketSort = mpGeneratorTablicString(mpI, mpMaxRozmiarElementowTablic);
                    // sortowanie tablic i aktualizacja liczników operacji dominujących
                    mpLicznikMergeSort += (ushort)MPAlgorytmySortowania.mpMergeSortProjekt(ref mpTMergeSort, 0, mpI);
                    mpLicznikBucketSort += (ushort)MPAlgorytmySortowania.mpBucketSortProjekt(ref mpTBucketSort, mpI);
                }
                // przechowanie średnich ilości opercji dominujących w talicach z danymi z pomiaru
                mpDaneZPomiaruMergeSort[mpI] = (ushort)(mpLicznikMergeSort / mpProbaBadawcza);
                mpDaneZPomiaruBucketSort[mpI] = (ushort)(mpLicznikBucketSort / mpProbaBadawcza);
                // przechowanie kosztu czasowego w tablicy
                mpWynikiAnalityczneMergeSort[mpI] = (ushort)(mpI * Math.Log(mpI));
                mpWynikiAnalityczneBucketSort[mpI] = mpI;
            }
        }

        private void mpBTNWynikiTabelarycznie_Click(object sender, EventArgs e)
        {
            mpSortowanie(out ushort mpMaxRozmiarTablicy, out ushort[] mpDaneZPomiaruMergeSort, out ushort[] mpDaneZPomiaruBucketSort, out ushort[] mpWynikiAnalityczneMergeSort, 
                out ushort[] mpWynikiAnalityczneBucketSort, out ushort[] mpWynikiKosztuPamieciMerseSort, out ushort[] mpWynikiKosztuPamieciBucketSort);
            mpDGVTabelaWyników.Rows.Clear();
            for (ushort mpI = 0; mpI < mpMaxRozmiarTablicy; mpI++)
            {
                mpDGVTabelaWyników.Rows.Add();
                mpDGVTabelaWyników.Rows[mpI].Cells[0].Value = mpI;
                mpDGVTabelaWyników.Rows[mpI].Cells[1].Value = mpDaneZPomiaruMergeSort[mpI];
                mpDGVTabelaWyników.Rows[mpI].Cells[2].Value = mpDaneZPomiaruBucketSort[mpI];
                mpDGVTabelaWyników.Rows[mpI].Cells[3].Value = mpWynikiAnalityczneMergeSort[mpI];
                mpDGVTabelaWyników.Rows[mpI].Cells[4].Value = mpWynikiAnalityczneBucketSort[mpI];
                mpDGVTabelaWyników.Rows[mpI].Cells[5].Value = mpWynikiKosztuPamieciMerseSort[mpI];
                mpDGVTabelaWyników.Rows[mpI].Cells[6].Value = mpWynikiKosztuPamieciBucketSort[mpI];
            }
            mpDGVTabelaWyników.Visible = true;
        }

        // funkcje zmieniające kolor poszczególnych elementów wykresu
        private void mpBTNKosztCzasowyMergeSortKolor_Click(object sender, EventArgs e)
        {
            mpBTNKosztCzasowyMergeSortKolor.BackColor = mpColorDialog1.Color;
        }

        private void mpBTNKolorTla_Click(object sender, EventArgs e)
        {
            mpBTNKolorTla.BackColor = mpColorDialog1.Color;
        }

        private void mpBTNKosztCzasowyMergeSortKolor_Click_1(object sender, EventArgs e)
        {
            mpBTNKosztCzasowyMergeSortKolor.BackColor = mpColorDialog1.Color;
        }

        private void mpBTNAnalitycznyKosztCzasowyMergeSortKolor_Click(object sender, EventArgs e)
        {
            mpBTNAnalitycznyKosztCzasowyMergeSortKolor.BackColor = mpColorDialog1.Color;
        }

        private void mpBTNKosztPamieciowyMergeSortKolor_Click(object sender, EventArgs e)
        {
            mpBTNKosztPamieciowyMergeSortKolor.BackColor = mpColorDialog1.Color;
        }

        private void mpBTNKosztCzasowyBucketSortKolor_Click(object sender, EventArgs e)
        {
            mpBTNKosztCzasowyBucketSortKolor.BackColor = mpColorDialog1.Color;
        }

        private void mpBTNAnalitycznyKosztCzasowyBucketSortKolor_Click(object sender, EventArgs e)
        {
            mpBTNAnalitycznyKosztCzasowyBucketSortKolor.BackColor = mpColorDialog1.Color;

        }

        private void mpBTNKosztPamieciowyBucketSortKolor_Click(object sender, EventArgs e)
        {
            mpBTNKosztPamieciowyBucketSortKolor.BackColor = mpColorDialog1.Color;
        }

        // funkcja zmieniająca typ linii dla danej serii wykresu
        private ChartDashStyle mpZmianaTypuLinii(int index)
        {
            switch (index)
            {
                case 0: return ChartDashStyle.Dash;
                case 1: return ChartDashStyle.DashDot;
                case 2: return ChartDashStyle.DashDotDot;
                case 3: return ChartDashStyle.Dot;
                default: return ChartDashStyle.Solid;
            }
        }

        private void mpBTNWykreWynikow_Click(object sender, EventArgs e)
        {
            mpErrorProvider1.Clear(); // wyczyszczenie kotrolki errorProvider
            // schowanie kontrolki DataGridView i wyświetlenie kontrolek mpCHTWykresWynikow i mpGRBUstawieniaWykresu 
            mpDGVTabelaWyników.Visible = false;
            mpCHTWykresWynikow.Visible = true;
            mpGRBUstawieniaWykresu.Visible = true;

            // przesortowanie tablicy i wykonanie analizy algorytmów
            mpSortowanie(out ushort mpMaxRozmiarTablicy, out ushort[] mpDaneZPomiaruMergeSort, out ushort[] mpDaneZPomiaruBucketSort, out ushort[] mpWynikiAnalityczneMergeSort, 
                out ushort[] mpWynikiAnalityczneBucketSort, out ushort[] mpWynikiKosztuPamieciMerseSort, out ushort[] mpWynikiKosztuPamieciBucketSort);

            // utworzenie tablicy przechowującej rozmiary sortowanych tablic
            int[] mpRozmiaryTablic = new int[mpMaxRozmiarTablicy];
            for (ushort mpI = 0; mpI < mpMaxRozmiarTablicy; mpI++) mpRozmiaryTablic[mpI] = mpI;

            mpCHTWykresWynikow.Titles.Clear(); // usunięcie tytułów
            mpCHTWykresWynikow.Titles.Add("Złożonośc obliczeniowa algorytmów MergeSort i BucketSort"); // dodanie tytułu

            mpCHTWykresWynikow.BackColor = mpBTNKolorTla.BackColor; // ustawienie koloru tła
            mpCHTWykresWynikow.Legends["Legend1"].Docking = Docking.Bottom; // ustwaienie legendy pod wykresem
            mpCHTWykresWynikow.Series.Clear(); // wyczyszczenie serii
            mpCHTWykresWynikow.Series.Add("Koszt czasowy MergeSort"); // dodanie nowej serii
            mpCHTWykresWynikow.Series[0].ChartType = SeriesChartType.Line; // ustawienie typu wykresu
            mpCHTWykresWynikow.Series[0].Color = mpBTNKosztCzasowyMergeSortKolor.BackColor; // ustawienie koloru
            mpCHTWykresWynikow.Series[0].BorderDashStyle = mpZmianaTypuLinii(mpCMBKosztCzasowyMergeSortRodzajLinii.SelectedIndex);
        }
    }
}
