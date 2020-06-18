using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_OneAuto.DTO
{
    public class DonHangDTO
    {
        public DonHangDTO( string madh,string tensp,string sdt, string tenkh, DateTime ngaylap, int sl,double gia, double tongtien, string tennv,string diachi)
        {
            this.madh = madh;
            this.tensp = tensp;
            this.sdt = sdt;
            this.tennv = tennv;
            this.tenkh = tenkh;
            this.ngaylap = ngaylap;
            this.sl = sl;
            this.tongtien = tongtien;this.gia=gia;
            this.diachi = diachi;

        }
        //mặc đinh
        public DonHangDTO()
        {

        }

        public DonHangDTO(DonHangDTO x)
        {
            this.madh = x.madh;
            this.tensp = x.tensp;
            this.sdt = x.sdt;
            this.tennv = x.tennv;
            this.tenkh = x.tenkh;
            this.ngaylap = x.ngaylap;
            this.sl = x.sl;
            this.tongtien = x.tongtien;
            this.gia = x.gia;
            this.diachi = x.diachi;
        }
        private string diachi;
        private double gia;
        private string sdt;
        private string tenkh;
        private string madh;
        private string tensp;
        public string manv { get => manv; set => manv = value; }
        private string tennv;
        private DateTime ngaylap;
        private int sl;
        private double tongtien;
        

        public string Madh { get => madh; set => madh = value; }
        public string Tensp { get => tensp; set => tensp = value; }
       
        public string Tennv { get => tennv; set => tennv = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public int Sl { get => sl; set => sl = value; }
        public double Tongtien { get => tongtien; set => tongtien = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public double Gia { get => gia; set => gia = value; }
        public string Diachi { get => diachi; set => diachi = value; }
    }
     
}
