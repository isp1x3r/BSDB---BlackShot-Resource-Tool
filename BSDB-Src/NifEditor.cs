using MaterialSkin.Controls;
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
    public partial class NifEditor : MaterialForm
    {
        private List<ItemInfo> Items { get; set; }
        private MainForm _mainForm { get; set; }

        private const string _aimPath = "";
        private const string _bodyPath = "";
        private const string _lowbodyPath = "";
        private const string _pathAddition = "../../Zata/Character/";
        public NifEditor(MainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
        }

        private void NifSwitchPath(string path, NifPackEdition edition)
        {
            foreach(var file in Extensions.NifFiles)
            {
                // Find the corresponding item
                var item = Items.FirstOrDefault(x => x.FileName.ToLower().Contains(file.ToLower()));

                if (item != null)
                {
                    // Get the directory part of the path
                    string directoryPath = Path.GetDirectoryName(item.FileName);
                    // Combine the directory path with the new file name
                    string newPath = Path.Combine(directoryPath, file).Replace('\\', '/');
                    // Set item FileName to final path
                    item.FileName = _pathAddition + newPath;
                }
            }

            _mainForm.SaveTotalItem(Items.ToArray());
            MaterialMessageBox.Show("Your Nif has been applied", "Success", false, FlexibleMaterialForm.ButtonsPosition.Center);
            statusLabel.ForeColor = Color.Green;
            statusLabel.Text      = $"{edition} Pack has been applied successfully";
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            NifSwitchPath(_aimPath, NifPackEdition.Aimbot);
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            NifSwitchPath(_bodyPath, NifPackEdition.Bodybot);
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            NifSwitchPath(_lowbodyPath, NifPackEdition.Inconspicuous);
        }

        private void NifEditor_Load(object sender, EventArgs e)
        {
            if (_mainForm.LoadTotalItem())
                    Items = Extensions.DeserializeCsv<ItemInfo>("tmp.totalitem").ToList();           
                else
                {
                    DialogResult result = MaterialMessageBox.Show("Failed to load nif editor", "Error", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    if (result == DialogResult.OK)
                        Close();
                }
        }
    }
}
