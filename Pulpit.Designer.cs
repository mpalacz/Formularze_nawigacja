
namespace Formularze_nawigacja
{
    partial class Pulpit
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.mpBTNLaboratoria = new System.Windows.Forms.Button();
            this.mpBTNProjektNr2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mpBTNLaboratoria
            // 
            this.mpBTNLaboratoria.Location = new System.Drawing.Point(18, 44);
            this.mpBTNLaboratoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mpBTNLaboratoria.Name = "mpBTNLaboratoria";
            this.mpBTNLaboratoria.Size = new System.Drawing.Size(265, 75);
            this.mpBTNLaboratoria.TabIndex = 0;
            this.mpBTNLaboratoria.Text = "Analiza złożoności algorytmów z zajęć laboratoryjnych";
            this.mpBTNLaboratoria.UseVisualStyleBackColor = true;
            this.mpBTNLaboratoria.Click += new System.EventHandler(this.mpBTNLaboratoria_Click);
            // 
            // mpBTNProjektNr2
            // 
            this.mpBTNProjektNr2.Location = new System.Drawing.Point(456, 44);
            this.mpBTNProjektNr2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mpBTNProjektNr2.Name = "mpBTNProjektNr2";
            this.mpBTNProjektNr2.Size = new System.Drawing.Size(265, 75);
            this.mpBTNProjektNr2.TabIndex = 1;
            this.mpBTNProjektNr2.Text = "Analiza złożoności algorytmów Projekt Nr 2";
            this.mpBTNProjektNr2.UseVisualStyleBackColor = true;
            this.mpBTNProjektNr2.Click += new System.EventHandler(this.mpBTNProjektNr2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(709, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Analizator złożoności obliczeniowej algorytmów sortowania";
            // 
            // Pulpit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 134);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mpBTNProjektNr2);
            this.Controls.Add(this.mpBTNLaboratoria);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Pulpit";
            this.Text = "Pulpit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mpBTNLaboratoria;
        private System.Windows.Forms.Button mpBTNProjektNr2;
        private System.Windows.Forms.Label label1;
    }
}

