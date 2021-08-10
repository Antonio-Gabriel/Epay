using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ePay.Functions
{
    public class ConvertBlob

    {
        public byte[] Blob (PictureBox imageConvert)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageConvert.Image.Save(ms, imageConvert.Image.RawFormat);
                return ms.ToArray();
            }
        }

        public Image unBlob(byte[] imageByArray)
        {
            using (MemoryStream ms = new MemoryStream(imageByArray))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }
    }
}
