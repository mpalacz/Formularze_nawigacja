
namespace Formularze_nawigacja
{
    partial class Laboratoria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mpBTNPoSortowaniu = new System.Windows.Forms.Button();
            this.mpErrorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.mpTXTMinimalnaProbaBadawcza = new System.Windows.Forms.TextBox();
            this.mpTXTKolorTla = new System.Windows.Forms.TextBox();
            this.mpTXTGruboscLinii = new System.Windows.Forms.TextBox();
            this.mpTXTGornaGranica = new System.Windows.Forms.TextBox();
            this.mpTXTDolnaGranica = new System.Windows.Forms.TextBox();
            this.mpTXTRozmiar = new System.Windows.Forms.TextBox();
            this.mpTXTKolorLinii = new System.Windows.Forms.TextBox();
            this.mpCMBAlgorytmySortowania = new System.Windows.Forms.ComboBox();
            this.mpCMBStylLinii = new System.Windows.Forms.ComboBox();
            this.mpBTNKoloriLinii = new System.Windows.Forms.Button();
            this.mpBTNReset = new System.Windows.Forms.Button();
            this.mpBTNWynikWykres = new System.Windows.Forms.Button();
            this.mpBTNWynikiTabelaryczne = new System.Windows.Forms.Button();
            this.mpBTNKolorTla = new System.Windows.Forms.Button();
            this.mpDGVTabelaWynikow = new System.Windows.Forms.DataGridView();
            this.mpTRBGruboscLinii = new System.Windows.Forms.TrackBar();
            this.mpBTNPowrotDoPulpitu = new System.Windows.Forms.Button();
            this.mpChartWykresKosztuCzasowego = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.mpColorDialog1 = new System.Windows.Forms.ColorDialog();
            this.RozmiarTablicy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LicznikOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WynikiAnalityczne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KosztPamieciowy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mpDGVPoSortowaniu = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wartosc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mpErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpDGVTabelaWynikow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpTRBGruboscLinii)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpChartWykresKosztuCzasowego)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpDGVPoSortowaniu)).BeginInit();
            this.SuspendLayout();
            // 
            // mpBTNPoSortowaniu
            // 
            this.mpBTNPoSortowaniu.Enabled = false;
            this.mpBTNPoSortowaniu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mpBTNPoSortowaniu.Location = new System.Drawing.Point(452, 596);
            this.mpBTNPoSortowaniu.Name = "mpBTNPoSortowaniu";
            this.mpBTNPoSortowaniu.Size = new System.Drawing.Size(260, 50);
            this.mpBTNPoSortowaniu.TabIndex = 0;
            this.mpBTNPoSortowaniu.Text = "Wizualizacja tablicy po sortowaniu";
            this.mpBTNPoSortowaniu.UseVisualStyleBackColor = true;
            this.mpBTNPoSortowaniu.Click += new System.EventHandler(this.mpBTNPoSortowaniu_Click);
            // 
            // mpErrorProvider1
            // 
            this.mpErrorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 76);
            this.label1.TabIndex = 1;
            this.label1.Text = "Minimalna próba badawcza\r\n(liczba powtórzeń sortowania\r\ntablicy o tych samych roz" +
    "miarach,\r\nale o różnej zawartości)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(347, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(536, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Analizator złożoności obliczeniowej algorytmów sortowania";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1029, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ustalona grubość linii\r\n(liczbowo)\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1029, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 38);
            this.label4.TabIndex = 4;
            this.label4.Text = "Zmień grubość linii\r\nwykrasu";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(741, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ustal styl linii wykresu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(588, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 38);
            this.label6.TabIndex = 6;
            this.label6.Text = "Wziernik koloru tła\r\ndla wykresu";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(255, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Wziernik koloru linii";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 562);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "Wybierz algorytm do analizy";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 452);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 57);
            this.label9.TabIndex = 9;
            this.label9.Text = "Górna granica przedziału\r\nwartości elementów\r\nsortowania tablicy";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 57);
            this.label10.TabIndex = 10;
            this.label10.Text = "Dolna granica przedziału\r\nwartości elementów\r\nsortowania tablicy";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 271);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 38);
            this.label11.TabIndex = 11;
            this.label11.Text = "Maksymalny rozmiar\r\nsortowania tablic";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mpTXTMinimalnaProbaBadawcza
            // 
            this.mpTXTMinimalnaProbaBadawcza.Location = new System.Drawing.Point(47, 236);
            this.mpTXTMinimalnaProbaBadawcza.Name = "mpTXTMinimalnaProbaBadawcza";
            this.mpTXTMinimalnaProbaBadawcza.Size = new System.Drawing.Size(100, 26);
            this.mpTXTMinimalnaProbaBadawcza.TabIndex = 13;
            // 
            // mpTXTKolorTla
            // 
            this.mpTXTKolorTla.BackColor = System.Drawing.Color.White;
            this.mpTXTKolorTla.Enabled = false;
            this.mpTXTKolorTla.Location = new System.Drawing.Point(592, 103);
            this.mpTXTKolorTla.Name = "mpTXTKolorTla";
            this.mpTXTKolorTla.Size = new System.Drawing.Size(120, 26);
            this.mpTXTKolorTla.TabIndex = 14;
            // 
            // mpTXTGruboscLinii
            // 
            this.mpTXTGruboscLinii.Enabled = false;
            this.mpTXTGruboscLinii.Location = new System.Drawing.Point(1050, 231);
            this.mpTXTGruboscLinii.Name = "mpTXTGruboscLinii";
            this.mpTXTGruboscLinii.Size = new System.Drawing.Size(100, 26);
            this.mpTXTGruboscLinii.TabIndex = 15;
            this.mpTXTGruboscLinii.Text = "1";
            // 
            // mpTXTGornaGranica
            // 
            this.mpTXTGornaGranica.Location = new System.Drawing.Point(47, 512);
            this.mpTXTGornaGranica.Name = "mpTXTGornaGranica";
            this.mpTXTGornaGranica.Size = new System.Drawing.Size(100, 26);
            this.mpTXTGornaGranica.TabIndex = 16;
            // 
            // mpTXTDolnaGranica
            // 
            this.mpTXTDolnaGranica.Location = new System.Drawing.Point(47, 412);
            this.mpTXTDolnaGranica.Name = "mpTXTDolnaGranica";
            this.mpTXTDolnaGranica.Size = new System.Drawing.Size(100, 26);
            this.mpTXTDolnaGranica.TabIndex = 17;
            // 
            // mpTXTRozmiar
            // 
            this.mpTXTRozmiar.Location = new System.Drawing.Point(47, 312);
            this.mpTXTRozmiar.Name = "mpTXTRozmiar";
            this.mpTXTRozmiar.Size = new System.Drawing.Size(100, 26);
            this.mpTXTRozmiar.TabIndex = 18;
            // 
            // mpTXTKolorLinii
            // 
            this.mpTXTKolorLinii.BackColor = System.Drawing.Color.Red;
            this.mpTXTKolorLinii.Enabled = false;
            this.mpTXTKolorLinii.Location = new System.Drawing.Point(259, 103);
            this.mpTXTKolorLinii.Name = "mpTXTKolorLinii";
            this.mpTXTKolorLinii.Size = new System.Drawing.Size(125, 26);
            this.mpTXTKolorLinii.TabIndex = 19;
            // 
            // mpCMBAlgorytmySortowania
            // 
            this.mpCMBAlgorytmySortowania.FormattingEnabled = true;
            this.mpCMBAlgorytmySortowania.Items.AddRange(new object[] {
            "Select Sort",
            "Insertion Sort",
            "Quick Sort",
            "Bubble Sort"});
            this.mpCMBAlgorytmySortowania.Location = new System.Drawing.Point(57, 584);
            this.mpCMBAlgorytmySortowania.Name = "mpCMBAlgorytmySortowania";
            this.mpCMBAlgorytmySortowania.Size = new System.Drawing.Size(132, 27);
            this.mpCMBAlgorytmySortowania.TabIndex = 20;
            this.mpCMBAlgorytmySortowania.Text = "Wybierz algorytm sortowania";
            // 
            // mpCMBStylLinii
            // 
            this.mpCMBStylLinii.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mpCMBStylLinii.Enabled = false;
            this.mpCMBStylLinii.FormattingEnabled = true;
            this.mpCMBStylLinii.Items.AddRange(new object[] {
            "Kreskowana",
            "Kreska-kropka",
            "Kreska-kropka-kropka",
            "Kropkowana",
            "Ciągła"});
            this.mpCMBStylLinii.Location = new System.Drawing.Point(745, 103);
            this.mpCMBStylLinii.Name = "mpCMBStylLinii";
            this.mpCMBStylLinii.Size = new System.Drawing.Size(138, 27);
            this.mpCMBStylLinii.TabIndex = 21;
            this.mpCMBStylLinii.SelectedIndexChanged += new System.EventHandler(this.mpCMBStylLinii_SelectedIndexChanged);
            // 
            // mpBTNKoloriLinii
            // 
            this.mpBTNKoloriLinii.Enabled = false;
            this.mpBTNKoloriLinii.Location = new System.Drawing.Point(82, 80);
            this.mpBTNKoloriLinii.Name = "mpBTNKoloriLinii";
            this.mpBTNKoloriLinii.Size = new System.Drawing.Size(107, 49);
            this.mpBTNKoloriLinii.TabIndex = 22;
            this.mpBTNKoloriLinii.Text = "Wybierz kolor linii";
            this.mpBTNKoloriLinii.UseVisualStyleBackColor = true;
            this.mpBTNKoloriLinii.Click += new System.EventHandler(this.mpBTNKoloriLinii_Click);
            // 
            // mpBTNReset
            // 
            this.mpBTNReset.Enabled = false;
            this.mpBTNReset.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mpBTNReset.Location = new System.Drawing.Point(1050, 536);
            this.mpBTNReset.Name = "mpBTNReset";
            this.mpBTNReset.Size = new System.Drawing.Size(114, 50);
            this.mpBTNReset.TabIndex = 24;
            this.mpBTNReset.Text = "Resetuj";
            this.mpBTNReset.UseVisualStyleBackColor = true;
            this.mpBTNReset.Click += new System.EventHandler(this.mpBTNReset_Click);
            // 
            // mpBTNWynikWykres
            // 
            this.mpBTNWynikWykres.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mpBTNWynikWykres.Location = new System.Drawing.Point(1050, 464);
            this.mpBTNWynikWykres.Name = "mpBTNWynikWykres";
            this.mpBTNWynikWykres.Size = new System.Drawing.Size(114, 68);
            this.mpBTNWynikWykres.TabIndex = 25;
            this.mpBTNWynikWykres.Text = "Graficzna prezentacja złożoności";
            this.mpBTNWynikWykres.UseVisualStyleBackColor = true;
            this.mpBTNWynikWykres.Click += new System.EventHandler(this.mpBTNWynikWykres_Click);
            // 
            // mpBTNWynikiTabelaryczne
            // 
            this.mpBTNWynikiTabelaryczne.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mpBTNWynikiTabelaryczne.Location = new System.Drawing.Point(1050, 390);
            this.mpBTNWynikiTabelaryczne.Name = "mpBTNWynikiTabelaryczne";
            this.mpBTNWynikiTabelaryczne.Size = new System.Drawing.Size(114, 68);
            this.mpBTNWynikiTabelaryczne.TabIndex = 26;
            this.mpBTNWynikiTabelaryczne.Text = "Tabelaryczna prezentacja złożoności";
            this.mpBTNWynikiTabelaryczne.UseVisualStyleBackColor = true;
            this.mpBTNWynikiTabelaryczne.Click += new System.EventHandler(this.mpBTNWynikiTabelaryczne_Click);
            // 
            // mpBTNKolorTla
            // 
            this.mpBTNKolorTla.Enabled = false;
            this.mpBTNKolorTla.Location = new System.Drawing.Point(420, 62);
            this.mpBTNKolorTla.Name = "mpBTNKolorTla";
            this.mpBTNKolorTla.Size = new System.Drawing.Size(145, 67);
            this.mpBTNKolorTla.TabIndex = 27;
            this.mpBTNKolorTla.Text = "Wybierz kolor tła dla obszaru wykresu";
            this.mpBTNKolorTla.UseVisualStyleBackColor = true;
            this.mpBTNKolorTla.Click += new System.EventHandler(this.mpBTNKolorTla_Click);
            // 
            // mpDGVTabelaWynikow
            // 
            this.mpDGVTabelaWynikow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mpDGVTabelaWynikow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RozmiarTablicy,
            this.LicznikOD,
            this.WynikiAnalityczne,
            this.KosztPamieciowy});
            this.mpDGVTabelaWynikow.Location = new System.Drawing.Point(284, 152);
            this.mpDGVTabelaWynikow.Name = "mpDGVTabelaWynikow";
            this.mpDGVTabelaWynikow.Size = new System.Drawing.Size(673, 419);
            this.mpDGVTabelaWynikow.TabIndex = 28;
            this.mpDGVTabelaWynikow.Visible = false;
            // 
            // mpTRBGruboscLinii
            // 
            this.mpTRBGruboscLinii.Enabled = false;
            this.mpTRBGruboscLinii.Location = new System.Drawing.Point(1033, 142);
            this.mpTRBGruboscLinii.Minimum = 1;
            this.mpTRBGruboscLinii.Name = "mpTRBGruboscLinii";
            this.mpTRBGruboscLinii.Size = new System.Drawing.Size(117, 45);
            this.mpTRBGruboscLinii.TabIndex = 29;
            this.mpTRBGruboscLinii.Value = 1;
            this.mpTRBGruboscLinii.Scroll += new System.EventHandler(this.mpTRBGruboscLinii_Scroll);
            // 
            // mpBTNPowrotDoPulpitu
            // 
            this.mpBTNPowrotDoPulpitu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mpBTNPowrotDoPulpitu.Location = new System.Drawing.Point(1014, 12);
            this.mpBTNPowrotDoPulpitu.Name = "mpBTNPowrotDoPulpitu";
            this.mpBTNPowrotDoPulpitu.Size = new System.Drawing.Size(152, 46);
            this.mpBTNPowrotDoPulpitu.TabIndex = 30;
            this.mpBTNPowrotDoPulpitu.Text = "Powrót do pulpitu";
            this.mpBTNPowrotDoPulpitu.UseVisualStyleBackColor = true;
            this.mpBTNPowrotDoPulpitu.Click += new System.EventHandler(this.mpBTNPowrotDoPulpitu_Click);
            // 
            // mpChartWykresKosztuCzasowego
            // 
            chartArea4.Name = "ChartArea1";
            this.mpChartWykresKosztuCzasowego.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.mpChartWykresKosztuCzasowego.Legends.Add(legend4);
            this.mpChartWykresKosztuCzasowego.Location = new System.Drawing.Point(284, 152);
            this.mpChartWykresKosztuCzasowego.Name = "mpChartWykresKosztuCzasowego";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.mpChartWykresKosztuCzasowego.Series.Add(series4);
            this.mpChartWykresKosztuCzasowego.Size = new System.Drawing.Size(673, 419);
            this.mpChartWykresKosztuCzasowego.TabIndex = 31;
            this.mpChartWykresKosztuCzasowego.Visible = false;
            // 
            // RozmiarTablicy
            // 
            this.RozmiarTablicy.HeaderText = "Rozmiar rablicy";
            this.RozmiarTablicy.Name = "RozmiarTablicy";
            this.RozmiarTablicy.ReadOnly = true;
            // 
            // LicznikOD
            // 
            this.LicznikOD.HeaderText = "Licznik operacji dominujących";
            this.LicznikOD.Name = "LicznikOD";
            this.LicznikOD.ReadOnly = true;
            // 
            // WynikiAnalityczne
            // 
            this.WynikiAnalityczne.HeaderText = "Koszt czasowy";
            this.WynikiAnalityczne.Name = "WynikiAnalityczne";
            this.WynikiAnalityczne.ReadOnly = true;
            // 
            // KosztPamieciowy
            // 
            this.KosztPamieciowy.HeaderText = "Koszt pamięciowy";
            this.KosztPamieciowy.Name = "KosztPamieciowy";
            this.KosztPamieciowy.ReadOnly = true;
            // 
            // mpDGVPoSortowaniu
            // 
            this.mpDGVPoSortowaniu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mpDGVPoSortowaniu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.Wartosc});
            this.mpDGVPoSortowaniu.Location = new System.Drawing.Point(284, 152);
            this.mpDGVPoSortowaniu.Name = "mpDGVPoSortowaniu";
            this.mpDGVPoSortowaniu.Size = new System.Drawing.Size(673, 419);
            this.mpDGVPoSortowaniu.TabIndex = 32;
            this.mpDGVPoSortowaniu.Visible = false;
            // 
            // Index
            // 
            this.Index.HeaderText = "Index";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            // 
            // Wartosc
            // 
            this.Wartosc.HeaderText = "Wartość";
            this.Wartosc.Name = "Wartosc";
            this.Wartosc.ReadOnly = true;
            // 
            // Laboratoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 658);
            this.Controls.Add(this.mpDGVPoSortowaniu);
            this.Controls.Add(this.mpChartWykresKosztuCzasowego);
            this.Controls.Add(this.mpBTNPowrotDoPulpitu);
            this.Controls.Add(this.mpTRBGruboscLinii);
            this.Controls.Add(this.mpDGVTabelaWynikow);
            this.Controls.Add(this.mpBTNKolorTla);
            this.Controls.Add(this.mpBTNWynikiTabelaryczne);
            this.Controls.Add(this.mpBTNWynikWykres);
            this.Controls.Add(this.mpBTNReset);
            this.Controls.Add(this.mpBTNKoloriLinii);
            this.Controls.Add(this.mpCMBStylLinii);
            this.Controls.Add(this.mpCMBAlgorytmySortowania);
            this.Controls.Add(this.mpTXTKolorLinii);
            this.Controls.Add(this.mpTXTRozmiar);
            this.Controls.Add(this.mpTXTDolnaGranica);
            this.Controls.Add(this.mpTXTGornaGranica);
            this.Controls.Add(this.mpTXTGruboscLinii);
            this.Controls.Add(this.mpTXTKolorTla);
            this.Controls.Add(this.mpTXTMinimalnaProbaBadawcza);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mpBTNPoSortowaniu);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Laboratoria";
            this.Text = "Laboratoria";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Laboratoria_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.mpErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpDGVTabelaWynikow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpTRBGruboscLinii)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpChartWykresKosztuCzasowego)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpDGVPoSortowaniu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mpBTNPoSortowaniu;
        private System.Windows.Forms.ErrorProvider mpErrorProvider1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mpBTNKolorTla;
        private System.Windows.Forms.Button mpBTNWynikiTabelaryczne;
        private System.Windows.Forms.Button mpBTNWynikWykres;
        private System.Windows.Forms.Button mpBTNReset;
        private System.Windows.Forms.Button mpBTNKoloriLinii;
        private System.Windows.Forms.ComboBox mpCMBStylLinii;
        private System.Windows.Forms.ComboBox mpCMBAlgorytmySortowania;
        private System.Windows.Forms.TextBox mpTXTKolorLinii;
        private System.Windows.Forms.TextBox mpTXTRozmiar;
        private System.Windows.Forms.TextBox mpTXTDolnaGranica;
        private System.Windows.Forms.TextBox mpTXTGornaGranica;
        private System.Windows.Forms.TextBox mpTXTGruboscLinii;
        private System.Windows.Forms.TextBox mpTXTKolorTla;
        private System.Windows.Forms.TextBox mpTXTMinimalnaProbaBadawcza;
        private System.Windows.Forms.DataGridView mpDGVTabelaWynikow;
        private System.Windows.Forms.TrackBar mpTRBGruboscLinii;
        private System.Windows.Forms.Button mpBTNPowrotDoPulpitu;
        private System.Windows.Forms.DataVisualization.Charting.Chart mpChartWykresKosztuCzasowego;
        private System.Windows.Forms.ColorDialog mpColorDialog1;
        private System.Windows.Forms.DataGridView mpDGVPoSortowaniu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wartosc;
        private System.Windows.Forms.DataGridViewTextBoxColumn RozmiarTablicy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LicznikOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn WynikiAnalityczne;
        private System.Windows.Forms.DataGridViewTextBoxColumn KosztPamieciowy;
    }
}