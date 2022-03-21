namespace BSDB
{
    public partial class Form1 : Form
    {
        private bool _loaded => false;
        private bool _decrypted { get; set; }
        private byte[] _buffer { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private bool EncryptDecrypt(string path)
        {
            byte[] Keys = { 0xDA, 0x86, 0xC1, 0x41 };
            int i = 0;
            int keyoffset = 0;
            if (_buffer.Length > 0)
            {
                try
                {
                    do
                    {
                        _buffer[i] ^= Keys[keyoffset++];
                        if (keyoffset >= 4)
                            keyoffset = 0;
                        i += 2;

                    } while (i < _buffer.Length);
                    File.WriteAllBytes(path, _buffer);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "BSDB Tool", MessageBoxButtons.OK);
                    return false;
                }
                
                if(_decrypted)
                {
                    label4.ForeColor = Color.Red;
                    label4.Text = "Encrypted";
                }else
                {
                    label4.ForeColor = Color.Green;
                    label4.Text = "Decrypted";
                }
            }

            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Program Files (x86)\\Papaya Play\\BlackShot\\Data\\";
                openFileDialog.FileName = "bsdb";
                openFileDialog.Filter = "Zip Archive (*.zip)|*.zip|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    _loaded = true;
                    var filePath = openFileDialog.FileName;
                    long _fsize = new FileInfo(filePath).Length;
                    _buffer = new byte[_fsize];
                    _buffer = File.ReadAllBytes(filePath);
                    // File Status Check
                    if (_buffer[0] == 0x8A)
                    {
                        _decrypted = false;
                        label4.ForeColor = Color.Red;
                        label4.Text = "Encrypted";
                    }
                    else if (_buffer[0] == 0x50)
                    {
                        _decrypted = true;
                        label4.ForeColor = Color.Green;
                        label4.Text = "Decrypted";
                    }
                    else
                    {
                        _loaded = false;
                        label4.ForeColor = Color.DarkRed;
                        label4.Text = "Corrupt";
                    }


                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!_loaded)
                MessageBox.Show("Please make sure you load the file first", "BSDB Tool", MessageBoxButtons.OK);

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                   
                    string output = _decrypted ? folderBrowserDialog.SelectedPath + "\\bsdb"
                  : folderBrowserDialog.SelectedPath + "\\bsdb.zip";
                    

                    if (EncryptDecrypt(output))
                    {
                        string status = _decrypted ? "encrypted" : "decrypted";
                        MessageBox.Show($"Congratulations\nYou have successfully {status} bsdb!", "BSDB Tool");
                    }
                }
            }

        }
    }
}
