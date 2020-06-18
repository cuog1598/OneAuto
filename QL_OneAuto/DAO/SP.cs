using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_OneAuto.DTO;

namespace QL_OneAuto.DAO
{
    public class SP
    {
        private static SP instance;

        public static SP Instance
        {
            get { if (instance == null) instance = new SP(); return instance; }
            private set { instance = value; }
        }
        private List<SanPham> list = new List<SanPham>();
        public void Add(SanPham x)
        {
            list.Add(x);
        }


        public SanPham this[string id]
        {
            get
            {
                SanPham people = list.Find(x => x.Masp == id);
                if (people is null)
                {
                    people = new SanPham();
                    people.Tensp = "<Không tìm thấy>";
                }
                return people;

            }
        }

        // Lấy ra độ dài list
        public int Length
        {
            get { return list.Count; }
        }
        // inderxer lấy ra nhân viên bằng cách truy cập vào vị trí
        public SanPham this[int x]
        {
            get
            {
                if (x >= Length || x < 0) return null;
                return list[x];
            }
        }


        public void GetFullInfo(string danhsach = "listTTbanle")
        {
            try
            {
                list.Clear();
                DataTable ds = DataProvider.Instance.ExecuteQuery(danhsach);
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    SanPham people;
                    double b = Convert.ToDouble(ds.Rows[i]["GiaTien"]);
                    people = new SanPham(ds.Rows[i]["MaSP"].ToString(), ds.Rows[i]["TenSP"].ToString(),b, ds.Rows[i]["TenLoai"].ToString());

                    Add(people);

                }
            }
            catch { }
        }
    }
}