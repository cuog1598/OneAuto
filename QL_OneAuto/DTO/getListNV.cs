using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_OneAuto
{
    public class getListNV
    {
        private static cListPeoPle instance;

        public static cListPeoPle Instance
        {
            get { if (instance == null) instance = new cListPeoPle(); return instance; }
            private set { instance = value; }
        }


        // Lưu bằng list
        private List<People> list = new List<People>();
        // Lấy ra độ dài list
        public int Length
        {
            get { return list.Count; }
        }
        public void Add(People x)
        {
            list.Add(x);
        }


        // inderxer lấy ra nhân viên bằng cách truy cập vào vị trí
        public People this[int x]
        {
            get
            {
                if (x >= Length || x < 0) return null;
                return list[x];
            }
        }
        // indexer lấy ra nhân viên bằng cách truy cập id 
        public People this[string id]
        {
            get
            {
                People people = list.Find(x => x.Phone == id);
                if (people is null)
                {
                    people = new People();
                    people.Hoten = "<Không tìm thấy>";
                }
                return people;

            }
        }

        public void GetFullInfo(string danhsach = "NhanVien")
        {
            try
            {
                list.Clear();
                DataTable ds = DataProvider.Instance.ExecuteQuery("select * from " + danhsach + " n, loainhanvien l where l.MaLoai=n.MaLoai ");
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    People people;

                    DateTime ngaysinh = Convert.ToDateTime(ds.Rows[i]["NgaySinh"].ToString());

                    DateTime ngaytao = Convert.ToDateTime(ds.Rows[i]["NgayNhap"]);
                    people = new People(ds.Rows[i]["MaNV"].ToString(), ds.Rows[i]["TenNV"].ToString(), ds.Rows[i]["SDT"].ToString(), ds.Rows[i]["DiaChi"].ToString(), ds.Rows[i]["TenLoai"].ToString(), ds.Rows[i]["email"].ToString(), String.Format("{0:yyyy-MM-dd}", ngaysinh), ngaytao);

                    Add(people);

                }
            }
            catch { }
        }
    }
}
