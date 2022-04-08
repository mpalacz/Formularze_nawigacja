
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
            this.mpBTNWynikiTabelaryczne = new System.Windows.Forms.Button();
            this.mpErrorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mpErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mpBTNWynikiTabelaryczne
            // 
            this.mpBTNWynikiTabelaryczne.Location = new System.Drawing.Point(1078, 328);
            this.mpBTNWynikiTabelaryczne.Name = "mpBTNWynikiTabelaryczne";
            this.mpBTNWynikiTabelaryczne.Size = new System.Drawing.Size(75, 23);
            this.mpBTNWynikiTabelaryczne.TabIndex = 0;
            this.mpBTNWynikiTabelaryczne.Text = "button1";
            this.mpBTNWynikiTabelaryczne.UseVisualStyleBackColor = true;
            this.mpBTNWynikiTabelaryczne.Click += new System.EventHandler(this.mpBTNWynikiTabelaryczne_Click);
            // 
            // mpErrorProvider1
            // 
            this.mpErrorProvider1.ContainerControl = this;
            // 
            // Laboratoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 658);
            this.Controls.Add(this.mpBTNWynikiTabelaryczne);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Laboratoria";
            this.Text = "Laboratoria";
            ((System.ComponentModel.ISupportInitialize)(this.mpErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mpBTNWynikiTabelaryczne;
        private System.Windows.Forms.ErrorProvider mpErrorProvider1;
    }
}