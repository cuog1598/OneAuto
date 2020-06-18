using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_OneAuto.DAO
{
    public class KH
    {
        private static KH instance;

        public static KH Instance
        {
            get { if (instance == null) instance = new KH(); return instance; }
            private set { instance = value; }
        }
        private List<KhachHang> list = new List<KhachHang>();
        public void Add(KhachHang x)
        {
            list.Add(x);
        }


        public KhachHang this[string id]
        {
            get
            {
                KhachHang people = list.Find(x => x.Makh == id);
                if (people is null)
                {
                    people = new KhachHang();
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
        public KhachHang this[int x]
        {
            get
            {
                if (x >= Length || x < 0) return null;
                return list[x];
            }
        }

       
        public void GetFullInfo(string danhsach = "ListKhachHang")
        {
            list.Clear();
            DataTable ds = DataProvider.Instance.ExecuteQuery(danhsach);
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                KhachHang people;
                DateTime ngaynhap = Convert.ToDateTime(ds.Rows[i]["NgayNhap"]);
                //DateTime ngaysinh = Convert.ToDateTime(ds.Rows[i]["NgaySinh"]);

                people = new KhachHang(ds.Rows[i]["MaKH"].ToString(), ds.Rows[i]["TenKH"].ToString(), ds.Rows[i]["DiaChi"].ToString(), ds.Rows[i]["SDT"].ToString(), ngaynhap, ds.Rows[i]["Email"].ToString());

                Add(people);
            }
        }
    }

        public class kh2
        {
            private static kh2 instance;

            public static kh2 Instance
            {
                get { if (instance == null) instance = new kh2(); return instance; }
                private set { instance = value; }
            }
            private List<KhachHang> list = new List<KhachHang>();
            public void Add(KhachHang x)
            {
                list.Add(x);
            }


            public KhachHang this[string id]
            {
                get
                {
                    KhachHang people = list.Find(x => x.Sdt == id);
                    if (people is null)
                    {
                        people = new KhachHang();
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
            public KhachHang this[int x]
            {
                get
                {
                    if (x >= Length || x < 0) return null;
                    return list[x];
                }
            }


            public void GetFullInfo(string danhsach = "ListKhachHang")
            {
                
                    list.Clear();
                    DataTable ds = DataProvider.Instance.ExecuteQuery(danhsach);
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        KhachHang people;
                        DateTime ngaynhap = Convert.ToDateTime(ds.Rows[i]["NgayNhap"]);
                        //DateTime ngaysinh = Convert.ToDateTime(ds.Rows[i]["NgaySinh"]);

                        people = new KhachHang(ds.Rows[i]["MaKH"].ToString(), ds.Rows[i]["TenKH"].ToString(), ds.Rows[i]["DiaChi"].ToString(), ds.Rows[i]["SDT"].ToString(), ngaynhap, ds.Rows[i]["Email"].ToString());

                        Add(people);

                    }
              
            }

            public int DHtop1()
            {
                try
                {
                    return (int)DataProvider.Instance.ExecuteScalar("	select top 1 with ties id from KhachHang order by id desc");
                }

                catch
                {
                    return -1;
                }
            }
        }
    }



