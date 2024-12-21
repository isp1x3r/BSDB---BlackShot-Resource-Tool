using Ionic.Zip;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mercenary
{
    public partial class MainForm : Form
    {
        private BSDB _BSDBMgr { get; set; }
        private ZipFile _zipFile { get; set; }
        private const string _bsdbtmp = "tmp.bsdb";
        private const string _totaltmp = "tmp.totalitem";
        private const string _glbtotalitem = "TotalItem_glb.csv";
        private const string _seatotalitem = "TotalItem_sea.csv";
        private string _totalItem { get; set; }
        private string _config = "Config.cfg";
        private string _DataDirectory { get; set; }
        public MainForm()
        {
            InitializeComponent();
            _BSDBMgr = new BSDB();
            //_totalItem = version == GameVersion.GLB ? _totalItem = _glbtotalitem : _seatotalitem;
        }

        public void SetDirectory(string directory)
        {
            _DataDirectory = directory;
        }

        public string GetDirectory()
        {
            return _DataDirectory;
        }

        public string GetConfigFile()
        {
            return _config;
        }
        public void SetStatus(StatusLevel status, string message)
        {
            switch (status)
            {
                case StatusLevel.Notify1:
                    statusLabel.ForeColor = Color.Purple;
                    break;
                case StatusLevel.Notify2:
                    statusLabel.ForeColor = Color.Blue;
                    break;
                case StatusLevel.Error:
                    statusLabel.ForeColor = Color.Red;
                    break;
                default:
                    statusLabel.ForeColor = Color.Green;
                    break;
            }
            statusLabel.Text = message;
        }

        public void EnableLoadStrip()
        {
            loadToolStripMenuItem.Enabled = true;
        }
        private void LoadBSDB(string fileName)
        {
            if (_BSDBMgr.Open(fileName))
            {
                ZipTreeView.Nodes.Clear();
                _zipFile = new ZipFile();
                _zipFile = ZipFile.Read(_bsdbtmp);
                _zipFile.Password = _BSDBMgr.zipPassword;

                var rootNode = new TreeNode("Root");

                foreach (ZipEntry entry in _zipFile)
                {
                    if (!entry.IsDirectory)
                    {
                        AddZipEntryToTree(rootNode, entry.FileName);
                    }
                }

                ZipTreeView.Nodes.Add(rootNode);
                rootNode.Expand();

                SetStatus(StatusLevel.Success, "BSDB Loaded Successfully");
                saveToolStripMenuItem.Enabled = true;
                weaponEditorToolStripMenuItem.Enabled = true;
                nifEditorToolStripMenuItem.Enabled = true;
            }
            else
                SetStatus(StatusLevel.Error, "Cannot load BSDB (file not encrypted or corrupt)");
        }

        public bool LoadTotalItem()
        {
            var entry = _zipFile.Entries.FirstOrDefault(x => x.FileName.Contains(_glbtotalitem));
            if (entry == null)
                return false;

            using (var reader = new StreamReader(entry.OpenReader()))
            {
                string fileContent = reader.ReadToEnd();
                File.WriteAllText(_totaltmp, fileContent);
            }
            return true;
        }

        public void SaveTotalItem(ItemInfo[] items)
        {
            Extensions.SerializeToCsv<ItemInfo>(items, _totaltmp);
            var entry = _zipFile.Entries.FirstOrDefault(x => x.FileName.Contains(_glbtotalitem));

            if (entry != null)
                _zipFile.RemoveEntry(entry);

            _zipFile.AddFile(_totaltmp).FileName = "Data/Csv/" + _glbtotalitem;
            _zipFile.Save();
        }
        private void loadfromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "C:\\Program Files (x86)\\Papaya Play\\BlackShot\\BlackShot\\Data\\",
                FileName = "bsdb",
                Filter = "Zip Archive (*.zip)|*.zip|All files (*.*)|*.*",
                Title = "Open ZIP File",
                FilterIndex = 2,
                RestoreDirectory = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                LoadBSDB(openFileDialog.FileName);
        }

        private void AddZipEntryToTree(TreeNode parentNode, string entryPath)
        {
            var parts = entryPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            TreeNode currentNode = parentNode;

            foreach (var part in parts)
            {
                var foundNode = currentNode.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == part);

                if (foundNode == null)
                {
                    var newNode = new TreeNode
                    {
                        Text = part,
                        Tag = string.Join("/", parts.Take(Array.IndexOf(parts, part) + 1))
                    };
                    currentNode.Nodes.Add(newNode);
                    currentNode = newNode;
                }
                else
                {
                    currentNode = foundNode;
                }
            }
        }

        private void ZipTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = ZipTreeView.GetNodeAt(e.Location);

            if (node != null)
            {
                var fileName = node.Text;
                if (fileName.EndsWith(".lua") || fileName.EndsWith(".csv"))
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        ZipTreeView.SelectedNode = node;

                        contextMenuStrip1.Show(ZipTreeView, e.Location);
                    }
                    else if (e.Button == MouseButtons.Left)
                    {
                        var entry = _zipFile.Entries.FirstOrDefault(x => x.FileName.Contains(node.Text));

                        // Manually bind the entry informations
                        fName.Text = node.Text;
                        fPath.Text = entry.FileName;
                        fSize.Text = entry.CompressedSize.ToString();
                        fUnCompressedSize.Text = entry.UncompressedSize.ToString();
                        fCompressionType.Text = entry.CompressionMethod.ToString();
                        fLastWrite.Text = entry.LastModified.ToString();
                        fAttributes.Text = entry.Attributes.ToString();
                    }
                }
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = ZipTreeView.SelectedNode;
            if (node != null)
            {
                var fileName = node.Text;
                var ext = fileName.Substring(fileName.Length - 4);

                if (ext == ".csv" || ext == ".lua")
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        FileName = fileName,
                        Filter = ext == ".csv" ?
                                        "Comma Separated Value (*.csv)|*.csv|All files (*.*)|*.*"
                                      : "Lua Script (*.lua)|*.lua|All files (*.*)|*.*",
                        Title = ext == ".csv" ?
                                        "Replace CSV File"
                                      : "Replace Lua File",
                    };

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var fullEntryName = _zipFile.Entries.FirstOrDefault(x => x.FileName.Contains(fileName)).FileName;
                        _zipFile.UpdateEntry(fullEntryName, File.ReadAllBytes(openFileDialog.FileName));
                        _zipFile.Save();
                        SetStatus(StatusLevel.Notify2, $"Replaced : {fullEntryName}");
                    }
                }
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = ZipTreeView.SelectedNode;

            if(node != null)
            {
                var fullEntryName = _zipFile.Entries.FirstOrDefault(x => x.FileName.Contains(node.Text)).FileName;
                _zipFile.RemoveEntry(fullEntryName);
                _zipFile.Save();
                SetStatus(StatusLevel.Notify1, $"Deleted : {fullEntryName}");
                ZipTreeView.Nodes.Remove(node);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Make sure the file is still in tact as an archive
            if (_BSDBMgr.CheckStatus(_bsdbtmp) == BSDBStatus.Corrupt)
            {
                SetStatus(StatusLevel.Error, "Temporary BSDB File is corrupt. Please close and retry");
                return;
            }

            // Save
            _zipFile.Save();
            // Encrypt
            _BSDBMgr.EncryptDecrypt(File.ReadAllBytes(_bsdbtmp), _bsdbtmp);
            File.Delete(_BSDBMgr.ZipPath);
            File.Copy(_bsdbtmp, _BSDBMgr.ZipPath);
            SetStatus(StatusLevel.Success, "Saved BSDB");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete(_bsdbtmp);
            File.Delete(_totaltmp);
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_zipFile != null)
            {
                // Encrypt our temporary file first(if not already encrypted)
                if(_BSDBMgr.CheckStatus(_bsdbtmp) == BSDBStatus.Decrypted)
                    _BSDBMgr.EncryptDecrypt(File.ReadAllBytes(_bsdbtmp), _bsdbtmp);

                var srcChecksum = Extensions.ComputeFileHash(_bsdbtmp);
                var destChecksum = Extensions.ComputeFileHash(_BSDBMgr.ZipPath);

                if (srcChecksum != destChecksum)
                {
                    DialogResult result = MessageBox.Show("Some changes are left unsaved\nWould you like to save?", "BSDB V3", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        _zipFile.Save();
                        File.WriteAllBytes(_BSDBMgr.ZipPath, File.ReadAllBytes(_bsdbtmp));
                    }
                }
                _zipFile.Dispose();
            }
            File.Delete(_bsdbtmp);
            File.Delete(_totaltmp);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(_DataDirectory))
            {
                if (_zipFile != null)
                    SetStatus(StatusLevel.Error, "Another BSDB instance is already opened.");
                else
                    LoadBSDB(Path.Combine(_DataDirectory,"bsdb"));
            }
        }

        private void pathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PathForm pathForm = new PathForm(this);
            pathForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(File.Exists(_config))
            {
                string path = Extensions.ReadConfValue(_config, "[BSDB]", "Path");

                if (!string.IsNullOrEmpty(path))
                {
                    if (Extensions.IsValidDataDirectory(path))
                    {
                        _DataDirectory = path;
                        EnableLoadStrip();
                        SetStatus(StatusLevel.Notify1, "Loaded Data directory path from config");
                    }
                    else
                        SetStatus(StatusLevel.Error, "Config provided path is malformed or incorrect");
                }
            }
        }

        private void weaponEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_zipFile != null)
            {
                ItemSearchForm itemsearchForm = new ItemSearchForm(this);
                itemsearchForm.Show();
            }  
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void encryptBSDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Zip Archive (*.zip)|*.zip|All files (*.*)|*.*",
                Title = "Open ZIP File",
                FilterIndex = 2,
                RestoreDirectory = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                var status = _BSDBMgr.CheckStatus(path);
                if (status == BSDBStatus.Encrypted)
                    SetStatus(StatusLevel.Notify1, "This file is already encrypted");
                else if (status == BSDBStatus.Corrupt)
                    SetStatus(StatusLevel.Error, "This file is corrupted");
                else
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        FileName = "bsdb"
                    };

                    if(saveFileDialog.ShowDialog() == DialogResult.OK)
                        _BSDBMgr.EncryptDecrypt(File.ReadAllBytes(path), saveFileDialog.FileName);
                }    
            }
        }

        private void decryptBSDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "C:\\Program Files (x86)\\Papaya Play\\BlackShot\\BlackShot\\Data\\",
                FileName = "bsdb",
                Filter = "BSDB File (*)|*|All files (*.*)|*.*",
                Title = "Open BSDB File",
                FilterIndex = 2,
                RestoreDirectory = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                var status = _BSDBMgr.CheckStatus(path);
                if (status == BSDBStatus.Decrypted)
                    SetStatus(StatusLevel.Notify1, "This file is already decrypted");
                else if (status == BSDBStatus.Corrupt)
                    SetStatus(StatusLevel.Error, "This file is corrupted");
                else
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        FileName = "bsdb.zip"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        _BSDBMgr.EncryptDecrypt(File.ReadAllBytes(path), saveFileDialog.FileName);
                }
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void fAQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAQForm fAQForm = new FAQForm();
            fAQForm.Show();
        }

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = ZipTreeView.SelectedNode;
            if (node != null)
            {
                var fileName = node.Text;
                var ext = fileName.Substring(fileName.Length - 4);

                if (ext == ".csv" || ext == ".lua")
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        FileName = fileName,
                        Filter = ext == ".csv" ?
                                        "Comma Separated Value (*.csv)|*.csv|All files (*.*)|*.*"
                                      : "Lua Script (*.lua)|*.lua|All files (*.*)|*.*",
                        Title = ext == ".csv" ?
                                        "Save CSV File"
                                      : "Save Lua File",
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var entry = _zipFile.Entries.FirstOrDefault(x => x.FileName.Contains(fileName));
                        entry.Extract(saveFileDialog.FileName);
                        _zipFile.Save();
                        SetStatus(StatusLevel.Notify2, $"Saved On disk : {fileName}");
                    }
                }
            }
        }

        private void nifEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NifEditor Nifeditor = new NifEditor(this);
            Nifeditor.Show();
        }
    }
}
