using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Mercenary
{
    public partial class ItemSearchForm : MaterialForm
    {
        private MainForm _mainForm;
        public string _DataDir { get; set; }

        private bool _switching { get; set; }

        private bool _savePending { get; set; }
        private List<ItemInfo> Items { get; set; }
        private ItemInfo _itemToReplace { get; set; }

        public ItemSearchForm(MainForm mainForm)
        {
            _mainForm = mainForm;
            _DataDir = _mainForm.GetDirectory();
            InitializeComponent();
        }

        private void SaveChanges()
        {
            _mainForm.SaveTotalItem(Items.ToArray());
            statustxt.Text = "Changes are saved.";
            _savePending = false;
        }
        public void SetReplaceSearch(ItemInfo item)
        {
            _switching = true;
            _itemToReplace = item;
            statustxt.Text = $"Changing weapon : {item.Name}";
        }

        public void ReplaceItems(ItemInfo src, ItemInfo dst)
        {
            _itemToReplace = null;
            if(src.ClassName != dst.ClassName)
            {
                MaterialMessageBox.Show($"{src.Name} and {dst.Name} are not of the same weapon class\nPlease try again", "Error", false, FlexibleMaterialForm.ButtonsPosition.Center);
            }
            else
            {
                var item = Items.FirstOrDefault(x => x.ItemCode == src.ItemCode);

                item.Name = dst.Name;
                item.FileName = dst.FileName;
                item.Char_Icon = dst.Char_Icon;
                item.Remark = dst.Remark;
                item.Parts_Material = dst.Parts_Material;

                _savePending = true;
                statustxt.Text = "ItemChange Success";
            }     
        }
        private void ItemSearchForm_Load(object sender, EventArgs e)
        {
            if(_mainForm.LoadTotalItem())
            {
                Items = Extensions.DeserializeCsv<ItemInfo>("tmp.totalitem").ToList();
                statusLabel.Text = $"{Items.Count}";

                foreach (var item in Items)
                    itemListBox.Items.Add(new MaterialListBoxItem(item.Name));
            }else
            {
                MaterialMessageBox.Show("TotalItem Cannot Be Loaded", "Error", false, FlexibleMaterialForm.ButtonsPosition.Center);
            }
            
        }

        private void itemListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selected = itemListBox.SelectedItem.Text;
            if (!string.IsNullOrEmpty(selected))
            {
                var item = Items.FirstOrDefault(x => x.Name == selected);
                if (item != null)
                {
                    if(_switching && item.Name == selected && _itemToReplace != null)
                        ReplaceItems(_itemToReplace, item);           
                    else
                    {
                        ItemInfoForm infoForm = new ItemInfoForm(this, item);
                        infoForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Not Item with such name has been found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
            string itemFilter = materialTextBox1.Text.ToLower();
            
            var filteredItems = Items
                .Where(x => !string.IsNullOrEmpty(itemFilter) && x.Name.ToLower().Contains(itemFilter))
                .OrderBy(x => x.Name)
                .Select(x => new MaterialListBoxItem(x.Name))
                .ToArray();

            itemListBox.Items.Clear();
            itemListBox.AddItems(filteredItems);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if(_savePending)
            {
                SaveChanges();
                Close();
            }
        }

        private void ItemSearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_savePending)
            {
                DialogResult result = MaterialMessageBox.Show("There are changes that are left unsaved", "Notice", false, FlexibleMaterialForm.ButtonsPosition.Center);
                if(result == DialogResult.OK)
                    SaveChanges();
            }
        }
    }
}
