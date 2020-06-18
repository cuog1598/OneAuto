using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_OneAuto.DAO;
using QL_OneAuto.DTO;
using QL_OneAuto.GUI;

namespace QL_OneAuto 
{
    public partial class DonHang : UserControl
    {
        private static DonHang _instance;
        public static DonHang Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DonHang();
                return _instance;
            }
        }
        public DonHang()
        {
            InitializeComponent();
            SetDataToList2();
            SetDataToList();

        }

        private void SetDataToList()
        {
            listDanhSach.ClearNodes();

            data.donhang.GetFullInfo("listTTbanle");
            // Load danh sách khách hàng lên
            for (int i = 0; i < data.donhang.Length; i++)
            {

                AddNewRow(data.donhang[i]);
            }
        }
        private void SetDataToList2()
        {
            treeList1.ClearNodes();

            data.donhang2.GetFullInfo("ListDHBB");
            // Load danh sách khách hàng lên
            for (int i = 0; i < data.donhang2.Length; i++)
            {

                AddNewRow2(data.donhang2[i]);
            }
        }
        private void AddNewRow(DonHangDTO x)
        {
            // Add vào treeview
            AddNewRow(x.Madh,x.Tensp,x.Sdt,x.Tenkh,x.Ngaylap,x.Sl,x.Gia,x.Tongtien,x.Tennv,x.Diachi);
        }


        private void AddNewRow(string madh, string tensp, string sdt, string tenkh, DateTime ngaylap, int sl,double gia, double tongtien, string tennv,string diachi)
        {
            object items = new object[] { madh, tensp, sdt, tenkh, ngaylap, sl, gia, tongtien, tennv,diachi };
            listDanhSach.AppendNode(items, null);
        }
        private void AddNewRow2(DonHangBBDTO x)
        {
            // Add vào treeview
            AddNewRow2(x.Madh, x.Tensp, x.Sdt, x.Tenkh, x.Ngaylap, x.Sl, x.Gia, x.Tongtien, x.Tennv, x.Diachi);
        }


        private void AddNewRow2(string madh, string tensp, string sdt, string tenkh, DateTime ngaylap, int sl, double gia, double tongtien, string tennv, string diachi)
        {
            object items = new object[] { madh, tensp, sdt, tenkh, ngaylap, sl, gia, tongtien, tennv, diachi };
            treeList1.AppendNode(items, null);
        }



        private void bgListNV_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((DevExpress.XtraBars.Docking2010.WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "create":
                    HoaDon h = new HoaDon();
                    
                    h.Show();

                    h.FormClosing += H_FormClosing;
                    break;
            }
        }

        private void H_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!e.Cancel)
            {
                SetDataToList();
            }
        }

        private void btnNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[0];
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraTabControl2.SelectedTabPage = xtraTabControl2.TabPages[1];
            if (!panel10.Controls.Contains(thongkebanle.Instance))
            {

                panel10.Controls.Add(thongkebanle.Instance);
                thongkebanle.Instance.Dock = DockStyle.Fill;
                thongkebanle.Instance.BringToFront();

            }
            else
            {
                thongkebanle.Instance.BringToFront();
                
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraTabControl2.SelectedTabPage = xtraTabControl2.TabPages[0];
             

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraTabControl2.SelectedTabPage = xtraTabControl2.TabPages[1];
            if (!panel10.Controls.Contains(ThongkeNgay.Instance))
            {

                panel10.Controls.Add(ThongkeNgay.Instance);
                ThongkeNgay.Instance.Dock = DockStyle.Fill;
                ThongkeNgay.Instance.BringToFront();

            }
            else
            {
                ThongkeNgay.Instance.BringToFront();

            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraTabControl3.SelectedTabPage = xtraTabControl3.TabPages[0];
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraTabControl3.SelectedTabPage = xtraTabControl3.TabPages[1];
            if (!panel13.Controls.Contains(ThongKeBB.Instance))
            {

                panel13.Controls.Add(ThongKeBB.Instance);
                ThongKeBB.Instance.Dock = DockStyle.Fill;
                ThongKeBB.Instance.BringToFront();

            }
            else
            {
                ThongKeBB.Instance.BringToFront();

            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraTabControl3.SelectedTabPage = xtraTabControl3.TabPages[1];
            if (!panel13.Controls.Contains(ThongkebanbuonTheoNgay.Instance))
            {

                panel13.Controls.Add(ThongkebanbuonTheoNgay.Instance);
                ThongkebanbuonTheoNgay.Instance.Dock = DockStyle.Fill;
                ThongkebanbuonTheoNgay.Instance.BringToFront();

            }
            else
            {
                ThongkebanbuonTheoNgay.Instance.BringToFront();

            }
        }

        private void BtnKH_CheckedChanged(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[1];
            SetDataToList2();
        }

        private void windowsUIButtonPanel2_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((DevExpress.XtraBars.Docking2010.WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "create":
                    HoaDon h = new HoaDon();

                    h.Show();

                    h.FormClosing += H_FormClosing;
                    break;
            }
        }
    
    }
}
