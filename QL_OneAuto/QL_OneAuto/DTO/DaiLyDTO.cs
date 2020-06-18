using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_OneAuto
{
    public class DaiLyDTO
    {
        public DaiLyDTO(int id,string manv, string tennv,string diachi,string tenchudaily,string tendaily,string sdt,string madl)
        {
            this.id = id;
            this.manv = manv;
            this.tennv = tennv;
            this.diachi = diachi;
            this.Tenchudaily = tenchudaily;
            this.tendaily = tendaily;
            this.sdt = sdt;
            this.madl = madl;
        }
        //mặc đinh
        public DaiLyDTO()
        {

        }

        public DaiLyDTO(DaiLyDTO x)
        {
            this.id = x.id;
            this.manv = x.manv;
            this.tennv = x.tennv;
            this.diachi = x.diachi;
            this.Tenchudaily = x.tenchudaily;
            this.tendaily = x.tendaily;
            this.sdt = x.sdt;
            this.madl = x.madl;
        }
         
   
        private int id;
        private string manv;
        private string tennv;
        private string diachi;
        private string tenchudaily;
        private string tendaily;
        private string sdt;
        private string madl;


        public int Id { get => id; set => id = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Tennv { get => tennv; set => tennv = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Tenchudaily { get => tenchudaily; set => tenchudaily = value; }
        public string Tendaily { get => tendaily; set => tendaily = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Madl { get => madl; set => madl = value; }
    }
}

