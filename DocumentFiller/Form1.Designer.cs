namespace DocumentFiller
{
    partial class Form1
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
            this.btnFillDocument = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.cmbDocuments = new System.Windows.Forms.ComboBox();
            this.pnlFields = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFillDocument
            // 
            this.btnFillDocument.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnFillDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFillDocument.Location = new System.Drawing.Point(279, 224);
            this.btnFillDocument.Name = "btnFillDocument";
            this.btnFillDocument.Size = new System.Drawing.Size(218, 64);
            this.btnFillDocument.TabIndex = 1;
            this.btnFillDocument.Text = "Uzupełnij dane w dokumencie";
            this.btnFillDocument.UseVisualStyleBackColor = false;
            this.btnFillDocument.Click += new System.EventHandler(this.btnFillDocument_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnSelectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSelectFile.Location = new System.Drawing.Point(279, 140);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(218, 61);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "Dodaj dokumnet do edycji";
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // cmbDocuments
            // 
            this.cmbDocuments.FormattingEnabled = true;
            this.cmbDocuments.Location = new System.Drawing.Point(217, 110);
            this.cmbDocuments.Name = "cmbDocuments";
            this.cmbDocuments.Size = new System.Drawing.Size(354, 24);
            this.cmbDocuments.TabIndex = 3;
            this.cmbDocuments.SelectedIndexChanged += new System.EventHandler(this.cmbDocuments_SelectedIndexChanged);
            // 
            // pnlFields
            // 
            this.pnlFields.Location = new System.Drawing.Point(12, 12);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(57, 53);
            this.pnlFields.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(163, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Po dodaniu wybierz dokument z listy i kliknij uzupełnij";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDocuments);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.btnFillDocument);
            this.Controls.Add(this.pnlFields);
            this.Name = "Form1";
            this.Text = "uzupełnij";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFillDocument;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.ComboBox cmbDocuments;
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.Label label1;
    }
}

