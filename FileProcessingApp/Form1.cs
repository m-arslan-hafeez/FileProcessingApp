using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Document = Microsoft.Office.Interop.Word.Document;
using Path = System.IO.Path;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System.Text;

namespace FileProcessingApp
{
    public partial class frmMain : Form
    {
        private IntPtr loaded_library_handle = IntPtr.Zero;

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeLibrary(IntPtr hModule);

        //[DllImport("kernel32")]
        //private static extern void Sleep(int milliseconds);

        // Define the delegate for the getEncryptedResult function
        private delegate void GetEncryptedResultDelegate(string inputFilePath, string outputFilePath, int key);
        private delegate void GetDecryptedResultDelegate(string inputFilePath, string outputFilePath, int key);

        private delegate IntPtr GetOutputResultDelegate();

        private delegate void SetMessageDelegate(string message);
        private delegate IntPtr GetMessageDelegate();

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
        public string txt;

        TextBox tbInOutputTab = new TextBox();
        TextBox tbInResultTab = new TextBox();

        public frmMain()
        {
            InitializeComponent();
            button_text = btnEncDec.Text;
        }

        private void CallGetEncryptedResult(string inputFilePath, string outputFilePath, int key)
        {
            if (loaded_library_handle != IntPtr.Zero)
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
            if (loaded_library_handle != IntPtr.Zero)
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

        private string CallGetOutputResultDelegate()
        {
            if (loaded_library_handle != IntPtr.Zero)
            {
                var getOutputResultDelegate = GetFunctionDelegate<GetOutputResultDelegate>("getString");
                if (getOutputResultDelegate != null)
                {
                    IntPtr resultPtr = getOutputResultDelegate();
                    string result = Marshal.PtrToStringAnsi(resultPtr);
                    return result;
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

            return null;
        }

        private void SetMessage(string message)
        {
            if (loaded_library_handle != IntPtr.Zero)
            {
                var setMessageDelegate = GetFunctionDelegate<SetMessageDelegate>("setMessage");
                if (setMessageDelegate != null)
                {
                    setMessageDelegate(message);
                }
                else
                {
                    MessageBox.Show("Failed to get function delegate for setMessage.", "Function Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("DLL is not loaded.", "DLL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetMessage()
        {
            if (loaded_library_handle != IntPtr.Zero)
            {
                var getMessageDelegate = GetFunctionDelegate<GetMessageDelegate>("getMessage");
                if (getMessageDelegate != null)
                {
                    IntPtr messagePtr = getMessageDelegate();
                    string message = Marshal.PtrToStringAnsi(messagePtr);
                    return message;
                }
                else
                {
                    MessageBox.Show("Failed to get function delegate for getMessage.", "Function Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("DLL is not loaded.", "DLL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        // Function to get a delegate to a function from the loaded library
        private TDelegateType GetFunctionDelegate<TDelegateType>(string function_name)
             where TDelegateType : Delegate
        {
            if (loaded_library_handle != IntPtr.Zero)
            {
                IntPtr function_pointer = GetProcAddress(loaded_library_handle, function_name);
                if (function_pointer != IntPtr.Zero)
                {
                    return Marshal.GetDelegateForFunctionPointer<TDelegateType>(function_pointer);
                }
            }
            return null;
        }

        public void openPdfFile(string file_path)
        {
            using (PdfReader reader = new PdfReader(file_path))
            {
                StringBuilder text = new StringBuilder();
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, page));
                }
                tbInResultTab.Text = text.ToString();
            }
        }

        public void openTextFile(string file_path)
        {
            string fileContents = File.ReadAllText(file_path);
            tbInResultTab.Text = fileContents;
        }

        public void openWordFile(string file_path)
        {
            var application = new Microsoft.Office.Interop.Word.Application();
            var document = application.Documents.Open(file_path);
            foreach (Table table in document.Tables)
            {
                foreach (Row row in table.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        string cellText = cell.Range.Text;
                        tbInResultTab.Text = cellText;
                        tbInResultTab.Text = "\t";
                        
                    }
                    tbInResultTab.Text = "\n";
                }
                tbInResultTab.Text = "\n\n";
            }
            document.Close();
            application.Quit();
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
                tbInResultTab.Text = encryptedContent;
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
            string resultTab = tbInResultTab.Text;
            range.Text = resultTab;
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
                    loaded_library_handle = LoadLibrary(dllPath);

                    if (loaded_library_handle != IntPtr.Zero)
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
            tbInResultTab.Clear();
            tbInOutputTab.Clear();
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
            tabControlShow.SelectedTab = tpOutputTab;
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
            txt = CallGetOutputResultDelegate();

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
                        tbInOutputTab.Text = txt;
                    }
                    if (btnEncDec.Text == "Decrypt")
                    {
                        CallGetDecryptedResult(inputFilePath, outputFilePath, user_key);
                        MessageBox.Show("File decrypted and saved successfully!");
                        tbInOutputTab.Text = txt;
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
                            btnClear.Visible = false;
                            btnClearAll.Visible = true;
                            btnExport.Visible = true;
                            tbInResultTab.Text = contents;
                            tbText.Clear();
                            tbKey.Clear();
                            tbInOutputTab.Text = txt;
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
                            btnClear.Visible = false;
                            btnClearAll.Visible = true;
                            btnExport.Visible = true;
                            tbInResultTab.Text = contents;
                            tbText.Clear();
                            tbKey.Clear();
                            tbInOutputTab.Text = txt;
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
            tbInResultTab.Clear();
            tbOutputFile.Clear();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

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
            if (loaded_library_handle != IntPtr.Zero)
            {
                FreeLibrary(loaded_library_handle);
            }
        }
        private void chBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            tbKey.UseSystemPasswordChar = !chBoxShow.Checked;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (loaded_library_handle != IntPtr.Zero)
            {
                FreeLibrary(loaded_library_handle);
            }
            this.Refresh();
            btnClearAll.Visible = false;
            btnExport.Visible = false;
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
            tbInOutputTab.Clear();
            tbInResultTab.Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbLibrary.Clear();
            tbFile.Clear();
            tbText.Clear();
            tbKey.Clear();
            btnEncDec.Visible = false;
            tbInOutputTab.Clear();
            tbInResultTab.Clear();
            tbOutputFile.Clear();
        }

        private void tabControlShow_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tpOutputTab)
            {
                tpOutputTab.Controls.Add(tbInOutputTab);
                tbInOutputTab.Visible = true;
                tbInOutputTab.Multiline = true;
                tbInOutputTab.Dock = DockStyle.Fill;
                tbInOutputTab.ScrollBars = ScrollBars.Both;
                tbInOutputTab.Size = new Size(494, 104);
                tbInOutputTab.ReadOnly = true;
            }
            else if (e.TabPage == tpResultTab)
            {
                tpResultTab.Controls.Add(tbInResultTab);
                tbInResultTab.Visible = true;
                tbInResultTab.Multiline = true;
                tbInResultTab.Dock = DockStyle.Fill;
                tbInResultTab.ScrollBars = ScrollBars.Both;
                tbInResultTab.Size = new Size(494, 104);
                tbInResultTab.ReadOnly = true;
            }
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            SetMessage("Hello from C# to C++ DLL!");
            await Task.Delay(100);
            string message = GetMessage();
            tbInOutputTab.Text = message;
        }
    }
}
