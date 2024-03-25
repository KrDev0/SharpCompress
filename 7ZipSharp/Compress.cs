using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SevenZip;

namespace _7ZipSharp
{
    internal class Compress
    {
        public ZipEncryptionMethod getEncriptMethod(CompressF frm)
        {
            switch (frm.cmbEncrip.SelectedIndex)
            {
                case 0:
                    return ZipEncryptionMethod.ZipCrypto;
                case 1:
                    return ZipEncryptionMethod.Aes128;
                case 2:
                    return ZipEncryptionMethod.Aes192;
                case 3:
                    return ZipEncryptionMethod.Aes256;
                default:
                    return ZipEncryptionMethod.ZipCrypto;
            }
        }
    
        public void getMethod(CompressF frm)
        {
            switch (frm.cmbFormato.SelectedIndex)
            {
                case 0:
                    frm.cmbMetodo.Items.Clear();
                    frm.cmbMetodo.Items.Add("BZip2");
                    frm.cmbMetodo.Items.Add("PPMd");
                    frm.cmbMetodo.Items.Add("LZMA");
                    frm.cmbMetodo.Items.Add("LZMA2 (Por defecto)");
                    frm.cmbMetodo.SelectedIndex = 3;
                    return;
                case 1:
                    frm.cmbMetodo.Items.Clear();
                    frm.cmbMetodo.Items.Add("Default (Por defecto)");
                    frm.cmbMetodo.SelectedIndex = 0;
                    return;
                case 2:
                    frm.cmbMetodo.Items.Clear();
                    frm.cmbMetodo.Items.Add("Deflate (Por defecto)");
                    frm.cmbMetodo.Items.Add("Deflate64");
                    frm.cmbMetodo.Items.Add("BZip2");
                    frm.cmbMetodo.Items.Add("LZMA");
                    frm.cmbMetodo.Items.Add("PPMd");
                    frm.cmbMetodo.SelectedIndex = 0;
                    return;
            }
        }

        public CompressionMethod GetCompressMethod(CompressF frm)
        {
            switch (frm.cmbMetodo.SelectedIndex)
            {
                case 0:
                    return CompressionMethod.BZip2;
                case 1:
                    return CompressionMethod.Copy;
                case 2:
                    return CompressionMethod.Default;
                case 3:
                    return CompressionMethod.Deflate;
                case 4:
                    return CompressionMethod.Deflate64;
                case 5:
                    return CompressionMethod.Lzma;
                case 6:
                    return CompressionMethod.Ppmd;
                default:
                    return CompressionMethod.Default;
            }
        }
        public OutArchiveFormat GetSelectedArchiveFormat(CompressF frm)
        {
            switch (frm.cmbFormato.SelectedIndex)
            {
                case 0:
                    return OutArchiveFormat.SevenZip;
                case 1:
                    return OutArchiveFormat.Tar;
                case 2:
                    return OutArchiveFormat.Zip;
                default:
                    return OutArchiveFormat.Zip;
            }
        }
        public string getFileType(CompressF frm)
        {
            switch (frm.cmbFormato.SelectedIndex)
            {
                case 0:
                    return "7z";
                case 1:
                    return "tar";
                case 2:
                    return "zip";
                default:
                    return "zip";
            }
        }

        public CompressionLevel GetSelectedCompressionLevel(CompressF frm)
        {
            switch (frm.cmbNivel.SelectedIndex)
            {
                case 0:
                    return CompressionLevel.Fast;
                case 1:
                    return CompressionLevel.High;
                case 2:
                    return CompressionLevel.Low;
                case 3:
                    return CompressionLevel.None;
                case 4:
                    return CompressionLevel.Normal;
                case 5:
                    return CompressionLevel.Ultra;
                default:
                    return CompressionLevel.Normal;
            }
        }

        public void GetForTar(CompressF frm)
        {
            switch (frm.cmbFormato.SelectedIndex)
            {
                case 1:
                    frm.cmbNivel.Enabled = false;
                    frm.cmbNivel.SelectedIndex = 0;
                    return;
                default:
                    frm.cmbNivel.Enabled = true;
                    frm.cmbNivel.SelectedIndex = 4;
                    return;
            }
        }
    }
}
