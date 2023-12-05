using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Object
{
    class doanhthu
    {
        private string IDDoanhThu;
        private string IDNhanVien;
        private DateTime NgayThucHien;
        private float SoTien;
        private string HoatDong;

        public doanhthu(string IDDoanhThu, string IDNhanVien, DateTime NgayThucHien, float SoTien, string HoatDong)
        {
            this.IDDoanhThu = IDDoanhThu;
            this.IDNhanVien = IDNhanVien;
            this.NgayThucHien = NgayThucHien;
            this.SoTien = SoTien;
            this.HoatDong = HoatDong;

        }
        public string IDDoanhThuProperty
        {
            get { return IDDoanhThu; }
            set { IDDoanhThu = value; }
        }

        public string IDNhanVienProperty
        {
            get { return IDNhanVien; }
            set { IDNhanVien = value; }
        }

        public DateTime NgayThucHienProperty
        {
            get { return NgayThucHien; }
            set { NgayThucHien = value; }
        }

        public float SoTienProperty
        {
            get { return SoTien; }
            set { SoTien= value; }
        }
        public string HoatDongProperty
        {
            get { return HoatDong; }
            set { HoatDong = value; }
        }
    }
}
