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
        private IntPtr loadedLibraryHandle = IntPtr.Zero;

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeLibrary(IntPtr hModule);

        // Define the delegate for the getEncryptedResult function
        private delegate void GetEncryptedResultDelegate(string inputFilePath, string outputFilePath, int key);
        private delegate void GetDecryptedResultDelegate(string inputFilePath, string outputFilePath, int key);

        private delegate string GetEncryptedTextDelegate(string text, int key);
        private delegate string GetDecryptedTextDelegate(string text, int key);

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
        public int user_key;
        public string user_text;
        string text_result;
        public static int cipher_key = 835294858;

        public frmMain()
        {
            InitializeComponent();
            button_text = btnEncDec.Text;
        }

        //private string CallGetEncryptedText(string text, int key)
        //{
        //    if (loadedLibraryHandle != IntPtr.Zero)
        //    {
        //        // Get a delegate to the function from the loaded library
        //        var getEncryptedTextDelegate = GetFunctionDelegate<GetEncryptedTextDelegate>("encryptFile");

        //        if (getEncryptedTextDelegate != null)
        //        {
        //            // Call the function using the delegate
        //            text_result = getEncryptedTextDelegate(text, key);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Failed to get function delegate.", "Function Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("DLL is not loaded.", "DLL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return text_result;
        //}

        //private string CallGetDecryptedText(string text, int key)
        //{
        //    if (loadedLibraryHandle != IntPtr.Zero)
        //    {
        //        // Get a delegate to the function from the loaded library
        //        var getDecryptedTextDelegate = GetFunctionDelegate<GetDecryptedTextDelegate>("decryptFile");

        //        if (getDecryptedTextDelegate != null)
        //        {
        //            // Call the function using the delegate
        //            text_result = getDecryptedTextDelegate(text, key);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Failed to get function delegate.", "Function Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("DLL is not loaded.", "DLL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return text_result;
        //}

        private void CallGetEncryptedResult(string inputFilePath, string outputFilePath, int key)
        {
            if (loadedLibraryHandle != IntPtr.Zero)
            {
                // Get a delegate to the function from the loaded library
                var getEncryptedResultDelegate = GetFunctionDelegate<GetEncryptedResultDelegate>("getEncryptedResult");

                if (getEncryptedResultDelegate != null)
                {
                    // Call the function using the delegate
                    getEncryptedResultDelegate(inputFilePath, outputFilePath, key);
                }
                else
                {
                    MessageBox.Show("Failed to get function delegate.", "Function Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("DLL is not loaded.", "DLL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CallGetDecryptedResult(string inputFilePath, string outputFilePath, int key)
        {
            if (loadedLibraryHandle != IntPtr.Zero)
            {
                // Get a delegate to the function from the loaded library
                var getDecryptedResultDelegate = GetFunctionDelegate<GetDecryptedResultDelegate>("getDecryptedResult");

                if (getDecryptedResultDelegate != null)
                {
                    // Call the function using the delegate
                    getDecryptedResultDelegate(inputFilePath, outputFilePath, key);
                }
                else
                {
                    MessageBox.Show("Failed to get function delegate.", "Function Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("DLL is not loaded.", "DLL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function to get a delegate to a function from the loaded library
        private TDelegateType GetFunctionDelegate<TDelegateType>(string functionName)
            where TDelegateType : Delegate
        {
            if (loadedLibraryHandle != IntPtr.Zero)
            {
                IntPtr functionPointer = GetProcAddress(loadedLibraryHandle, functionName);
                if (functionPointer != IntPtr.Zero)
                {
                    return Marshal.GetDelegateForFunctionPointer<TDelegateType>(functionPointer);
                }
            }
            return null;
        }

        static string encryptFile(string input, int key)
        {

            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                c = (char)((c + key + cipher_key));
                chars[i] = c;
            }
            return new string(chars);
        }

        static string decryptFile(string input, int key)
        {

            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                c = (char)((c - key - cipher_key));
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
                openFileDialog.Filter = "Libraries|*.dll";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string dllPath = openFileDialog.FileName;
                    loadedLibraryHandle = LoadLibrary(dllPath);

                    if (loadedLibraryHandle != IntPtr.Zero)
                    {
                        tbLibrary.Text = dllPath;
                    }
                    else
                    {
                        MessageBox.Show("Failed to load the DLL.", "DLL Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            tbLibrary.Clear();
            tbFile.Clear();
            tbKey.Clear();
            rtbShow.Clear();
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
                        btnEncDec.Visible = true;
                        btnEncDec.Text = "Decrypt";
                    }
                    else
                    {
                        btnEncDec.Visible = true;
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
            chBoxShow.Checked = true;
        }

        private void optFile_CheckedChanged(object sender, EventArgs e)
        {
            if (optFile.Checked == true)
            {
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
            user_key = Convert.ToInt32(tbKey.Text);

            file = tbFile.Text;
            user_text = tbText.Text;
            library = tbLibrary.Text;
            if (string.IsNullOrEmpty(library))
            {
                MessageBox.Show("Select library first!");
            }
            else if (string.IsNullOrEmpty(file) && string.IsNullOrEmpty(user_text))
            {
                MessageBox.Show("Select file or enter text first!");
            }
            else if (user_key.Equals(null))
            {
                MessageBox.Show("Please enter key!");
            }
            else
            {
                if (string.IsNullOrEmpty(user_text))
                {
                    if (btnEncDec.Text == "Encrypt")
                    {
                        CallGetEncryptedResult(inputFilePath, outputFilePath, user_key);
                        MessageBox.Show("File encrypted and saved successfully!");
                    }
                    if (btnEncDec.Text == "Decrypt")
                    {
                        CallGetDecryptedResult(inputFilePath, outputFilePath, user_key);
                        MessageBox.Show("File decrypted and saved successfully!");
                    }
                }
                else
                {
                    if (btnEncDec.Text == "Encrypt")
                    {
                        //string contents = CallGetEncryptedText(user_text, userKey);
                        string contents = encryptFile(user_text, user_key);
                        rtbShow.Text = contents;
                        tbText.Clear();
                        tbKey.Clear();
                        MessageBox.Show("Contents encrypted successfully!");
                    }
                    if (btnEncDec.Text == "Decrypt")
                    {
                        //string contents = CallGetDecryptedText(user_text, userKey);
                        string contents = decryptFile(user_text, user_key);
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
            btnEncDec.Visible = false;
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
                btnEncDec.Visible = true;
                btnEncDec.Text = cbOptions.SelectedItem.ToString();
            }
            if (cbOptions.SelectedIndex == 1)
            {
                btnEncDec.Visible = true;
                btnEncDec.Text = cbOptions.SelectedItem.ToString();
            }

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (loadedLibraryHandle != IntPtr.Zero)
            {
                FreeLibrary(loadedLibraryHandle);
            }
        }

        private void chBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility based on CheckBox state
            tbKey.UseSystemPasswordChar = !chBoxShow.Checked;
        }
    }
}
