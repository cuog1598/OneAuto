using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_OneAuto
{
    public class SanPham
    {

        public SanPham(String masp, string tensp, double giatien,string tenloai)
        {
            this.masp = masp;
            this.tensp = tensp;
            this.giatien = giatien;
            this.tenloai = tenloai;
        }
        //mặc đinh
        public SanPham()
        {

        }

        public SanPham(SanPham x)
        {
            this.masp = x.masp;
            this.tensp = x.tensp;
            this.giatien = x.giatien;
            this.tenloai = x.tenloai;
        }
        private string masp;
        private string tensp;
        private double giatien;
        private string tenloai;

        public string Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public double Giatien { get => giatien; set => giatien = value; }
        public string Tenloai { get => tenloai; set => tenloai = value; }
    }
}
