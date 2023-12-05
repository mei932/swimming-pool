using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Object
{
    class nhanvien
    {
        private string IDNhanVien;
        private string name;
        private string NgaySinh;
        private string Chucvu;
        private string DiaChi;
        private string SDT;
        private string email;

        public nhanvien(string IDNhanVien, string name, string NgaySinh, string Chucvu, string DiaChi, string SDT, string email)
        {
            this.IDNhanVien = IDNhanVien;
            this.name = name;
            this.NgaySinh = NgaySinh;
            this.Chucvu = Chucvu;
            this.DiaChi = DiaChi;
            this.SDT = SDT;
            this.email = email;
        }

        public string IDNhanVienProperty
        {
            get { return IDNhanVien; }
            set { IDNhanVien = value; }
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

        public string ChucvuProperty
        {
            get { return Chucvu; }
            set { Chucvu = value; }
        }

        public string DiaChiProperty
        {
            get { return DiaChi; }
            set { DiaChi = value; }
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
