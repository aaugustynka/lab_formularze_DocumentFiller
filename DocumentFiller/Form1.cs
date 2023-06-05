using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DocumentFiller
{
    public partial class Form1 : Form
    {
        private DocumentData documentData;
        private string selectedFilePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnFillDocument_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Wybierz plik dokumentu.");
                return;
            }

            if (cmbDocuments.SelectedItem is Document selectedDocument)
            {
                string xmlFileName = $"output_{Guid.NewGuid()}.xml";
                string selectedFilePath = selectedDocument.TemplatePath;

                // Utworzenie dokumentu Word z szablonu
                using (WordprocessingDocument document = WordprocessingDocument.Open(selectedFilePath, true))
                {
                    // Uzupełnienie pól formularza
                    foreach (System.Windows.Forms.TextBox textBox in pnlFields.Controls.OfType<System.Windows.Forms.TextBox>())
                    {
                        FillFormField(document, textBox.Name, textBox.Text);
                    }
                }

                // Przechwytywanie zdarzenia zamknięcia głównego okna aplikacji
                FormClosing += (s, args) =>
                {
                   
                    SaveDataToXml(xmlFileName, documentData);
                };

                Process.Start(selectedFilePath);

                MessageBox.Show("Dokument został uzupełniony. Dane zostaną zapisane do pliku XML po zamknięciu aplikacji.");
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki Word (*.docx)|*.docx|Wszystkie pliki (*.*)|*.*";
            openFileDialog.Title = "Wybierz plik dokumentu";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                string documentName = Path.GetFileNameWithoutExtension(selectedFilePath);

                Document newDocument = new Document(documentName, selectedFilePath);
                documentData.Documents.Add(newDocument);

                cmbDocuments.DataSource = null;
                cmbDocuments.DataSource = documentData.Documents;
                cmbDocuments.DisplayMember = "Name";
            }
        }

        private void cmbDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocuments.SelectedItem is Document selectedDocument)
            {
                // Usuń istniejące kontrolki TextBox
                pnlFields.Controls.Clear();

                // Pobierz listę nazw pól formularza z wybranego szablonu
                List<string> formFieldNames = GetFormFieldNamesFromTemplate(selectedDocument.TemplatePath);

                // Dodaj nowe kontrolki TextBox dla pól formularza
                foreach (string fieldName in formFieldNames)
                {
                    Label label = new Label();
                    label.Text = fieldName;
                    TextBox textBox = new TextBox();
                    textBox.Name = fieldName;
                    textBox.Dock = DockStyle.Fill;

                    pnlFields.Controls.Add(label);
                    pnlFields.Controls.Add(textBox);
                }
            }
        }

        private void FillFormField(WordprocessingDocument document, string fieldName, string value)
        {
            var tag = document.MainDocumentPart.Document.Body.Descendants<Tag>()
                .FirstOrDefault(t => t.Val == fieldName);

            if (tag != null)
            {
                var sdtElement = tag.Parent;
                var textElement = sdtElement.Descendants<Text>().FirstOrDefault();

                if (textElement != null)
                {
                    textElement.Text = value;
                }
            }
        }

        private List<string> GetFormFieldNamesFromTemplate(string templatePath)
        {
            List<string> formFieldNames = new List<string>();

            using (WordprocessingDocument document = WordprocessingDocument.Open(templatePath, false))
            {
                foreach (SdtElement element in document.MainDocumentPart.Document.Body.Descendants<SdtElement>())
                {
                    if (element.Descendants<Tag>().FirstOrDefault() is Tag tag)
                    {
                        string fieldName = tag.Val;
                        if (!formFieldNames.Contains(fieldName))
                        {
                            formFieldNames.Add(fieldName);
                        }
                    }
                }
            }

            return formFieldNames;
        }

        private void SaveDataToXml(string xmlFileName, DocumentData data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DocumentData));
            using (TextWriter writer = new StreamWriter(xmlFileName))
            {
                serializer.Serialize(writer, data);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            documentData = new DocumentData();
            cmbDocuments.DataSource = documentData.Documents;
            cmbDocuments.DisplayMember = "Name";
        }
    }

    public class DocumentData
    {
        public List<Document> Documents { get; set; }

        public DocumentData()
        {
            Documents = new List<Document>();
        }
    }

    public class Document
    {
        public string Name { get; set; }
        public string TemplatePath { get; set; }

        public Document()
        {
        }

        public Document(string name, string templatePath)
        {
            Name = name;
            TemplatePath = templatePath;
        }
    }
}


