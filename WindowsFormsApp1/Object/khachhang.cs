using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Object
{
    class khachhang
    {
        private string IDKhachHang;
        private string name;
        private string NgaySinh;
        private string GT;
        private string SDT;
        private string email;

        public khachhang(string IDKhachHang, string name, string NgaySinh, string GT, string SDT, string email)
        {
            this.IDKhachHang = IDKhachHang;
            this.name = name;
            this.NgaySinh = NgaySinh;
            this.GT = GT;
            this.SDT = SDT;
            this.email = email;
        }

        public string IDKhachHangProperty
        {
            get { return IDKhachHang; }
            set { IDKhachHang = value; }
        }

        public string NameProperty
        {
            get { return name; }
            set { name = value; }
        }

        public string NgaySinhProperty
        {
            get { return NgaySinh; }
            set { NgaySinh = value; }
        }
        public string GioiTinhProperty
        {
            get { return GT; }
            set { GT = value; }
        }

        public string SDTProperty
        {
            get { return SDT; }
            set { SDT = value; }
        }

        public string EmailProperty
        {
            get { return email; }
            set { email = value; }
        }
    }
}
