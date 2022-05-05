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
            if (mpCMBAlgorytmySortowania.SelectedIndex < 0)
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
            if (!int.TryParse(mpTXTDolnaGranica.Text, out mpDolnaGranicaPrzedzialu))
            {
                mpErrorProvider1.SetError(mpTXTDolnaGranica, "ERROR: wystąpił niedozwolony znak w zapisie dolnej granicy przedziału wartości elementów tablicy T");
                return;
            }
            if (!int.TryParse(mpTXTGornaGranica.Text, out mpGornaGranicaPrzedzialu))
            {
                mpErrorProvider1.SetError(mpTXTGornaGranica, "ERROR: wystąpił niedozwolony znak w zapisie górnej granicy przedziału wartości elementów tablicy T");
                return;
            }
            if (mpDolnaGranicaPrzedzialu > mpGornaGranicaPrzedzialu)
            {
                mpErrorProvider1.SetError(mpTXTGornaGranica, "ERROR: górna granica musi być większa od dolnej");
                return;
            }
            if (mpDolnaGranicaPrzedzialu == mpGornaGranicaPrzedzialu)
            {
                mpErrorProvider1.SetError(mpTXTDolnaGranica, "ERROR: granice przedziału musą być różne");
                return;
            }
            // utworzenie egzemplarza tablicy do sortowania
            mpT = new int[mpMaxRozmiarTablicy];
            // deklaracja pomocniczych tablic dla przechowywania wyników prowadzonego eksperymentu
            ushort[] mpDaneZPomiaru = new ushort[mpMaxRozmiarTablicy];
            ushort[] mpWynikiAnalityczne = new ushort[mpMaxRozmiarTablicy];
            ushort[] mpTablicowyLicznikOD = new ushort[mpLicznoscProbBadawczych];
            ushort[] mpWynikiKosztuPamięci = new ushort[mpMaxRozmiarTablicy];
            // deklaracje zmiennych pomocniczych
            float mpSredniaOD, mpSumaOD;
            // powtarzanie eksperymentu dla każdego rozmiaru tablicy T
            for (ushort mpL = 1; mpL < mpMaxRozmiarTablicy; mpL++)
            {
                // dla każdego rozmiaru tablicy powtarzamy wielokrotnie proces
                // sortowania i zbierania danych o liczbie wykonanych operacji dominujących
                for (ushort mpK = 1; mpK < mpLicznoscProbBadawczych; mpK++)
                {
                    // generator liczb losowych
                    Random mpRandom = new Random();
                    // dla każdego powtórzenia sortowania tablicy "generujemy" losowo jej zawartość
                    for (ushort mpI = 0; mpI < mpL; mpI++)
                        mpT[mpI] = mpRandom.Next(mpDolnaGranicaPrzedzialu, mpGornaGranicaPrzedzialu);
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
                        case 3:
                            mpLicznikOD += MPAlgorytmySortowania.mpBubbleSort(ref mpT);
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
                        mpWynikiAnalityczne[mpL] = (ushort)(mpL * mpL);
                        break;
                    case 1:
                        mpWynikiAnalityczne[mpL] = (ushort)(mpL * mpL);
                        break;
                    case 2:
                        mpWynikiAnalityczne[mpL] = (ushort)(mpL * (mpL - 1) / 2);
                        break;
                    case 3:
                        mpWynikiAnalityczne[mpL] = (ushort)(mpL * Math.Log(mpL));
                        break;
                }
            }
            mpWynikiKosztuPamięci[0] = 1;
            for (ushort mpI = 1; mpI < mpMaxRozmiarTablicy; mpI++)
                switch (mpCMBAlgorytmySortowania.SelectedIndex)
                {
                    case 0:
                        mpWynikiKosztuPamięci[mpI] = 1;
                        break;
                    case 1:
                        mpWynikiKosztuPamięci[mpI] = 1;
                        break;
                    case 2:
                        mpWynikiKosztuPamięci[mpI] = mpI;
                        break;
                    case 3:
                        mpWynikiKosztuPamięci[mpI] = (ushort)(mpI);
                        break;
                }
            // wpisanie uzyskanych danych z przeprowadzonego pomiaru do kontrolki DataGridView
            mpDGVTabelaWynikow.Rows.Clear();
            for (ushort mpI = 0; mpI < mpMaxRozmiarTablicy; mpI++)
            {
                mpDGVTabelaWynikow.Rows.Add();
                mpDGVTabelaWynikow.Rows[mpI].Cells[0].Value = mpI;
                mpDGVTabelaWynikow.Rows[mpI].Cells[1].Value = mpDaneZPomiaru[mpI];
                mpDGVTabelaWynikow.Rows[mpI].Cells[2].Value = mpWynikiAnalityczne[mpI];
                mpDGVTabelaWynikow.Rows[mpI].Cells[3].Value = mpWynikiKosztuPamięci[mpI];
                // zmiana koloru tła dla wierszy parzystych
                if (mpI % 2 == 0)
                {
                    mpDGVTabelaWynikow.Rows[mpI].Cells[0].Style.BackColor = Color.LightGray;
                    mpDGVTabelaWynikow.Rows[mpI].Cells[1].Style.BackColor = Color.LightGray;
                    mpDGVTabelaWynikow.Rows[mpI].Cells[2].Style.BackColor = Color.LightGray;
                    mpDGVTabelaWynikow.Rows[mpI].Cells[3].Style.BackColor = Color.LightGray;
                }
                else
                {
                    mpDGVTabelaWynikow.Rows[mpI].Cells[0].Style.BackColor = Color.White;
                    mpDGVTabelaWynikow.Rows[mpI].Cells[1].Style.BackColor = Color.White;
                    mpDGVTabelaWynikow.Rows[mpI].Cells[2].Style.BackColor = Color.White;
                    mpDGVTabelaWynikow.Rows[mpI].Cells[3].Style.BackColor = Color.White;
                }
            }
            // odsłonięcie kontrolki DataGridView
            mpDGVTabelaWynikow.Visible = true;
            // ukrycie kontrolki Chart
            mpChartWykresKosztuCzasowego.Visible = false;
            // ukrycie kontrolki mpDGVPoSortowaniu
            mpDGVPoSortowaniu.Visible = false;
            // odlbokowanie resetu
            mpBTNReset.Enabled = true;
        }

        private void mpBTNPowrotDoPulpitu_Click(object sender, EventArgs e)
        {
            Hide(); // schowanie obecnie pokazywanego okna
            Application.OpenForms[0].Show(); // pokaznie okna pulpitu
        }

        // zakończenie działania programu, po zamknięciu okna
        private void Laboratoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mpBTNWynikWykres_Click(object sender, EventArgs e)
        {
            mpErrorProvider1.Dispose();
            ushort mpLicznikOD = 0;
            if (mpCMBAlgorytmySortowania.SelectedIndex < 0)
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
            if (!int.TryParse(mpTXTDolnaGranica.Text, out mpDolnaGranicaPrzedzialu))
            {
                mpErrorProvider1.SetError(mpTXTDolnaGranica, "ERROR: wystąpił niedozwolony znak w zapisie dolnej granicy przedziału wartości elementów tablicy T");
                return;
            }
            if (!int.TryParse(mpTXTGornaGranica.Text, out mpGornaGranicaPrzedzialu))
            {
                mpErrorProvider1.SetError(mpTXTGornaGranica, "ERROR: wystąpił niedozwolony znak w zapisie górnej granicy przedziału wartości elementów tablicy T");
                return;
            }
            if (mpDolnaGranicaPrzedzialu > mpGornaGranicaPrzedzialu)
            {
                mpErrorProvider1.SetError(mpTXTGornaGranica, "ERROR: górna granica musi być większa od dolnej");
                return;
            }
            if (mpDolnaGranicaPrzedzialu == mpGornaGranicaPrzedzialu)
            {
                mpErrorProvider1.SetError(mpTXTDolnaGranica, "ERROR: granice przedziału musą być różne");
                return;
            }
            // utworzenie egzemplarza tablicy do sortowania
            mpT = new int[mpMaxRozmiarTablicy];
            // deklaracja pomocniczych tablic dla przechowywania wyników prowadzonego eksperymentu
            ushort[] mpDaneZPomiaru = new ushort[mpMaxRozmiarTablicy];
            ushort[] mpWynikiAnalityczne = new ushort[mpMaxRozmiarTablicy];
            ushort[] mpTablicowyLicznikOD = new ushort[mpLicznoscProbBadawczych];
            ushort[] mpWynikiKosztuPamięci = new ushort[mpMaxRozmiarTablicy];
            // deklaracje zmiennych pomocniczych
            float mpSredniaOD, mpSumaOD;
            // powtarzanie eksperymentu dla każdego rozmiaru tablicy T
            for (ushort mpL = 1; mpL < mpMaxRozmiarTablicy; mpL++)
            {
                // dla każdego rozmiaru tablicy powtarzamy wielokrotnie proces
                // sortowania i zbierania danych o liczbie wykonanych operacji dominujących
                for (ushort mpK = 1; mpK < mpLicznoscProbBadawczych; mpK++)
                {
                    // generator liczb losowych
                    Random mpRandom = new Random();
                    // dla każdego powtórzenia sortowania tablicy "generujemy" losowo jej zawartość
                    for (ushort mpI = 0; mpI < mpL; mpI++)
                        mpT[mpI] = mpRandom.Next(mpDolnaGranicaPrzedzialu, mpGornaGranicaPrzedzialu);
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
                        case 3:
                            mpLicznikOD += MPAlgorytmySortowania.mpBubbleSort(ref mpT);
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
                        mpWynikiAnalityczne[mpL] = (ushort)(mpL * mpL);
                        break;
                    case 1:
                        mpWynikiAnalityczne[mpL] = (ushort)(mpL * mpL);
                        break;
                    case 2:
                        mpWynikiAnalityczne[mpL] = (ushort)(mpL * (mpL - 1) / 2);
                        break;
                    case 3:
                        mpWynikiAnalityczne[mpL] = (ushort)(mpL * Math.Log(mpL));
                        break;
                }
            }
            mpWynikiKosztuPamięci[0] = 1;
            for (ushort mpI = 1; mpI < mpMaxRozmiarTablicy; mpI++)
                switch (mpCMBAlgorytmySortowania.SelectedIndex)
                {
                    case 0:
                        mpWynikiKosztuPamięci[mpI] = 1;
                        break;
                    case 1:
                        mpWynikiKosztuPamięci[mpI] = 1;
                        break;
                    case 2:
                        mpWynikiKosztuPamięci[mpI] = mpI;
                        break;
                    case 3:
                        mpWynikiKosztuPamięci[mpI] = (ushort)(mpI);
                        break;
                }
            // wpisanie wyników pomiaru do kontrolki Chart
            // odsłonięcie kontrolki Chart
            mpChartWykresKosztuCzasowego.Visible = true;
            // ustalenie tytułu wykresu
            mpChartWykresKosztuCzasowego.Titles.Add("Złóżoność obliczeniowa " +
                "algorytmu: " + mpCMBAlgorytmySortowania.SelectedItem);
            // ustalenie koloru tła kontrolki Chart
            mpChartWykresKosztuCzasowego.BackColor = mpTXTKolorTla.BackColor;
            // ustawienie legendy pod rysukiem
            mpChartWykresKosztuCzasowego.Legends["Legend1"].Docking = Docking.Bottom;
            // deklaracja i utworzenie tablicy rozmiarów badanych (sortowanych) tablic elementów
            int[] mpRozmiarTablicElementow = new int[mpMaxRozmiarTablicy];
            for (ushort mpI = 0; mpI < mpMaxRozmiarTablicy; mpI++)
                mpRozmiarTablicElementow[mpI] = mpI;
            // wyczyszczenie kontrolki Chart
            mpChartWykresKosztuCzasowego.Series.Clear();
            // dodanie do kontrolki Chart pierwszej serii danych,
            // która będzie opisywała koszt czasowy z pomiaru 
            mpChartWykresKosztuCzasowego.Series.Add("Seria 1");
            mpChartWykresKosztuCzasowego.Series[0].Name = "Koszt czasowy z pomiaru";
            // ustalenie typou wykresu
            mpChartWykresKosztuCzasowego.Series[0].ChartType = SeriesChartType.Line;
            // ustalenie koloru
            mpChartWykresKosztuCzasowego.Series[0].Color = mpTXTKolorLinii.BackColor;
            mpChartWykresKosztuCzasowego.Series[0].BorderDashStyle = mpZmianaTypuLinii(1);
            mpChartWykresKosztuCzasowego.Series[0].BorderWidth = int.Parse(mpTXTGruboscLinii.Text);
            // dodanie do serii danych o numerze 0 współrzędnych kreślonej linii
            mpChartWykresKosztuCzasowego.Series[0].Points.DataBindXY(mpRozmiarTablicElementow, mpDaneZPomiaru);

            // dodanie drugiej serii danych dla wizualizacji analitycznej kosztu czasowego
            mpChartWykresKosztuCzasowego.Series.Add("Seria 2");
            mpChartWykresKosztuCzasowego.Series[1].Name = "Analityczny koszt czasowy";
            // ustalenie typu wykresu
            mpChartWykresKosztuCzasowego.Series[1].ChartType = SeriesChartType.Line;
            mpChartWykresKosztuCzasowego.Series[1].Color = mpTXTKolorLinii.BackColor;
            mpChartWykresKosztuCzasowego.Series[1].BorderDashStyle = mpZmianaTypuLinii(1);
            mpChartWykresKosztuCzasowego.Series[1].BorderWidth = 1;
            // przypisanie serii danych o numerze 1 współrzędnych punktów kreślonej linii
            mpChartWykresKosztuCzasowego.Series[1].Points.DataBindXY(mpRozmiarTablicElementow, mpWynikiAnalityczne);

            // dodanie nowej serii danych (dla kosztu pamięciowego algorytmu)
            mpChartWykresKosztuCzasowego.Series.Add("Seria 3");
            mpChartWykresKosztuCzasowego.Series[2].Name = "Koszt pamięciowy";
            mpChartWykresKosztuCzasowego.Series[1].ChartType = SeriesChartType.Line;
            mpChartWykresKosztuCzasowego.Series[2].Color = Color.Green;
            mpChartWykresKosztuCzasowego.Series[2].BorderDashStyle = mpZmianaTypuLinii(1);
            mpChartWykresKosztuCzasowego.Series[2].BorderWidth = 3;
            mpChartWykresKosztuCzasowego.Series[2].Points.DataBindXY(mpRozmiarTablicElementow, mpWynikiKosztuPamięci);
            // ukrycie kontrolek DataGridView
            mpDGVTabelaWynikow.Visible = false;
            mpDGVPoSortowaniu.Visible = false;
            // pokazanie kontrolki Chart
            mpChartWykresKosztuCzasowego.Visible = true;
            // odlokowanie kontrolek zmieniających wygląd wykresu
            mpBTNKoloriLinii.Enabled = true;
            mpBTNKolorTla.Enabled = true;
            mpCMBStylLinii.Enabled = true;
            mpTRBGruboscLinii.Enabled = true;
            // odblokowanie mpBTNPoSortowaniu
            mpBTNPoSortowaniu.Enabled = true;
            // odblokowanie resetu
            mpBTNReset.Enabled = true;
            // ustawienie domyślnego stylu linii
            mpCMBStylLinii.SelectedIndex = 1;
        }

        private void mpBTNPoSortowaniu_Click(object sender, EventArgs e)
        {
            // pokazanie kontrolki i schowanie pozostałych 
            mpDGVPoSortowaniu.Visible = true;
            mpDGVTabelaWynikow.Visible = false;
            mpChartWykresKosztuCzasowego.Visible = false;

            // wyczyszczenie wierszy
            mpDGVPoSortowaniu.Rows.Clear();

            // umieszcznie danych w tabeli
            for (ushort mpI = 0; mpI < mpT.Length - 1; mpI++)
            {
                mpDGVPoSortowaniu.Rows.Add();
                mpDGVPoSortowaniu.Rows[mpI].Cells[0].Value = mpI;
                mpDGVPoSortowaniu.Rows[mpI].Cells[1].Value = mpT[mpI];
            }
        }

        private void mpBTNKoloriLinii_Click(object sender, EventArgs e)
        {
            mpColorDialog1.ShowDialog(); // wyświetlenie kolor dialog
            mpTXTKolorLinii.BackColor = mpColorDialog1.Color; // zmiana koloru mpTXTKolorLinii
            // zmiana koloru linii
            mpChartWykresKosztuCzasowego.Series[0].Color = mpTXTKolorLinii.BackColor;
            mpChartWykresKosztuCzasowego.Series[1].Color = mpTXTKolorLinii.BackColor;
            mpChartWykresKosztuCzasowego.Series[2].Color = mpTXTKolorLinii.BackColor;
        }

        private void mpBTNKolorTla_Click(object sender, EventArgs e)
        {
            mpColorDialog1.ShowDialog(); // wyświetlenie kolor dialog
            mpTXTKolorTla.BackColor = mpColorDialog1.Color; // zmiana koloru mpTXTKolorTla
            // zmiana koloru tła
            mpChartWykresKosztuCzasowego.BackColor = mpTXTKolorTla.BackColor;
        }

        private void mpTRBGruboscLinii_Scroll(object sender, EventArgs e)
        {
            // zmiana napisu w mpTXTGruboscLinii
            mpTXTGruboscLinii.Text = mpTRBGruboscLinii.Value.ToString();
            // zmiana grubości linii
            mpChartWykresKosztuCzasowego.Series[0].BorderWidth = int.Parse(mpTXTGruboscLinii.Text);
            mpChartWykresKosztuCzasowego.Series[1].BorderWidth = int.Parse(mpTXTGruboscLinii.Text);
            mpChartWykresKosztuCzasowego.Series[2].BorderWidth = int.Parse(mpTXTGruboscLinii.Text);
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

        private void mpCMBStylLinii_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mpStyl = mpZmianaTypuLinii(mpCMBStylLinii.SelectedIndex);
            mpChartWykresKosztuCzasowego.Series[0].BorderDashStyle = mpStyl;
            mpChartWykresKosztuCzasowego.Series[1].BorderDashStyle = mpStyl;
            mpChartWykresKosztuCzasowego.Series[2].BorderDashStyle = mpStyl;
        }

        private void mpBTNReset_Click(object sender, EventArgs e)
        {
            // schwowanie tabeleke i wykresu
            mpChartWykresKosztuCzasowego.Visible = false;
            mpDGVPoSortowaniu.Visible = false;
            mpDGVTabelaWynikow.Visible = false;
            // zablokowanie kontrolek
            mpBTNReset.Enabled = false;
            mpBTNPoSortowaniu.Enabled = false;
            mpBTNKolorTla.Enabled = false;
            mpBTNKoloriLinii.Enabled = false;
            mpTRBGruboscLinii.Enabled = false;
            mpCMBStylLinii.Enabled = false;
            // przywrócenie oryginalnych wartości
            mpTXTDolnaGranica.Text = null;
            mpTXTGornaGranica.Text = null;
            mpTXTGruboscLinii.Text = "1";
            mpTXTKolorLinii.BackColor = Color.Red;
            mpTXTKolorTla.BackColor = Color.White;
            mpTRBGruboscLinii.Value = 1;
            mpTXTMinimalnaProbaBadawcza.Text = null;
            mpTXTRozmiar.Text = null;
            mpCMBAlgorytmySortowania.SelectedIndex = -1;
            mpCMBStylLinii.SelectedIndex = 1;
        }
    }
}
