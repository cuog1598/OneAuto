using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_OneAuto.GUI;
using DevExpress.XtraTreeList.Nodes;
using QL_OneAuto.DAO;

namespace QL_OneAuto 
{

    public partial class NhanVien : UserControl
    {

        private static NhanVien _instance;
        public static NhanVien Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NhanVien();
                return _instance;
            }
        }
        private void SetDataToList()
        {
            treeList3.ClearNodes();

            data.KH.GetFullInfo("ListNhanVien");
            // Load danh sách khách hàng lên
            for (int i = 0; i < data.KH.Length; i++)
            {

                AddNewRow(data.KH[i]);
            }
        }

        private void SetDataToListDL()
        {
            treeList1.ClearNodes();

            data.DL.GetFullInfo("DaiLy_NhanVien");
            // Load danh sách khách hàng lên
            for (int i = 0; i < data.DL.Length; i++)
            {

                AddNewRow3(data.DL[i]);
            }
        }
        //addrow

        // Overload phương thức thêm một dòng vào treeview với đối tượng People được đưa vào
        private void AddNewRow(People x)
        {
            // Add vào treeview
            AddNewRow(x.Id, x.Hoten, x.Phone, x.Diachi, x.Tenloai, x.Email, x.Ngaysinh, x.Ngaytao);
        }


        private void AddNewRow(string id, string hoten, string phone, string diachi, string tenloai, string email, string ngaysinh, DateTime ngaytao)
        {
            object items = new object[] { id, hoten, phone, diachi, tenloai, ngaysinh, ngaytao, email };
            treeList3.AppendNode(items, null);
        }

        public NhanVien()
        {
            InitializeComponent();
            btnNhanVien.Checked = true;

           
        }

      

        private void btnNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            wait();
            SetDataToList();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[0];
        }

        private void BtnKH_CheckedChanged(object sender, EventArgs e)
        {
            wait();
            SetDataToList2();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[1];
            
            //loadlistNV();
            if (BtnKH.Checked == true)
            {


            }

        }



        // Lấy mã khách hàng đang selected
        public string[] GetIDSelected()
        {
            int number = treeList3.Selection.Count;
            if (number < 1) return null;
            // khởi tạo mảng chứa các mã số khách hàng được chọn
            string[] ds = new string[number];
            for (int i = 0; i < number; i++)
            {
                ds[i] = treeList3.Selection[i].GetValue(0).ToString();
            }
            return ds;
        }


        private void View()
        {


            // Lấy ID đang chọn
            string[] id = GetIDSelected();
            if (id.Length == 1)
            {
                // Lấy nhân viên có id đó ra
                People x = data.NV[id[0]] as People;
                if (!(x is null))
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.GetType() != typeof(TT_NV)) continue;

                        if ((form as TT_NV).NhanVien.Id == x.Id)
                        {
                            form.Focus();
                            return;
                        }
                    }

                    TT_NV f2 = new TT_NV();
                    f2.NhanVien = x;
                    
                    f2.FormClosing += F2_FormClosing;
                    f2.Show();

                }
            }

        }

        private void F2_FormClosing(object sender, FormClosingEventArgs e)
        { // chỉ kiểm tra nếu form được phép đóng
            if (!e.Cancel)
            {
                // Lấy ra thông tin nhân viên
                People x = ((TT_NV)sender).nhan;
                // Nếu id là emply hay null thì chưa lưu ~> hủy
                if (x is null) return;
                if (String.IsNullOrEmpty(x.Id)) return;
                // Lấy ra node có ID trùng với nhân viên này
                TreeListNode node = treeList3.FindNodeByKeyID(x.Id);
                if (node is null) return;
                // Sửa dòng thông tin
                node.SetValue("hoten", x.Hoten);
                node.SetValue("namsinh", x.Ngaysinh);
                node.SetValue("ngaynhap", x.Ngaytao);
                node.SetValue("tenloai", x.Tenloai);
                node.SetValue("phone", x.Phone);
                node.SetValue("diachi", x.Diachi);


            }
        }

        private void listDanhSach_DoubleClick(object sender, EventArgs e)
        {

            

        }




        //load ds khách hàng

        public string[] GetIDSelected2()
        {
            int number = treeList3.Selection.Count;
            if (number < 1) return null;
            // khởi tạo mảng chứa các mã số khách hàng được chọn
            string[] ds = new string[number];
            for (int i = 0; i < number; i++)
            {
                ds[i] = treeList3.Selection[i].GetValue(0).ToString();
            }
            return ds;
        }
       
        private void SetDataToList2()
        {
                treeList2.ClearNodes();
                data.KH2.GetFullInfo("ListKhachHang");
            // Load danh sách khách hàng lên
            
                for (int i = 0; i < data.KH2.Length; i++)
                {

                    AddNewRow2(data.KH2[i]);
                }
            
        }
       

        //addrow

      
    // Overload phương thức thêm một dòng vào treeview với đối tượng People được đưa vào
    private void AddNewRow2(KhachHang x)
    {
        // Add vào treeview
        AddNewRow2(x.Makh, x.Tenkh, x.Diachi, x.Sdt,x.Ngaynhap);
    }

    private void AddNewRow2(string makh, string tenkh, string diachi, string sdt,DateTime ngaynhap )
    {
        object items = new object[] { makh, tenkh, diachi, sdt, ngaynhap };
        treeList2.AppendNode(items, null);
    }

        //xử lý thêm

        private void themNV()
        {



        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((DevExpress.XtraBars.Docking2010.WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "create":

                    themNV();

                    break;
            }
        }


        private void bgListNV_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((DevExpress.XtraBars.Docking2010.WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "create":
                    ThemNhanVien Them = new ThemNhanVien();
                    Them.Show();

                    Them.FormClosing += Them_FormClosing;
                    break;
                case "delete":
                    SetDataToList();
                    break;
            }
        }

        private void Them_FormClosing(object sender, FormClosingEventArgs e)
        {
            // chỉ kiểm tra nếu form được phép đóng
            if (!e.Cancel)
            {
                // Lấy ra thông tin khách hàng
                People x = ((ThemNhanVien)sender).nhan;
                // Kiểm tra khách hàng này có được lưu hay chưa thông qua ID
                // Nếu id là emply hay null thì chưa lưu ~> hủy
                // Kiểm tra khách hàng này có được lưu hay chưa thông qua ID
                // Nếu id là emply hay null thì chưa lưu ~> hủy
                if (x is null) return;
                if (String.IsNullOrEmpty(x.Id)) return;
                // Add vào dữ liệu list khách hang

                // Add vào dữ liệu list khách hang
                data.NV.Add(x);
                // THêm một dòng thông tin vào treeview

                AddNewRow(x);
            }
        }



        private void txtTimKiem_SelectedValueChanged(object sender, EventArgs e)
        {

        }



        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.EditValue is null) txtTimKiem.EditValue = "";
            string SearchString = txtTimKiem.EditValue.ToString();
            foreach (TreeListNode x in treeList3.Nodes)
            {
                if (x[0].ToString().Contains(SearchString) || x[1].ToString().Contains(SearchString) || x[2].ToString().Contains(SearchString) || x[3].ToString().Contains(SearchString) || x[4].ToString().Contains(SearchString) || x[5].ToString().Contains(SearchString) || x[6].ToString().Contains(SearchString))
                    x.Visible = true;
                else
                    x.Visible = false;
            }
        }

        void wait()
        {
            Form1 f = new Form1();
            f.waitForm();
        }

        //dại lý
        private void AddNewRow3(DaiLyDTO x)
        {
            // Add vào treeview
            AddNewRow3(x.Madl, x.Tennv, x.Tendaily, x.Tenchudaily, x.Diachi, x.Sdt);
        }


        private void AddNewRow3(string madl, string TenNV, string TenDaiLy, string tenchudaily, string diachi, string sdt)
        {
            object items = new object[] { madl, TenNV, TenDaiLy, tenchudaily, diachi, sdt };
            treeList1.AppendNode(items, null);
        }

        private void windowsUIButtonPanel2_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((DevExpress.XtraBars.Docking2010.WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "create":
                    TTDL t = new TTDL();
                    t.type = true;
                    t.FormClosing += T_FormClosing;
                    t.Show();
                    //ViewDL();
                    break;
            }
        }

        private void T_FormClosing(object sender, FormClosingEventArgs e)
        {
            // chỉ kiểm tra nếu form được phép đóng
            if (!e.Cancel)
            {
                // Lấy ra thông tin khách hàng
                DaiLyDTO x = ((TTDL)sender).nhan;
                // Kiểm tra khách hàng này có được lưu hay chưa thông qua ID
                // Nếu id là emply hay null thì chưa lưu ~> hủy
                // Kiểm tra khách hàng này có được lưu hay chưa thông qua ID
                // Nếu id là emply hay null thì chưa lưu ~> hủy
                if (x is null) return;
                if (String.IsNullOrEmpty(x.Madl)) return;
                // Add vào dữ liệu list khách hang

                // Add vào dữ liệu list khách hang
                data.DL.Add(x);
                // THêm một dòng thông tin vào treeview

                AddNewRow3(x);
            }
        }

        public string[] getidDL()
        {
            int number = treeList1.Selection.Count;
            if (number < 1) return null;
            // khởi tạo mảng chứa các mã số khách hàng được chọn
            string[] ds = new string[number];
            for (int i = 0; i < number; i++)
            {
                ds[i] = treeList1.Selection[i].GetValue(0).ToString();
            }
            return ds;
        }
        private void ViewDL()
        {
            // Lấy ID đang chọn
            string[] id = getidDL();
            if (id.Length == 1)
            {
                // Lấy nhân viên có id đó ra
                DaiLyDTO x = data.DL[id[0]] as DaiLyDTO;
                if (!(x is null))
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.GetType() != typeof(TTDL)) continue;

                        if ((form as TTDL).daily.Madl == x.Madl)
                        {
                            form.Focus();
                            return;
                        }
                    }

                    TTDL f = new TTDL();
                    f.daily = x;
                    f.Show();
                    f.FormClosing += F_FormClosing;
                }
            }
        }

        private void F_FormClosing(object sender, FormClosingEventArgs e)
        {
            // chỉ kiểm tra nếu form được phép đóng
            if (!e.Cancel)
            {
                // Lấy ra thông tin nhân viên
                DaiLyDTO x = ((TTDL)sender).nhan;
                // Nếu id là emply hay null thì chưa lưu ~> hủy
                // Nếu id là emply hay null thì chưa lưu ~> hủy
                if (x is null) return;
                if (String.IsNullOrEmpty(x.Madl)) return;
                // Lấy ra node có ID trùng với nhân viên này
                DevExpress.XtraTreeList.Nodes.TreeListNode node = treeList1.FindNodeByKeyID(x.Madl);
                if (node is null) return;

                node.SetValue("tendaily", x.Tendaily);
                node.SetValue("tenchudaily", x.Tenchudaily);
                //node.SetValue("tennv", x.Tennv);
                //node.SetValue("Email", x.Email);
                node.SetValue("sdt", x.Sdt);
                node.SetValue("diachi", x.Diachi);
            }
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            ViewDL();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            btnNhanVien.Focus();
            SetDataToList();
            SetDataToList2();
            SetDataToListDL();
        }

        private void BtnKH_CheckedChanged_1(object sender, EventArgs e)
        {
            SetDataToListDL();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[2];
        }

        private void searchControl1_EditValueChanged(object sender, EventArgs e)
        {
            if (searchControl1.EditValue is null) searchControl1.EditValue = "";
            string SearchString = searchControl1.EditValue.ToString();
            foreach (TreeListNode x in treeList2.Nodes)
            {
                if (x[0].ToString().Contains(SearchString) || x[1].ToString().Contains(SearchString) || x[2].ToString().Contains(SearchString) || x[3].ToString().Contains(SearchString))
                    x.Visible = true;
                else
                    x.Visible = false;
            }
        }

        private void searchControl2_EditValueChanged(object sender, EventArgs e)
        {
            if (searchControl2.EditValue is null) searchControl2.EditValue = "";
            string SearchString = searchControl2.EditValue.ToString();
            foreach (TreeListNode x in treeList1.Nodes)
            {
                if (x[0].ToString().Contains(SearchString) || x[1].ToString().Contains(SearchString) || x[2].ToString().Contains(SearchString) || x[3].ToString().Contains(SearchString) || x[4].ToString().Contains(SearchString) || x[5].ToString().Contains(SearchString))
                    x.Visible = true;
                else
                    x.Visible = false;
            }
        }

        private void treeList3_DoubleClick(object sender, EventArgs e)
        {
            View();
        }
    }
}

