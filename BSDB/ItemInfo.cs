using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercenary
{
    public class ItemInfo
    {
        public string TypeName { get; set; }
        public byte Type { get; set; }
        public ushort No { get; set; }
        public string ClassName { get; set; }
        public byte Class { get; set; }
        public string PartName { get; set; }
        public byte Part { get; set; }
        public string Name { get; set; }
        public byte Default { get; set; }
        public byte Sale { get; set; }
        public byte LvlLimit { get; set; }
        public uint Price_1D { get; set; }
        public uint Price_3D { get; set; }
        public uint Price_7D { get; set; }
        public uint Price_30D { get; set; }
        public uint Price_90D { get; set; }
        public uint Price_120D { get; set; }
        public uint Price_Unlimited { get; set; }
        public string FileName { get; set; }
        public string Char_Icon { get; set; }
        public string Parts_Material { get; set; }
        public string Remark { get; set; }
        public short Ability1 { get; set; }
        public short Value1 { get; set; }
        public short Ability2 { get; set; }
        public short Value2 { get; set; }
        public short Ability3 { get; set; }
        public short Value3 { get; set; }
        public short Ability4 { get; set; }
        public short Value4 { get; set; }
        public short Ability5 { get; set; }
        public short Value5 { get; set; }
        public short Group_No { get; set; }
        public byte ItemAbility { get; set; }
        public byte New { get; set; }
        public uint ItemCode { get; set; }
        public byte ExpireType { get; set; }
        public string PlusBP { get; set; }
    }
}
