using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercenary
{
    public class BSDB
    {
        public string ZipPath { get; private set; }
        private static int EncryptedMagic = 75844490;
        private static int DecryptedMagic = 67324752;
        private byte[] Keys = { 0xDA, 0x86, 0xC1, 0x41 };
        public string zipPassword = "b7ed87e4fdf11b257ebfca36880531a0";

        public BSDB()
        {

        }
        public BSDB(string zipPath)
        {
            ZipPath = zipPath;
        }

        public BSDBStatus CheckStatus(string fileName = "")
        {
            string path = fileName == "" ? ZipPath : fileName;
            using (var br = new BinaryReader(new MemoryStream(File.ReadAllBytes(path))))
            {
                var magic = br.ReadInt32();

                if (magic == EncryptedMagic)
                    return BSDBStatus.Encrypted;

                else if (magic == DecryptedMagic)
                    return BSDBStatus.Decrypted;
            }

            return BSDBStatus.Corrupt;
        }
        public bool Open(string fileName)
        {
            ZipPath = fileName;
            if (CheckStatus(fileName) != BSDBStatus.Encrypted)
                return false;

            EncryptDecrypt(File.ReadAllBytes(fileName), "tmp.bsdb");
            return true;
        }

        public void EncryptDecrypt(byte[] buffer, string path = "")
        {
            int i = 0;
            int j = 0;

            if (buffer.Length > 0)
            {
                do
                {
                    buffer[i] ^= Keys[j++];
                    if (j >= 4)
                        j = 0;
                    i += 2;
                } while (i < buffer.Length);
            }

            if (!string.IsNullOrEmpty(path))
                File.WriteAllBytes(path, buffer);
        }
    }
}
