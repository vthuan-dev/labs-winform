using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_prjSinhVien
{
    public class clsCanBo
    {
        string mscb;
        string hotencb;
        string mkcb;
        public string MaSo
        {
            get
            {
                return mscb;
            }
            set
            {
                mscb = value;
            }
        }
        public string HoTen
        {
            get
            {
                return hotencb;
            }
            set
            {
                hotencb = value;
            }
        }
        public string MatKhau
        {
            get
            {
                return mkcb;
            }
            set
            {
                mkcb = value;
            }
        }
        public clsCanBo(string mscb, string hoten, string mkcb)
        {
            this.mscb = mscb;
            this.hotencb = hoten;
            this.mkcb = mkcb;
        }
    }
}
