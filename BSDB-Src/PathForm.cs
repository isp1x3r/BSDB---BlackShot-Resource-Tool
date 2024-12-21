using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercenary
{
    public partial class PathForm : Form
    {
        private MainForm _mainForm;
        private string _path;
        public PathForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(_path))
            {
                if (Extensions.IsValidDataDirectory(_path))
                {
                    _mainForm.SetDirectory(_path);
                    _mainForm.EnableLoadStrip();
                    _mainForm.SetStatus(StatusLevel.Notify2, "Loaded Data Directory Path.");

                    string cfg = _mainForm.GetConfigFile();
                    if(!File.Exists(cfg))
                        File.Create(cfg);
                    // Save settings
                    Extensions.WriteConfValue(cfg, "[BSDB]", "Path", _path);
                }
                else
                {
                    string message = "Invalid Data Folder";
                    _mainForm.SetStatus(StatusLevel.Error, message);
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Close();
            }         
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                _path = folderDialog.SelectedPath;
                textBox1.Text = _path;
            }
        }

        private void PathForm_Load(object sender, EventArgs e)
        {
            string dir = _mainForm.GetDirectory();
            if (!string.IsNullOrEmpty(dir))
                textBox1.Text = dir;
        }
    }
}
