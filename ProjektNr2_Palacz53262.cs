using System;
using System.Drawing;
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
            string[] mpTablicaStringow = new string[mpRozmiarTablicy]; // zadeklarowanie pustej tablicy
            Random mpR = new Random(); // generator liczb losowych
            for (ushort mpI = 0; mpI < mpTablicaStringow.Length; mpI++) // iterowanie przez całą tablicę
            {
                string mpNapis = ""; // zadeklarowanie pustego napisu
                for (ushort mpJ = 0; mpJ < mpR.Next(mpMaxDlugoscElementowTablicy); mpJ++) // tworzenie wyrazu o losowej wielkości (maksymalna wielkość wynosi 20)
                    mpNapis += (char)(mpR.Next(32, 126)); // dodawanie do napisu losowego znaku z zakresu ascii (z pominięciem znaków sterujących)
                mpTablicaStringow[mpI] = mpNapis; // przypisanie wartości napisu do aktualnie iterowanego elementu tablicy
            }
            return mpTablicaStringow;
        }

        // funkcja wykonująca sortowanie za pomocą MergeSort i BucketSort
        private bool mpSortowanie(out ushort mpMaxRozmiarTablicy, out ushort[] mpDaneZPomiaruMergeSort, out ushort[] mpDaneZPomiaruBucketSort, out ushort[] mpWynikiAnalityczneMergeSort,
            out ushort[] mpWynikiAnalityczneBucketSort, out ushort[] mpWynikiKosztuPamieciowegoMergeSort, out ushort[] mpWynikiKosztuPamieciowegoBucketSort)
        {
            bool mpCzyPoprawneDane = true;
            mpErrorProvider1.Clear(); // wyczyszczenie błędów wyświetlanych przez kontrolkę errorProvider
            ushort mpLicznikMergeSort=0; // licznik operacji dominujących algorytmu MergeSort
            ushort mpLicznikBucketSort=0; // licznik operacji dominujących algorytmu BucketSort
            // wczytanie zormiaru tablicy
            if (!ushort.TryParse(mpTXTMaxRozmiarTablicy.Text, out mpMaxRozmiarTablicy))
            {
                mpErrorProvider1.SetError(mpTXTMaxRozmiarTablicy, "Proszę wpisać liczbę naturalną");
                mpCzyPoprawneDane = false;
            }
            // wczytanie próby badawczej
            if (!ushort.TryParse(mpTXTProbaBadawcza.Text, out ushort mpProbaBadawcza))
            {
                mpErrorProvider1.SetError(mpTXTProbaBadawcza, "Proszę wpisać liczbę naturalną");
                mpCzyPoprawneDane = false;
            }
            // pobranie maksymalnego rozmiaru elementów tablicy
            if (!ushort.TryParse(mpTXTMaxWielkoscElementowTablicy.Text, out ushort mpMaxRozmiarElementowTablic))
            {
                mpErrorProvider1.SetError(mpTXTMaxWielkoscElementowTablicy, "Proszę wpisać liczbę naturalną");
                mpCzyPoprawneDane = false;
            }
            // sprawdzenie czy wczytane dane są równe od zera
            if (mpTXTMaxRozmiarTablicy.Text == "0")
            {
                mpErrorProvider1.SetError(mpTXTMaxRozmiarTablicy, "Wartość musi być większa od 0");
                mpCzyPoprawneDane = false;
            }
            if (mpTXTProbaBadawcza.Text == "0")
            {
                mpErrorProvider1.SetError(mpTXTProbaBadawcza, "Wartość musi być większa od 0");
                mpCzyPoprawneDane = false;
            }
            if (mpTXTMaxWielkoscElementowTablicy.Text == "0")
            {
                mpErrorProvider1.SetError(mpTXTMaxWielkoscElementowTablicy, "Wartość musi być większa od 0");
                mpCzyPoprawneDane = false;
            }
            // jeśli dane są niepoprawne, wynikom przypisuje się wartości 0 lub null i zwracana jest wartość false
            if (!mpCzyPoprawneDane)
            {
                mpMaxRozmiarTablicy = 0;
                mpDaneZPomiaruBucketSort = null;
                mpDaneZPomiaruMergeSort = null;
                mpWynikiAnalityczneBucketSort = null;
                mpWynikiAnalityczneMergeSort = null;
                mpWynikiKosztuPamieciowegoBucketSort = null;
                mpWynikiKosztuPamieciowegoMergeSort = null;
                return false;
            }
            // deklaracja tablic do przechowywania średnich ilości wykonanych operacji dominująch
            mpDaneZPomiaruMergeSort = new ushort[mpMaxRozmiarTablicy + 1];
            mpDaneZPomiaruBucketSort = new ushort[mpMaxRozmiarTablicy + 1];
            // deklaracja talic do przechowywania kosztów czasowych wykonywania algorytmów
            mpWynikiAnalityczneMergeSort = new ushort[mpMaxRozmiarTablicy + 1];
            mpWynikiAnalityczneBucketSort = new ushort[mpMaxRozmiarTablicy + 1];
            // deklaracja tablic do przechowywania kosztów pamięci wykonanych algorytmów
            mpWynikiKosztuPamieciowegoMergeSort = new ushort[mpMaxRozmiarTablicy + 1];
            mpWynikiKosztuPamieciowegoBucketSort = new ushort[mpMaxRozmiarTablicy + 1];
            // przeprowadznie eksperymentu dla każdego rozmiaru tablicy
            for (ushort mpI = 1; mpI <= mpMaxRozmiarTablicy; mpI++)
            {
                // wykonywanie eksperytmentu w ilości podanej próby badawczej
                for (ushort mpJ = 0; mpJ < mpProbaBadawcza; mpJ++)
                {
                    // generowanie tablic do sortowania 
                    mpTMergeSort = mpGeneratorTablicString(mpI, mpMaxRozmiarElementowTablic);
                    mpTBucketSort = mpTMergeSort;
                    // sortowanie tablic i aktualizacja liczników operacji dominujących
                    mpLicznikMergeSort += (ushort)MPAlgorytmySortowania.mpMergeSortProjekt(ref mpTMergeSort, 0, mpI - 1);
                    mpLicznikBucketSort += (ushort)MPAlgorytmySortowania.mpBucketSortProjekt(ref mpTBucketSort);
                }
                // przechowanie średnich ilości opercji dominujących w talicach z danymi z pomiaru
                mpDaneZPomiaruMergeSort[mpI] = (ushort)(mpLicznikMergeSort / mpProbaBadawcza);
                mpDaneZPomiaruBucketSort[mpI] = (ushort)(mpLicznikBucketSort / mpProbaBadawcza);
                // przechowanie kosztu czasowego w tablicy
                mpWynikiAnalityczneMergeSort[mpI] = (ushort)(mpI * (Math.Log(mpI) / Math.Log(2) + 1) + mpI);
                mpWynikiAnalityczneBucketSort[mpI] = (ushort)(mpI * 2);
                // przechowanie kosztu pamięciowego algorytmów
                mpWynikiKosztuPamieciowegoMergeSort[mpI] = (ushort)(Math.Log(mpI) / Math.Log(2) + mpI);
                mpWynikiKosztuPamieciowegoBucketSort[mpI] = (ushort)(mpI * 2);
            }
            return true;
        }

        private void mpBTNWynikiTabelarycznie_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy sortowanie się powiodło i pobranie wartości zmiennych z wynikami analizy
            if (!mpSortowanie(out ushort mpMaxRozmiarTablicy, out ushort[] mpDaneZPomiaruMergeSort, out ushort[] mpDaneZPomiaruBucketSort,
                out ushort[] mpWynikiAnalityczneMergeSort, out ushort[] mpWynikiAnalityczneBucketSort, out ushort[] mpWynikiKosztuPamieciMerseSort,
                out ushort[] mpWynikiKosztuPamieciBucketSort))
                return; // jeśli sortowanie się nie powiodło, funkcja jest przerywana
            mpDGVTabelaWyników.Rows.Clear(); // wyczyszczenie wierdzy w kontrolce mpDGVTabelaWyników
            for (ushort mpI = 0; mpI < mpMaxRozmiarTablicy; mpI++) // iterowanie przez elementy tablic wyników
            {
                mpDGVTabelaWyników.Rows.Add(); // dodanie nowego wiersza
                // umieszczanie wyników w odpowiednich kolumnach
                mpDGVTabelaWyników.Rows[mpI].Cells[0].Value = mpI+1;
                mpDGVTabelaWyników.Rows[mpI].Cells[1].Value = mpDaneZPomiaruMergeSort[mpI + 1];
                mpDGVTabelaWyników.Rows[mpI].Cells[2].Value = mpDaneZPomiaruBucketSort[mpI + 1];
                mpDGVTabelaWyników.Rows[mpI].Cells[3].Value = mpWynikiAnalityczneMergeSort[mpI + 1];
                mpDGVTabelaWyników.Rows[mpI].Cells[4].Value = mpWynikiAnalityczneBucketSort[mpI + 1];
                mpDGVTabelaWyników.Rows[mpI].Cells[5].Value = mpWynikiKosztuPamieciMerseSort[mpI + 1];
                mpDGVTabelaWyników.Rows[mpI].Cells[6].Value = mpWynikiKosztuPamieciBucketSort[mpI + 1];
            }
            // wyświetlenie kontrolki DataGridView
            mpDGVTabelaWyników.Visible = true;
            // schowanie kontrolki chart i groupBox
            mpCHTWykresWynikow.Visible = false;
            mpGRBUstawieniaWykresu.Visible = false;
            // odblokowanie mpBTNWizualizacjaTablicyPoSortowaniu i schowanie mpDGVPoSortowaniu
            mpBTNWizualizacjaTablicyPoSortowaniu.Enabled = true;
            mpDGVPoSortowaniu.Visible = false;
            // odblokowanie mpBTNReset
            mpBTNReset.Enabled = true;
        }

        // funkcja zwracająca wybrany typ linii
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

        // wyświetlanie wyników w formie wykresu
        private void mpBTNWykreWynikow_Click(object sender, EventArgs e)
        {
            mpErrorProvider1.Clear(); // wyczyszczenie kotrolki errorProvider

            // przesortowanie tablicy i wykonanie analizy algorytmów
            if (!mpSortowanie(out ushort mpMaxRozmiarTablicy, out ushort[] mpDaneZPomiaruMergeSort, out ushort[] mpDaneZPomiaruBucketSort,
                out ushort[] mpWynikiAnalityczneMergeSort, out ushort[] mpWynikiAnalityczneBucketSort, out ushort[] mpWynikiKosztuPamieciMerseSort,
                out ushort[] mpWynikiKosztuPamieciBucketSort))
                return; // jeśli sortowanie się nie powiodło, funkcja jest przerywana

            // utworzenie tablicy przechowującej rozmiary sortowanych tablic
            ushort[] mpRozmiaryTablic = new ushort[mpMaxRozmiarTablicy + 1];
            // wypełnienie mpRozmiaryTablic
            for (ushort mpI = 0; mpI <= mpMaxRozmiarTablicy; mpI++) mpRozmiaryTablic[mpI] = mpI;

            mpCHTWykresWynikow.Titles.Clear(); // usunięcie tytułów
            mpCHTWykresWynikow.Titles.Add("Złożonośc obliczeniowa algorytmów MergeSort i BucketSort"); // dodanie tytułu

            mpCHTWykresWynikow.BackColor = mpBTNKolorTla.BackColor; // ustawienie koloru tła
            mpCHTWykresWynikow.ChartAreas["ChartArea1"].BackColor = mpBTNKolorTla.BackColor;
            mpCHTWykresWynikow.Legends["Legend1"].BackColor = mpBTNKolorTla.BackColor;
            mpCHTWykresWynikow.Legends["Legend1"].Docking = Docking.Bottom; // ustwaienie legendy pod wykresem
            mpCHTWykresWynikow.Series.Clear(); // wyczyszczenie serii

            mpCHTWykresWynikow.Series.Add("Koszt czasowy MergeSort"); // dodanie nowej serii
            mpCHTWykresWynikow.Series[0].ChartType = SeriesChartType.Line; // ustawienie typu wykresu
            mpCHTWykresWynikow.Series[0].Color = mpBTNKosztCzasowyMergeSortKolor.BackColor; // ustawienie koloru
            // ustawienie typu linii
            mpCHTWykresWynikow.Series[0].BorderDashStyle = mpZmianaTypuLinii(1);
            // ustawienie grubości linii
            mpCHTWykresWynikow.Series[0].BorderWidth = (int)mpNUDKosztCzasowyMergeSortGruboscLinii.Value;
            // wprowadzenie danych
            mpCHTWykresWynikow.Series[0].Points.DataBindXY(mpRozmiaryTablic, mpDaneZPomiaruMergeSort);

            // powtórzenie procesu dla pozostałych danych
            mpCHTWykresWynikow.Series.Add("Analityczny koszt czasowy MergeSort");
            mpCHTWykresWynikow.Series[1].ChartType = SeriesChartType.Line;
            mpCHTWykresWynikow.Series[1].Color = mpBTNAnalitycznyKosztCzasowyMergeSortKolor.BackColor;
            mpCHTWykresWynikow.Series[1].BorderDashStyle = mpZmianaTypuLinii(0);
            mpCHTWykresWynikow.Series[1].BorderWidth = (int)mpNUDAnalitycznyKosztCzasowyMergeSortGruboscLinii.Value;
            mpCHTWykresWynikow.Series[1].Points.DataBindXY(mpRozmiaryTablic, mpWynikiAnalityczneMergeSort);

            mpCHTWykresWynikow.Series.Add("Koszt pamięciowy MergeSort");
            mpCHTWykresWynikow.Series[2].ChartType = SeriesChartType.Line;
            mpCHTWykresWynikow.Series[2].Color = mpBTNKosztPamieciowyMergeSortKolor.BackColor;
            mpCHTWykresWynikow.Series[2].BorderDashStyle = mpZmianaTypuLinii(2);
            mpCHTWykresWynikow.Series[2].BorderWidth = (int)mpNUDKosztPamieciowyMergeSortGruboscLinii.Value;
            mpCHTWykresWynikow.Series[2].Points.DataBindXY(mpRozmiaryTablic, mpWynikiKosztuPamieciMerseSort);

            mpCHTWykresWynikow.Series.Add("Koszt czasowy BucketSort");
            mpCHTWykresWynikow.Series[3].ChartType = SeriesChartType.Line;
            mpCHTWykresWynikow.Series[3].Color = mpBTNKosztCzasowyBucketSortKolor.BackColor;
            mpCHTWykresWynikow.Series[3].BorderDashStyle = mpZmianaTypuLinii(1);
            mpCHTWykresWynikow.Series[3].BorderWidth = (int)mpNUDKosztCzasowyBucketSortGruboscLinii.Value;
            mpCHTWykresWynikow.Series[3].Points.DataBindXY(mpRozmiaryTablic, mpDaneZPomiaruBucketSort);

            mpCHTWykresWynikow.Series.Add("Analityczny koszt czasowy BucketSort");
            mpCHTWykresWynikow.Series[4].ChartType = SeriesChartType.Line;
            mpCHTWykresWynikow.Series[4].Color = mpBTNAnalitycznyKosztCzasowyBucketSortKolor.BackColor;
            mpCHTWykresWynikow.Series[4].BorderDashStyle = mpZmianaTypuLinii(0);
            mpCHTWykresWynikow.Series[4].BorderWidth = (int)mpNUDAnalitycznyKosztCzasowyBucketSortGruboscLinii.Value;
            mpCHTWykresWynikow.Series[4].Points.DataBindXY(mpRozmiaryTablic, mpWynikiAnalityczneBucketSort);

            mpCHTWykresWynikow.Series.Add("Koszt pamięciowy BucketSort");
            mpCHTWykresWynikow.Series[5].ChartType = SeriesChartType.Line;
            mpCHTWykresWynikow.Series[5].Color = mpBTNKosztPamieciowyBucketSortKolor.BackColor;
            mpCHTWykresWynikow.Series[5].BorderDashStyle = mpZmianaTypuLinii(2);
            mpCHTWykresWynikow.Series[5].BorderWidth = (int)mpNUDKosztPamieciowyBucketSortGruboscLinii.Value;
            mpCHTWykresWynikow.Series[5].Points.DataBindXY(mpRozmiaryTablic, mpWynikiKosztuPamieciBucketSort);

            // schowanie kontrolki DataGridView i wyświetlenie kontrolek mpCHTWykresWynikow i mpGRBUstawieniaWykresu 
            mpDGVTabelaWyników.Visible = false;
            mpCHTWykresWynikow.Visible = true;
            mpGRBUstawieniaWykresu.Visible = true;
            // odblokowanie mpBTNWizualizacjaTablicyPoSortowaniu i schowanie mpDGVPoSortowaniu
            mpBTNWizualizacjaTablicyPoSortowaniu.Enabled = true;
            mpDGVPoSortowaniu.Visible = false;
            // odblokowanie mpBTNReset
            mpBTNReset.Enabled = true;

            // ustawienie domyślnych rodzajów linii dla wykresu
            mpCMBAnalitycznyKosztCzasowyBucketSortRodzajLinii.SelectedIndex = 0;
            mpCMBAnalitycznyKosztCzasowyMergeSortRodzajLinii.SelectedIndex = 0;
            mpCMBKosztCzasowyBucketSortRodzajLinii.SelectedIndex = 1;
            mpCMBKosztCzasowyMergeSortRodzajLinii.SelectedIndex = 1;
            mpCMBKosztPamieciowyBucketSortRodzajLinii.SelectedIndex = 2;
            mpCMBKosztPamieciowyMergeSortRodzajLinii.SelectedIndex = 2;
        }

        // funkcje zmieniające kolor poszczególnych elementów wykresu
        private void mpBTNKosztCzasowyMergeSortKolor_Click(object sender, EventArgs e)
        {
            mpColorDialog1.ShowDialog(); // pokazanie mpColorDialog1
            // zmiana koloru przycisku
            mpBTNKosztCzasowyMergeSortKolor.BackColor = mpColorDialog1.Color;
            // zmiana koloru elementu wykresu
            mpCHTWykresWynikow.Series[0].Color = mpColorDialog1.Color;
        }

        private void mpBTNKolorTla_Click(object sender, EventArgs e)
        {
            mpColorDialog1.ShowDialog();
            mpBTNKolorTla.BackColor = mpColorDialog1.Color;
            mpCHTWykresWynikow.BackColor = mpColorDialog1.Color;
            mpCHTWykresWynikow.ForeColor = mpColorDialog1.Color;
            mpCHTWykresWynikow.ChartAreas["ChartArea1"].BackColor = mpColorDialog1.Color;
            mpCHTWykresWynikow.Legends["Legend1"].BackColor = mpColorDialog1.Color;
        }

        private void mpBTNAnalitycznyKosztCzasowyMergeSortKolor_Click(object sender, EventArgs e)
        {
            mpColorDialog1.ShowDialog();
            mpBTNAnalitycznyKosztCzasowyMergeSortKolor.BackColor = mpColorDialog1.Color;
            mpCHTWykresWynikow.Series[1].Color = mpColorDialog1.Color;
        }

        private void mpBTNKosztPamieciowyMergeSortKolor_Click(object sender, EventArgs e)
        {
            mpColorDialog1.ShowDialog();
            mpBTNKosztPamieciowyMergeSortKolor.BackColor = mpColorDialog1.Color;
            mpCHTWykresWynikow.Series[2].Color = mpColorDialog1.Color;
        }

        private void mpBTNKosztCzasowyBucketSortKolor_Click(object sender, EventArgs e)
        {
            mpColorDialog1.ShowDialog();
            mpBTNKosztCzasowyBucketSortKolor.BackColor = mpColorDialog1.Color;
            mpCHTWykresWynikow.Series[3].Color = mpColorDialog1.Color;
        }

        private void mpBTNAnalitycznyKosztCzasowyBucketSortKolor_Click(object sender, EventArgs e)
        {
            mpColorDialog1.ShowDialog();
            mpBTNAnalitycznyKosztCzasowyBucketSortKolor.BackColor = mpColorDialog1.Color;
            mpCHTWykresWynikow.Series[4].Color = mpColorDialog1.Color;
        }

        private void mpBTNKosztPamieciowyBucketSortKolor_Click(object sender, EventArgs e)
        {
            mpColorDialog1.ShowDialog();
            mpBTNKosztPamieciowyBucketSortKolor.BackColor = mpColorDialog1.Color;
            mpCHTWykresWynikow.Series[5].Color = mpColorDialog1.Color;
        }

        // funkcje zmieniające styl linii wykresu
        private void mpCMBKosztCzasowyMergeSortRodzajLinii_SelectedIndexChanged(object sender, EventArgs e)
        {
            mpCHTWykresWynikow.Series[0].BorderDashStyle = mpZmianaTypuLinii(mpCMBKosztCzasowyMergeSortRodzajLinii.SelectedIndex);
        }

        private void mpCMBAnalitycznyKosztCzasowyMergeSortRodzajLinii_SelectedIndexChanged(object sender, EventArgs e)
        {
            mpCHTWykresWynikow.Series[1].BorderDashStyle = mpZmianaTypuLinii(mpCMBAnalitycznyKosztCzasowyMergeSortRodzajLinii.SelectedIndex);
        }

        private void mpCMBKosztPamieciowyMergeSortRodzajLinii_SelectedIndexChanged(object sender, EventArgs e)
        {
            mpCHTWykresWynikow.Series[2].BorderDashStyle = mpZmianaTypuLinii(mpCMBKosztPamieciowyMergeSortRodzajLinii.SelectedIndex);
        }

        private void mpCMBKosztCzasowyBucketSortRodzajLinii_SelectedIndexChanged(object sender, EventArgs e)
        {
            mpCHTWykresWynikow.Series[3].BorderDashStyle = mpZmianaTypuLinii(mpCMBKosztCzasowyBucketSortRodzajLinii.SelectedIndex);
        }

        private void mpCMBAnalitycznyKosztCzasowyBucketSortRodzajLinii_SelectedIndexChanged(object sender, EventArgs e)
        {
            mpCHTWykresWynikow.Series[4].BorderDashStyle = mpZmianaTypuLinii(mpCMBAnalitycznyKosztCzasowyBucketSortRodzajLinii.SelectedIndex);
        }

        private void mpCMBKosztPamieciowyBucketSortRodzajLinii_SelectedIndexChanged(object sender, EventArgs e)
        {
            mpCHTWykresWynikow.Series[5].BorderDashStyle = mpZmianaTypuLinii(mpCMBKosztPamieciowyBucketSortRodzajLinii.SelectedIndex);
        }

        // funkcje zmieniające grubośc linii wykresu
        private void mpNUDKosztCzasowyMergeSortGruboscLinii_ValueChanged(object sender, EventArgs e)
        {
            mpCHTWykresWynikow.Series[0].BorderWidth = (int)mpNUDKosztCzasowyMergeSortGruboscLinii.Value;
        }

        private void mpNUDAnalitycznyKosztCzasowyMergeSortGruboscLinii_ValueChanged(object sender, EventArgs e)
        {
            mpCHTWykresWynikow.Series[1].BorderWidth = (int)mpNUDAnalitycznyKosztCzasowyMergeSortGruboscLinii.Value;
        }

        private void mpNUDKosztPamieciowyMergeSortGruboscLinii_ValueChanged(object sender, EventArgs e)
        {
            mpCHTWykresWynikow.Series[2].BorderWidth = (int)mpNUDKosztPamieciowyMergeSortGruboscLinii.Value;
        }

        private void mpNUDKosztCzasowyBucketSortGruboscLinii_ValueChanged(object sender, EventArgs e)
        {
            mpCHTWykresWynikow.Series[3].BorderWidth = (int)mpNUDKosztCzasowyBucketSortGruboscLinii.Value;
        }

        private void mpNUDAnalitycznyKosztCzasowyBucketSortGruboscLinii_ValueChanged(object sender, EventArgs e)
        {
            mpCHTWykresWynikow.Series[4].BorderWidth = (int)mpNUDAnalitycznyKosztCzasowyBucketSortGruboscLinii.Value;
        }

        private void mpNUDKosztPamieciowyBucketSortGruboscLinii_ValueChanged(object sender, EventArgs e)
        {
            mpCHTWykresWynikow.Series[5].BorderWidth = (int)mpNUDKosztPamieciowyBucketSortGruboscLinii.Value;
        }

        private void mpBTNReset_Click(object sender, EventArgs e)
        {
            // ustawienie domyślnych ustawień dla elementów ustawień wykresu
            mpBTNKolorTla.BackColor=Color.White;
            mpBTNKosztCzasowyMergeSortKolor.BackColor = Color.Red;
            mpBTNAnalitycznyKosztCzasowyMergeSortKolor.BackColor=Color.Green;
            mpBTNKosztPamieciowyMergeSortKolor.BackColor = Color.Blue;
            mpBTNKosztCzasowyBucketSortKolor.BackColor = Color.Yellow;
            mpBTNAnalitycznyKosztCzasowyBucketSortKolor.BackColor = Color.Orange;
            mpBTNKosztPamieciowyBucketSortKolor.BackColor = Color.Purple;
            mpNUDAnalitycznyKosztCzasowyBucketSortGruboscLinii.Value = 1;
            mpNUDAnalitycznyKosztCzasowyMergeSortGruboscLinii.Value = 1;
            mpNUDKosztCzasowyBucketSortGruboscLinii.Value = 1;
            mpNUDKosztCzasowyMergeSortGruboscLinii.Value = 1;
            mpNUDKosztPamieciowyBucketSortGruboscLinii.Value = 1;
            mpNUDKosztPamieciowyMergeSortGruboscLinii.Value = 1;
            mpCMBAnalitycznyKosztCzasowyBucketSortRodzajLinii.SelectedIndex = 0;
            mpCMBAnalitycznyKosztCzasowyMergeSortRodzajLinii.SelectedIndex = 0;
            mpCMBKosztCzasowyBucketSortRodzajLinii.SelectedIndex = 1;
            mpCMBKosztCzasowyMergeSortRodzajLinii.SelectedIndex = 1;
            mpCMBKosztPamieciowyBucketSortRodzajLinii.SelectedIndex = 2;
            mpCMBKosztPamieciowyMergeSortRodzajLinii.SelectedIndex = 2;
            // wyczyszczenie kotrolki errorProvider
            mpErrorProvider1.Clear();
            // wyczyszczenie kontrolki chart
            mpCHTWykresWynikow.Series.Clear();
            mpCHTWykresWynikow.Titles.Clear();
            // wyczyszczenie kontrolki DataGridView
            mpDGVTabelaWyników.Rows.Clear();
            // ukrycie kontrolek
            mpDGVTabelaWyników.Visible = false;
            mpCHTWykresWynikow.Visible = false;
            mpGRBUstawieniaWykresu.Visible = false;
            // wyczyszczenie kontrolek textBox
            mpTXTMaxRozmiarTablicy.Text = null;
            mpTXTMaxWielkoscElementowTablicy.Text = null;
            mpTXTProbaBadawcza.Text = null;
            // zablokowanie mpBTNWizualizacjaTablicyPoSortowaniu
            mpBTNWizualizacjaTablicyPoSortowaniu.Enabled = false;
            // zablokowanie mpBTNWizualizacjaTablicyPoSortowaniu i schowanie mpDGVPoSortowaniu
            mpBTNWizualizacjaTablicyPoSortowaniu.Enabled = false;
            mpDGVPoSortowaniu.Visible = false;
            // zablokowanie przycisku Reset
            mpBTNReset.Enabled = false;
        }

        private void mpBTNWizualizacjaTablicyPoSortowaniu_Click(object sender, EventArgs e)
        {
            mpDGVPoSortowaniu.Rows.Clear(); // wyczyszcznie wierszy
            // iterowanie przez elementy tablic
            for (ushort mpI = 0; mpI < mpTMergeSort.Length; mpI++)
            {
                mpDGVPoSortowaniu.Rows.Add(); // dodanie wiersza
                // wpisanie wartości do komurek
                mpDGVPoSortowaniu.Rows[mpI].Cells[0].Value = mpI;
                mpDGVPoSortowaniu.Rows[mpI].Cells[1].Value = mpTMergeSort[mpI];
                mpDGVPoSortowaniu.Rows[mpI].Cells[2].Value = mpTBucketSort[mpI];
            }
            // ukrycie kontrolek pokazujących wyniki analizy sortowania
            mpCHTWykresWynikow.Visible = false;
            mpDGVTabelaWyników.Visible = false;
            mpGRBUstawieniaWykresu.Visible = false;
            // wyświetlenie kontrolki mpDGVPoSortowaniu
            mpDGVPoSortowaniu.Visible = true;
        }

        
    }
}
