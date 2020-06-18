using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_OneAuto.DTO
{
    public class dhBB
    {
        private static dhBB instance;

        public static dhBB Instance
        {
            get { if (instance == null) instance = new dhBB(); return instance; }
            private set { instance = value; }
        }
        private List<DonHangBBDTO> list = new List<DonHangBBDTO>();
        public void Add(DonHangBBDTO x)
        {
            list.Add(x);
        }


        public DonHangBBDTO this[string id]
        {
            get
            {
                DonHangBBDTO people = list.Find(x => x.Madh == id);
                if (people is null)
                {
                    people = new DonHangBBDTO();
                    people.Tenkh = "<Không tìm thấy>";
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
        public DonHangBBDTO this[int x]
        {
            get
            {
                if (x >= Length || x < 0) return null;
                return list[x];
            }
        }


        public void GetFullInfo(string danhsach = "ListDHBB")
        {
            list.Clear();
            try
            {

                DataTable ds = DataProvider.Instance.ExecuteQuery(danhsach);
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    DonHangBBDTO people;
                    DateTime ngaynhap = Convert.ToDateTime(ds.Rows[i]["NgayNhap"]);
                    //DateTime ngaysinh = Convert.ToDateTime(ds.Rows[i]["NgaySinh"]);
                    double a = Convert.ToDouble(ds.Rows[i]["ThanhTien"]);
                    double b = Convert.ToDouble(ds.Rows[i]["GiaTien"]);
                    people = new DonHangBBDTO(ds.Rows[i]["MaDH"].ToString(), ds.Rows[i]["TenSP"].ToString(), ds.Rows[i]["SDT"].ToString(), ds.Rows[i]["TenKH"].ToString(), ngaynhap, (int)ds.Rows[i]["SL"], b, a, ds.Rows[i]["TenNV"].ToString(), ds.Rows[i]["DiaChi"].ToString());

                    Add(people);

                }
            }
            catch { }
        }

    }
}
