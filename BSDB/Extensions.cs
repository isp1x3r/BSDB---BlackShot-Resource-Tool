using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercenary
{
    public static class Extensions
    {
        public static string[] NifFiles =
        {
            "Ad_body1.nif",
            "ca_body1.nif",
            "ke_body1.nif",
            "BLACKSHOT_FC_KIT_Body.nif",
            "BlackShot_Tee_Shirt_Body.nif",
            "BUNNY_SUIT_Body.nif",
            "Crimson_body.nif",
            "DELTA_FORCE_body.nif",
            "Dragon_body_gold.nif",
            "Dragon_body_silver.nif",
            "GINGERBREAD_SUIT_Body.nif",
            "Green_Squid_Tracksuit.nif",
            "GROM_Body.nif",
            "HAWAIIAN_SUIT_Body.nif",
            "LEOPARD_SWIMWEAR_body.nif",
            "MERMAID_SWIMWEAR_Body.nif",
            "MISTER_TANKTOP_Body.nif",
            "Monster_GM_Body.nif",
            "MOUSE_SUIT_Body.nif",
            "Neo_Tactical_Rig_Body.nif",
            "Orchid_Body.nif",
            "PARAMOUR_SUIT_body.nif",
            "Pink_Squid_Tracksuit.nif",
            "RED_BUNNY_SUIT_Body.nif",
            "Resort_Swimwear_Body.nif",
            "Rudolph_Body.nif",
            "SANTA_Body.nif",
            "SANTA_GM_Body.nif",
            "TIGER_SUIT_Body.nif",
            "UDT_WETSUIT_Body.nif",
            "Vamp_body.nif",
            "Vietnam_US_Body.nif",
            "Vietnam_VT_Body.nif",
            "WINTER_FOREST_SUIT_Body.nif",
            "Xmas_Suit_Body.nif",
            "CHINESE_SPY_body1.nif",
            "COWGIRL_body1.nif",
            "DAMI_body1.nif",
            "DAMI_AIRFORCE_body1.nif",
            "ELLIE_body1.nif",
            "IRENE_body1.nif",
            "ISABELLE_body1.nif",
            "JIMMY_body1.nif",
            "KANA_body1.nif",
            "KANA_ARMY_body1.nif",
            "Paratrooper_body1.nif",
            "MINAH_CHEERLEADER_body1.nif",
            "nina_body1.nif",
            "PMC_body1.nif",
            "RAYNE_body1.nif",
            "YUKI_body1.nif",
            "YUNA_body1.nif",
            "vi_body1.nif"
        };
        public static bool IsValidDataDirectory(string path)
        {
            string[] folders = { "_SG", "Character", "Csv", "Item", "Scene", "Sound" };
            return File.Exists(Path.Combine(path, "bsdb")) && folders.All(folder => Directory.Exists(Path.Combine(path, folder)));
        }
        public static string ComputeFileHash(string filePath)
        {
            using (FileStream stream = File.OpenRead(filePath))
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    return BitConverter.ToString(sha256.ComputeHash(stream));
                }
            }
        }

        public static string ReadConfValue(string filePath, string section, string key)
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lines == null)
                return "";
            bool isInSection = false;

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    isInSection = trimmedLine.Equals(section, StringComparison.OrdinalIgnoreCase);
                }
                else if (isInSection && trimmedLine.StartsWith(key + "=", StringComparison.OrdinalIgnoreCase))
                {
                    return trimmedLine.Substring(key.Length + 1);
                }
            }

            return "";
        }

        public static void WriteConfValue(string filePath, string section, string key, string newValue)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{section}");
                writer.WriteLine($"{key}={newValue}");
            }
        }
        public static void SerializeToCsv<T>(IEnumerable<T> records, string savePath)
        {
            using (var writer = new StreamWriter(savePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }
        public static List<T> DeserializeCsv<T>(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<T>().ToList();
            }
        }

        public static bool IsWeapon(ItemInfo item)
        {
            string[] weaponClasses = { "Rifle", "SMG", "Shotgun", "Sniper", "Pistol", "Melee" };

            if (weaponClasses.Any(x => item.ClassName == x))
                return true;
            return false;
        }
    }
}
