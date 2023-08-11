using System;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.Text;
using Microsoft.Office.Interop.Word;
using iTextSharp.text.pdf.parser;
using Document = Microsoft.Office.Interop.Word.Document;
using Path = System.IO.Path;
using System.Runtime.InteropServices;

namespace FileProcessingApp
{
    public partial class frmMain : Form
    {
        //const string DLL_PATH = "CipherLibrary.dll";
        //[DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        //public static extern void getEncryptedResult(string inputFilePath, string outputFilePath, int key);

        //[DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        //public static extern void getDecryptedResult(string inputFilePath, string outputFilePath, int key);

        public string inputFilePath;
        public string outputFilePath;
        public string showInputFilePath;
        public string dllLibrary;
        public string inputFileExtension;
        public string outputFileExtension;
        public string showFileExtension;
        public string button_text;
        public string result_file;
        public string file_name;
        public string library;
        public string file;
        public int userKey;
        public string text;

        public frmMain()
        {
            InitializeComponent();
            button_text = btnEncDec.Text;
        }

        static void getEncryptedResult(string inputFilePath, string outputFilePath, int key)
        {
            try
            {
                string content = File.ReadAllText(inputFilePath);
                string encryptedContent = encryptFile(content, key);
                File.WriteAllText(outputFilePath, encryptedContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        static string encryptFile(string input, int key)
        {

            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                c = (char)((c + key - 100929));
                chars[i] = c;
            }
            return new string(chars);
        }

        static void getDecryptedResult(string inputFilePath, string outputFilePath, int key)
        {
            try
            {
                string content = File.ReadAllText(inputFilePath);
                string encryptedContent = decryptFile(content, key);
                File.WriteAllText(outputFilePath, encryptedContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        static string decryptFile(string input, int key)
        {

            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                c = (char)((c - key + 100929));
                chars[i] = c;
            }
            return new string(chars);
        }

        public void UpdateRichTextBox(string textIn)
        {
            if (rtbShow.InvokeRequired)
            {
                rtbShow.Invoke(new Action<string>(UpdateRichTextBox), textIn);
            }
            else
            {
                rtbShow.AppendText(textIn);
            }
        }

        public void openPdfFile(string file_path){
            using (PdfReader reader = new PdfReader(file_path))
            {
                StringBuilder text = new StringBuilder();
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, page));
                }

                UpdateRichTextBox(text.ToString());
            }
        }

        public void openTextFile(string file_path) {
            string fileContents = File.ReadAllText(file_path);
            UpdateRichTextBox(fileContents);
        }

        public void openWordFile(string file_path) {
            var application = new Microsoft.Office.Interop.Word.Application();
            var document = application.Documents.Open(file_path);
            foreach (Table table in document.Tables)
            {
                foreach (Row row in table.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        string cellText = cell.Range.Text;
                        UpdateRichTextBox(cellText + "\t"); 
                    }
                    UpdateRichTextBox("\n"); 
                }
                UpdateRichTextBox("\n\n"); 
            }
            document.Close();
            application.Quit();
        }

        public void openEncryptedFile(string file_path) {
            try
            {
                string encryptedContent = File.ReadAllText(file_path);
                rtbShow.Text = encryptedContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing contents: " + ex.Message);
            }
        }
        private void ExportToWord(string filePath)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Document doc = wordApp.Documents.Add();
            Range range = doc.Content;
            string richTextBoxText = rtbShow.Text;
            range.Text = richTextBoxText;
            doc.SaveAs2(filePath);
            doc.Close();
            wordApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
        }

        private void btnLibrary_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dllLibrary = openFileDialog.FileName;
                    tbLibrary.Text = dllLibrary;
                }
            }
        }
        private void btnFile_Click(object sender, EventArgs e)
        {
            tbLibrary.Clear();
            tbFile.Clear();
            tbKey.Clear();
            rtbShow.Clear();
            btnEncDec.Text = "Encrypt/Decrypt";
            using (var openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    inputFilePath = openFileDialog.FileName;
                    tbFile.Text = inputFilePath;
                    inputFileExtension = Path.GetExtension(inputFilePath);
                    file_name = Path.GetFileName(inputFilePath);

                    if (inputFileExtension == ".enc")
                    {
                        btnEncDec.Text = "Decrypt";
                    }
                    else
                    {
                        btnEncDec.Text = "Encrypt";
                    }
                }
            }

            switch (inputFileExtension)
            {
                case ".pdf":
                    openPdfFile(inputFilePath);
                    break;
                case ".txt":
                    openTextFile(inputFilePath);
                    break;
                case ".docx":
                    openWordFile(inputFilePath);
                    break;
                case ".doc":
                    openWordFile(inputFilePath);
                    break;
                case ".enc":
                    openEncryptedFile(inputFilePath);
                    break;
                default:
                    MessageBox.Show("File type not matched!");
                    break;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Document|*.docx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToWord(saveFileDialog.FileName);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void optFile_CheckedChanged(object sender, EventArgs e)
        {
            if (optFile.Checked == true)
            {
                btnEncDec.Text = "Encrypt/Decrypt";
                lblText.Visible = false;
                tbText.Visible = false;
                cbOptions.Visible = false;
                lblFile.Visible = true;
                tbFile.Visible = true;
                btnFile.Visible = true;
                lblOutputFile.Visible = true;
                tbOutputFile.Visible = true;
                btnSaveOutput.Visible = true;
            }
        }

        private void optText_CheckedChanged(object sender, EventArgs e)
        {
            if (optText.Checked == true)
            {
                lblFile.Visible = false;
                tbFile.Visible = false;
                btnFile.Visible = false;
                lblOutputFile.Visible = false;
                tbOutputFile.Visible = false;
                btnSaveOutput.Visible = false;
                lblText.Visible = true;
                tbText.Visible = true;
                cbOptions.Visible = true;
            }
        }
        private void btnSaveOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Files (*.enc) | *.enc | All Files (*.*) | *.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbOutputFile.Text = saveFileDialog.FileName;
                outputFilePath = tbOutputFile.Text;
                outputFileExtension = Path.GetExtension(outputFilePath);
            }
        }


        private void btnEncDec_Click(object sender, EventArgs e)
        {
            userKey = Convert.ToInt32(tbKey.Text);

            file = tbFile.Text;
            text = tbText.Text;
            //library = tbLibrary.Text;
            //if (string.IsNullOrEmpty(library))
            //{
            //    MessageBox.Show("Select library first!");
            //}
            //else 

            if (string.IsNullOrEmpty(file) && string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Select file or enter text first!");
            }
            else if (userKey.Equals(null))
            {
                MessageBox.Show("Please enter key!");
            }
            else
            {
                if (string.IsNullOrEmpty(text))
                {
                    if (btnEncDec.Text == "Encrypt")
                    {
                        getEncryptedResult(inputFilePath, outputFilePath, userKey);
                        MessageBox.Show("File encrypted and saved successfully!");
                    }
                    if (btnEncDec.Text == "Decrypt")
                    {
                        getDecryptedResult(inputFilePath, outputFilePath, userKey);
                        MessageBox.Show("File decrypted and saved successfully!");
                    }
                }
                else
                {
                    if (btnEncDec.Text == "Encrypt")
                    {
                        string contents = encryptFile(text, userKey);
                        rtbShow.Text = contents;
                        tbText.Clear();
                        tbKey.Clear();
                        MessageBox.Show("Contents encrypted successfully!");
                    }
                    if (btnEncDec.Text == "Decrypt")
                    {
                        string contents = decryptFile(text, userKey);
                        rtbShow.Text = contents;
                        tbText.Clear();
                        tbKey.Clear();
                        MessageBox.Show("Contents decrypted successfully!");
                    }
                }  
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbLibrary.Clear();
            tbFile.Clear();
            tbText.Clear();
            tbKey.Clear();
            btnEncDec.Text = "Encrypt/Decrypt";
            rtbShow.Clear();
            tbOutputFile.Clear();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            openEncryptedFile(outputFilePath);
        }

        private void cbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOptions.SelectedIndex == 0) {
                btnEncDec.Text = cbOptions.SelectedItem.ToString();
            }
            if (cbOptions.SelectedIndex == 1)
            {
                btnEncDec.Text = cbOptions.SelectedItem.ToString();
            }

        }
    }
}
