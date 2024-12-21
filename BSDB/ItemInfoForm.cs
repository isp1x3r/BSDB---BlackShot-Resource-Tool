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
using MaterialSkin;
using MaterialSkin.Controls;

namespace Mercenary
{
    public partial class ItemInfoForm : MaterialForm
    {
        private ItemSearchForm _searchForm;
        private ItemInfo _item;
        private string _shopIcons;
        public ItemInfoForm(ItemSearchForm searchForm, ItemInfo item)
        {
            _searchForm = searchForm;
            _item = item;
            _shopIcons = Path.Combine(_searchForm._DataDir, "_SG\\Scene\\Interface\\ShopIcon");
            InitializeComponent();
        }

        private void ItemInfoForm_Load(object sender, EventArgs e)
        {
            // Manually bind item info
            fItemName .Text = _item.Name;
            fItemClass.Text = _item.ClassName;
            fItemPart.Text  = _item.PartName;
            if (_item.Sale == 1)
                fItemSale.Text = "BP Item";
            else if (_item.Sale == 2)
                fItemSale.Text = "Gem Item";
            else
                fItemSale.Text = "Not In Shop";
            fItemFile.Text = _item.FileName;
            fItemDesc.Text = _item.Remark;

            // Item Picture
            var itemPic = Path.Combine(_shopIcons, _item.Char_Icon);
            if(File.Exists(itemPic))
                fItemPicture.Image = Image.FromFile(itemPic);
            else
                fItemPicture.Image = Properties.Resources.notfound;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if(Extensions.IsWeapon(_item))
                _searchForm.SetReplaceSearch(_item);
            else
                MaterialMessageBox.Show("Only weapons are supported\n This is not a weapon", "Error", false, FlexibleMaterialForm.ButtonsPosition.Center);

            Close();
        }
    }
}
