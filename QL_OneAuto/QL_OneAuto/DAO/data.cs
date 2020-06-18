using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_OneAuto.DAO;
using QL_OneAuto.DTO;
namespace QL_OneAuto 
{
    static public class data
    {
        static data()
        {
            KH.GetFullInfo("ListNhanVien");
            NV.GetFullInfo("ListNhanVien");
            NV2.GetFullInfo("ListKhachHang");
            KH3.GetFullInfo("ListKhachHang");
            donhang.GetFullInfo("listTTbanle");
            sp.GetFullInfo("ListSP");
            listNV.GetFullInfo("NhanVien");
            KH2.GetFullInfo("ListKhachHang");
            DL.GetFullInfo("DaiLy_NhanVien");
            donhang2.GetFullInfo("ListDHBB");

        }
        static public cListPeoPle KH = new cListPeoPle();
        static public cListPeoPle NV = new cListPeoPle();
        static public KH NV2 = new KH();
        static public KH KH3 = new KH();
        static public DH donhang = new DH();
        static public SP sp = new SP();
        static public getListNV listNV= new getListNV();
        static public kh2 KH2 = new kh2();
        static public DaiLy DL = new DaiLy();
        static public dhBB donhang2 = new dhBB();

    }
}
