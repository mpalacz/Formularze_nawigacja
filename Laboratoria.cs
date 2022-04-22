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
            if (!int.TryParse(mpTXTDolnaGranica.Text, out mpGornaGranicaPrzedzialu))
            {
                mpErrorProvider1.SetError(mpTXTDolnaGranica, "ERROR: wystąpił niedozwolony znak w zapisie dolnej granicy przedziału wartości elementów tablicy T");
                return;
            }
            if (!int.TryParse(mpTXTGornaGranica.Text, out mpDolnaGranicaPrzedzialu))
            {
                mpErrorProvider1.SetError(mpTXTGornaGranica, "ERROR: wystąpił niedozwolony znak w zapisie górnej granicy przedziału wartości elementów tablicy T");
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
                    case 3:
                        mpWynikiAnalityczne[mpL] = (ushort)(mpL * (Math.Log(mpL) / Math.Log(2) + 1));
                        break;
                }
            }
            mpWynikiKosztuPamięci[0] = 1;
            for (ushort mpI = 1; mpI < mpMaxRozmiarTablicy; mpI++)
                switch (mpCMBAlgorytmySortowania.SelectedIndex)
                {
                    case 0:
                    case 1:
                        mpWynikiKosztuPamięci[mpI] = mpI;
                        break;
                    case 2:
                    case 3:
                        mpWynikiKosztuPamięci[mpI] = (ushort)(mpI + (Math.Log(mpI) / Math.Log(2)) * 30);
                        // 30 to domyślnie przyjęta wielkość bloku pamięci (dla wywołania metody),
                        // który jest odkładany na stosie (wywołań metod)
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
            // ustawienie stanu braku aktywności dla obsługiwanego przycisku poleceń
            mpBTNWynikiTabelaryczne.Enabled = false;
            // odsłonięcie kontrolki DataGridView
            mpDGVTabelaWynikow.Visible = true;
            // ukrycie kontrolki Chart
            mpChartWykresKosztuCzasowego.Visible = false;
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
            if (!int.TryParse(mpTXTDolnaGranica.Text, out mpGornaGranicaPrzedzialu))
            {
                mpErrorProvider1.SetError(mpTXTDolnaGranica, "ERROR: wystąpił niedozwolony znak w zapisie dolnej granicy przedziału wartości elementów tablicy T");
                return;
            }
            if (!int.TryParse(mpTXTGornaGranica.Text, out mpDolnaGranicaPrzedzialu))
            {
                mpErrorProvider1.SetError(mpTXTGornaGranica, "ERROR: wystąpił niedozwolony znak w zapisie górnej granicy przedziału wartości elementów tablicy T");
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
                    case 3:
                        mpWynikiAnalityczne[mpL] = (ushort)(mpL * (Math.Log(mpL) / Math.Log(2) + 1));
                        break;
                }
            }
            mpWynikiKosztuPamięci[0] = 1;
            for (ushort mpI = 1; mpI < mpMaxRozmiarTablicy; mpI++)
                switch (mpCMBAlgorytmySortowania.SelectedIndex)
                {
                    case 0:
                    case 1:
                        mpWynikiKosztuPamięci[mpI] = mpI;
                        break;
                    case 2:
                    case 3:
                        mpWynikiKosztuPamięci[mpI] = (ushort)(mpI + (Math.Log(mpI) / Math.Log(2)) * 30);
                        // 30 to domyślnie przyjęta wielkość bloku pamięci (dla wywołania metody),
                        // który jest odkładany na stosie (wywołań metod)
                        break;
                }
            // wpisanie wyników pomiaru do kontrolki Chart
            // odsłonięcie kontrolki Chart
            mpChartWykresKosztuCzasowego.Visible = true;
            // ustalenie tytułu wykresu
            mpChartWykresKosztuCzasowego.Titles.Add("Złóżoność obliczeniowa " +
                "algorytmu: "+mpCMBAlgorytmySortowania.SelectedItem);
            // ustalenie koloru tła kontrolki Chart
            mpChartWykresKosztuCzasowego.BackColor = mpTXTKolorTla.BackColor;
            // ustawienie legendy pod rysukiem
            mpChartWykresKosztuCzasowego.Legends["Legend1"].Docking = Docking.Bottom;
            // deklaracja i utworzenie tablicy rozmiarów badanych (sortowanych) tablic elementów
            int[] mpRozmiarTablicElementow = new int[mpMaxRozmiarTablicy];
            for(ushort mpI = 0; mpI < mpMaxRozmiarTablicy; mpI++)
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
            mpChartWykresKosztuCzasowego.Series[0].BorderDashStyle = ChartDashStyle.Dash;
            mpChartWykresKosztuCzasowego.Series[0].BorderWidth = int.Parse(mpTXTGruboscLinii.Text);
            // dodanie do serii danych o numerze 0 współrzędnych kreślonej linii
            mpChartWykresKosztuCzasowego.Series[0].Points.DataBindXY(mpRozmiarTablicElementow, mpDaneZPomiaru);

            // dodanie drugiej serii danych dla wizualizacji analitycznej kosztu czasowego
            mpChartWykresKosztuCzasowego.Series.Add("Seria 2");
            mpChartWykresKosztuCzasowego.Series[1].Name = "Analityczny koszt czasowy";
            // ustalenie typu wykresu
            mpChartWykresKosztuCzasowego.Series[1].ChartType = SeriesChartType.Line;
            mpChartWykresKosztuCzasowego.Series[1].Color= mpTXTKolorLinii.BackColor;
            mpChartWykresKosztuCzasowego.Series[1].BorderDashStyle= ChartDashStyle.Dash;
            mpChartWykresKosztuCzasowego.Series[1].BorderWidth = 1;
            // przypisanie serii danych o numerze 1 współrzędnych punktów kreślonej linii
            mpChartWykresKosztuCzasowego.Series[1].Points.DataBindXY(mpRozmiarTablicElementow, mpWynikiAnalityczne);

            // dodanie nowej serii danych (dla kosztu pamięciowego algorytmu)
            mpChartWykresKosztuCzasowego.Series.Add("Seria 3");
            mpChartWykresKosztuCzasowego.Series[2].Name = "Koszt pamięciowy"; mpChartWykresKosztuCzasowego.Series[1].ChartType = SeriesChartType.Line;
            mpChartWykresKosztuCzasowego.Series[2].Color = Color.Green;
            mpChartWykresKosztuCzasowego.Series[2].BorderDashStyle = ChartDashStyle.Solid;
            mpChartWykresKosztuCzasowego.Series[2].BorderWidth = 3;
            mpChartWykresKosztuCzasowego.Series[2].Points.DataBindXY(mpRozmiarTablicElementow, mpWynikiKosztuPamięci);
            // ukrycie kontrolki DataGridView
            mpDGVTabelaWynikow.Visible = false;
            // pokazanie kontrolki Chart
            mpChartWykresKosztuCzasowego.Visible = true;
        }
    }
}
