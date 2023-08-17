using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Document = Microsoft.Office.Interop.Word.Document;
using Path = System.IO.Path;
using System.Runtime.InteropServices;
using System.Drawing;

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
        public static int cipher_key = 835294858;

        public frmMain()
        {
            InitializeComponent();
            button_text = btnEncDec.Text;
        }

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
        public void openResultFile(string file_path) {
            try
            {
                string encryptedContent = File.ReadAllText(file_path);
//                rtbShow.Text = encryptedContent;
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
//            string richTextBoxText = rtbShow.Text;
//            range.Text = richTextBoxText;
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
//            rtbShow.Clear();
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
                btnShow.Visible = true;
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
                btnShow.Visible = false;
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
                        string contents = encryptFile(user_text, user_key);
                        if (string.IsNullOrEmpty(contents)) {
                            MessageBox.Show("Contents not encrypted!");
                        }
                        else
                        {
                            this.Size = new Size(630, 657);
//                            rtbShow.Visible = true;
//                            rtbShow.Size = new Size(558, 243);
                            btnClear.Visible = false;
                            btnClearAll.Visible = true;
                            btnExport.Visible = true;
//                            rtbShow.Text = contents;
                            tbText.Clear();
                            tbKey.Clear();
                            MessageBox.Show("Contents encrypted successfully!");
                        }  
                    }
                    if (btnEncDec.Text == "Decrypt")
                    {
                        string contents = decryptFile(user_text, user_key);
                        if (string.IsNullOrEmpty(contents)) {
                            MessageBox.Show("Contents not decrypted!");
                        }
                        else
                        {
                            this.Size = new Size(630, 657);
//                            rtbShow.Visible = true;
//                            rtbShow.Size = new Size(558, 243);
                            btnClear.Visible = false;
                            btnClearAll.Visible = true;
                            btnExport.Visible = true;
//                            rtbShow.Text = contents;
                            tbText.Clear();
                            tbKey.Clear();
                            MessageBox.Show("Contents decrypted successfully!");
                        }  
                    }
                }  
            }
        }
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            tbLibrary.Clear();
            tbFile.Clear();
            tbText.Clear();
            tbKey.Clear();
            btnEncDec.Visible = false;
//            rtbShow.Clear();
            tbOutputFile.Clear();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Size = new Size(630, 657);
//            rtbShow.Visible = true;
//            rtbShow.Size = new Size(558, 243);
            btnClear.Visible = false;
            openResultFile(outputFilePath);
            btnClearAll.Visible = true;
            btnExport.Visible = true;
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
            tbKey.UseSystemPasswordChar = !chBoxShow.Checked;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.Size = new Size(630, 354);
            btnClearAll.Visible = false;
            btnExport.Visible = false;
//            rtbShow.Visible = false;
            tbLibrary.Clear();
            optFile.Checked = false;
            optText.Checked = false;
            tbFile.Clear();
            tbText.Clear();
            tbKey.Clear();
            btnEncDec.Visible = false;
            cbOptions.SelectedItem = null;
            cbOptions.Text = "Select Option";
            lblOutputFile.Visible = false;
            tbOutputFile.Clear();
            tbOutputFile.Visible = false;
            btnSaveOutput.Visible = false;
            lblFile.Visible = false;
            tbFile.Visible = false;
            lblText.Visible = false;
            tbText.Visible = false;
            btnFile.Visible = false;
            cbOptions.Visible = false;
            btnShow.Visible = false;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbLibrary.Clear();
            tbFile.Clear();
            tbText.Clear();
            tbKey.Clear();
            btnEncDec.Visible = false;
//            rtbShow.Clear();
            tbOutputFile.Clear();
        }
    }
}
