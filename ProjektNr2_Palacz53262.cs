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

        private bool mpPobieranieDanych(out ushort mpMaxRozmiarTablicy, out ushort mpProbaBadawcza, out ushort mpMaxRozmiarElementowTablic)
        {
            mpProbaBadawcza = 0;
            mpMaxRozmiarElementowTablic = 0;
            // wczytanie zormiaru tablicy
            if (!ushort.TryParse(mpTXTMaxRozmiarTablicy.Text, out mpMaxRozmiarTablicy))
            {
                mpErrorProvider1.SetError(mpTXTMaxRozmiarTablicy, "Proszę wpisać liczbę naturalną");
                return false;
            }
            // wczytanie próby badawczej
            if (!ushort.TryParse(mpTXTProbaBadawcza.Text, out mpProbaBadawcza))
            {
                mpErrorProvider1.SetError(mpTXTProbaBadawcza, "Proszę wpisać liczbę naturalną");
                return false;
            }
            // pobranie maksymalnego rozmiaru elementów tablicy
            if (!ushort.TryParse(mpTXTMaxWielkoscElementowTablicy.Text, out mpMaxRozmiarElementowTablic))
            {
                mpErrorProvider1.SetError(mpTXTMaxWielkoscElementowTablicy, "Proszę wpisać liczbę naturalną");
                return false;
            }
            return true;
        }

        private bool mpSortowanie(out ushort mpMaxRozmiarTablicy, out ushort[] mpDaneZPomiaruMergeSort, out ushort[] mpDaneZPomiaruBucketSort, out ushort[] mpWynikiAnalityczneMergeSort,
            out ushort[] mpWynikiAnalityczneBucketSort, out ushort[] mpWynikiKosztuPamieciMergeSort, out ushort[] mpWynikiKosztuPamieciBucketSort)
        {
            bool czyPorpawneDane = true; // zmienna przechowująca informację czy pobrane dane są poprawne
            mpErrorProvider1.Clear(); // wyczyszczenie błędów wyświetlanych przez kontrolkę errorProvider
            ushort mpLicznikMergeSort = 0; // licznik operacji dominujących algorytmu MergeSort
            ushort mpLicznikBucketSort = 0; // licznik operacji dominujących algorytmu BucketSort
            if (!mpPobieranieDanych(out mpMaxRozmiarTablicy, out ushort mpProbaBadawcza, out ushort mpMaxRozmiarElementowTablic))
                czyPorpawneDane = false;
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
            return czyPorpawneDane;
        }

        private void mpBTNWynikiTabelarycznie_Click(object sender, EventArgs e)
        {
            if (!mpSortowanie(out ushort mpMaxRozmiarTablicy, out ushort[] mpDaneZPomiaruMergeSort, out ushort[] mpDaneZPomiaruBucketSort, 
                out ushort[] mpWynikiAnalityczneMergeSort, out ushort[] mpWynikiAnalityczneBucketSort, out ushort[] mpWynikiKosztuPamieciMerseSort, 
                out ushort[] mpWynikiKosztuPamieciBucketSort))
                return;
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
            // wyświetlenie kontrolki DataGridView
            mpDGVTabelaWyników.Visible = true;
            // schowanie kontrolki chart i groupBox
            mpCHTWykresWynikow.Visible = false;
            mpGRBUstawieniaWykresu.Visible = false;
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

            // przesortowanie tablicy i wykonanie analizy algorytmów
            if (mpSortowanie(out ushort mpMaxRozmiarTablicy, out ushort[] mpDaneZPomiaruMergeSort, out ushort[] mpDaneZPomiaruBucketSort, out ushort[] mpWynikiAnalityczneMergeSort,
                out ushort[] mpWynikiAnalityczneBucketSort, out ushort[] mpWynikiKosztuPamieciMerseSort, out ushort[] mpWynikiKosztuPamieciBucketSort))
                return;

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
            // ustawienie typu linii
            mpCHTWykresWynikow.Series[0].BorderDashStyle = mpZmianaTypuLinii(mpCMBKosztCzasowyMergeSortRodzajLinii.SelectedIndex);
            // ustawienie grubości linii
            mpCHTWykresWynikow.Series[0].BorderWidth = (int)mpNUDKosztCzasowyMergeSortGruboscLinii.Value;
            // wprowadzenie danych
            mpCHTWykresWynikow.Series[0].Points.DataBindXY(mpRozmiaryTablic, mpDaneZPomiaruMergeSort);
            
            // powtórzenie procesu dla pozostałych danych
            mpCHTWykresWynikow.Series.Add("Analityczny koszt czasowy MergeSort"); 
            mpCHTWykresWynikow.Series[1].ChartType = SeriesChartType.Line;
            mpCHTWykresWynikow.Series[1].Color = mpBTNAnalitycznyKosztCzasowyMergeSortKolor.BackColor; 
            mpCHTWykresWynikow.Series[1].BorderDashStyle = mpZmianaTypuLinii(mpCMBAnalitycznyKosztCzasowyMergeSortRodzajLinii.SelectedIndex);
            mpCHTWykresWynikow.Series[1].BorderWidth = (int)mpNUDAnalitycznyKosztCzasowyMergeSortGruboscLinii.Value;
            mpCHTWykresWynikow.Series[1].Points.DataBindXY(mpRozmiaryTablic, mpWynikiAnalityczneMergeSort);

            mpCHTWykresWynikow.Series.Add("koszt pamięciowy MergeSort");
            mpCHTWykresWynikow.Series[2].ChartType = SeriesChartType.Line;
            mpCHTWykresWynikow.Series[2].Color = mpBTNKosztPamieciowyMergeSortKolor.BackColor;
            mpCHTWykresWynikow.Series[2].BorderDashStyle = mpZmianaTypuLinii(mpCMBKosztPamieciowyMergeSortRodzajLinii.SelectedIndex);
            mpCHTWykresWynikow.Series[2].BorderWidth = (int)mpNUDKosztPamieciowyMergeSortGruboscLinii.Value;
            mpCHTWykresWynikow.Series[2].Points.DataBindXY(mpRozmiaryTablic, mpWynikiKosztuPamieciMerseSort);

            mpCHTWykresWynikow.Series.Add("Koszt czasowy BucketSort"); 
            mpCHTWykresWynikow.Series[3].ChartType = SeriesChartType.Line; 
            mpCHTWykresWynikow.Series[3].Color = mpBTNKosztCzasowyBucketSortKolor.BackColor; 
            mpCHTWykresWynikow.Series[3].BorderDashStyle = mpZmianaTypuLinii(mpCMBKosztCzasowyBucketSortRodzajLinii.SelectedIndex);
            mpCHTWykresWynikow.Series[3].BorderWidth = (int)mpNUDKosztCzasowyBucketSortGruboscLinii.Value;
            mpCHTWykresWynikow.Series[3].Points.DataBindXY(mpRozmiaryTablic, mpDaneZPomiaruBucketSort);

            mpCHTWykresWynikow.Series.Add("Analityczny koszt czasowy BucketSort");
            mpCHTWykresWynikow.Series[4].ChartType = SeriesChartType.Line;
            mpCHTWykresWynikow.Series[4].Color = mpBTNAnalitycznyKosztCzasowyBucketSortKolor.BackColor;
            mpCHTWykresWynikow.Series[4].BorderDashStyle = mpZmianaTypuLinii(mpCMBAnalitycznyKosztCzasowyBucketSortRodzajLinii.SelectedIndex);
            mpCHTWykresWynikow.Series[4].BorderWidth = (int)mpNUDAnalitycznyKosztCzasowyBucketSortGruboscLinii.Value;
            mpCHTWykresWynikow.Series[4].Points.DataBindXY(mpRozmiaryTablic, mpWynikiAnalityczneBucketSort);

            mpCHTWykresWynikow.Series.Add("koszt pamięciowy BucketSort");
            mpCHTWykresWynikow.Series[5].ChartType = SeriesChartType.Line;
            mpCHTWykresWynikow.Series[5].Color = mpBTNKosztPamieciowyBucketSortKolor.BackColor;
            mpCHTWykresWynikow.Series[5].BorderDashStyle = mpZmianaTypuLinii(mpCMBKosztPamieciowyBucketSortRodzajLinii.SelectedIndex);
            mpCHTWykresWynikow.Series[5].BorderWidth = (int)mpNUDKosztPamieciowyBucketSortGruboscLinii.Value;
            mpCHTWykresWynikow.Series[5].Points.DataBindXY(mpRozmiaryTablic, mpWynikiKosztuPamieciBucketSort);

            // schowanie kontrolki DataGridView i wyświetlenie kontrolek mpCHTWykresWynikow i mpGRBUstawieniaWykresu 
            mpDGVTabelaWyników.Visible = false;
            mpCHTWykresWynikow.Visible = true;
            mpGRBUstawieniaWykresu.Visible = true;
        }
    }
}
