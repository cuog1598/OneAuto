using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QL_OneAuto.DAO;
using QL_OneAuto.DTO;

namespace QL_OneAuto.GUI
{
    public partial class HoaDon : DevExpress.XtraEditors.XtraForm
    {
        public HoaDon()
        {
            InitializeComponent();
        }


        People hoadon = new People();

        private void ChonKhachHang()
        {
            using (var f1 = new ChonNhanVien())
            {

                f1.ID_Choose = hoadon.Id;
                var result = f1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(f1.ID_Choose))
                    {
                        hoadon.Id = f1.ID_Choose;
                        txtNV.Text = data.NV[hoadon.Id].Hoten;
                        manv = hoadon.Id;
                    }
                    else
                    {
                        MessageBox.Show("k có");
                    }
                }
            }


        }
        string manv;
        string masp;
        private void ChonKhachHang2()
        {
            using (var f1 = new ChonNhanVien())
            {

                f1.ID_Choose = hoadon.Id;
                var result = f1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(f1.ID_Choose))
                    {
                        hoadon.Id = f1.ID_Choose;
                        BBchonDaiLy.Text = data.NV[hoadon.Id].Hoten;

                        textBox1.Text = data.NV[hoadon.Id].Id;
                    }
                    else
                    {
                        MessageBox.Show("k có");
                    }
                }
            }


        }
        private void comboBoxEdit1_Click(object sender, EventArgs e)
        {
            ChonKhachHang2();
        }

        private void txtNV_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ChonKhachHang();
        }

        private void ChonSP_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ChonSanPham();
        }
        SanPham sanPH = new SanPham();
        private void ChonSanPham()
        {
            using (var f = new ChonSP())
            {

                f.ID_Choose = sanPH.Masp;
                var result = f.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(f.ID_Choose))
                    {
                        sanPH.Masp = f.ID_Choose;
                        ChonSP.Text = data.sp[sanPH.Masp].Tensp;
                        txtGia.Text = data.sp[sanPH.Masp].Giatien.ToString();
                        txtSL.Text = "1";
                        txtSL.Enabled = true;
                        checkEdit1.Enabled = true;
                        masp = data.sp[sanPH.Masp].Masp;
                    }
                    else
                    {
                        MessageBox.Show("k có");
                    }
                }
            }
        }



        private void SetTextBoxEnabled(bool enabled)
        {
            txtDiaChi.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtHoTen.Enabled = enabled;

            // txtPhone.Enabled = enabled;
        }
        //hàm kiểm tra sđt

        bool isPhone(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phone, "^[0-9]{7,13}$");
        }

        private void txtPhone_EditValueChanged(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(data.KH2[txtPhone.Text].Sdt)))
            {
                epLoi.SetError((Control)sender, "Số điện thoại đã tồn tại");
                txtPhone.Properties.Appearance.BorderColor = Color.Red;
                if (XtraMessageBox.Show("Số điện thoại này đã tồn tại.bạn chỉ được phép dùng lại khách hàng đã lưu hoặc dùng số điện thoại mới\n" + "Bạn muốn dùng lại thông tin khách hàng?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    txtPhone.Enabled = false;
                    setTextboxKH();
                    SetTextBoxEnabled(false);
                    
                    llbChange.Visible = true;
                    txtPhone.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                    epLoi.SetError(txtPhone, null);
                }

            }
            else
            {

                txtPhone.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                epLoi.SetError(txtPhone, null);
            }
            // kiểm tra số điện thoại nhập vào có chính xác hay ko
            // số điện thoại chính xác phải từ 7 đến 11 ký tự và ko có ký tự khác số
            string phone = ((Control)sender).Text;
            // nếu rỗng hoặc null thì ko kiểm tra
            if (String.IsNullOrEmpty(phone))
            {
                epLoi.SetError((Control)sender, null);
                return;
            }

            if (!isPhone(phone))
            {
                epLoi.SetError((Control)sender, "Số điện thoại hợp lệ phải từ 7 đến 13 chữ số, không chứa các ký tự khác số");
            }
            else
            {
                epLoi.SetError((Control)sender, null);
                // nếu hợp lệ thì replace các ký tự khoảng trắng dư thừa
                phone = phone.Trim();
                phone = phone.Replace(" ", String.Empty);
                txtPhone.Text = phone;
            }

        }
        private void testSDT()
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                XtraMessageBox.Show("Phải nhập số điện thoại trước", "Thông báo", MessageBoxButtons.OK);
                txtPhone.Focus();
            }
        }
        private void txtHoTen_EditValueChanged(object sender, EventArgs e)
        {
            testSDT();


        }

        static public bool isEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        private void txtEmail_EditValueChanged(object sender, EventArgs e)
        {
            testSDT();
            // kiểm tra email nhập vào có hợp lệ hay ko
            string email = ((Control)sender).Text;
            if (String.IsNullOrEmpty(email))
            {
                epLoi.SetError((Control)sender, null);
                return;
            }
            if (!isEmail(email))
            {
                epLoi.SetError((Control)sender, "Email có định dạng không hợp lệ");
            }
            else
            {
                epLoi.SetError((Control)sender, null);

            }
        }

        private void txtDiaChi_EditValueChanged(object sender, EventArgs e)
        {
            testSDT();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
           
            
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtHoTen.Text = "";
            txtPhone.Text = "";
            txtPhone.Enabled = true;
            SetTextBoxEnabled(true);
        }

        // đổ dữ liệu có sẵn vào textbox khcash hàng

        private void setTextboxKH()
        {
            txtHoTen.Text = data.KH2[txtPhone.Text].Tenkh;
            txtDiaChi.Text = data.KH2[txtPhone.Text].Diachi;
            txtEmail.Text = data.KH2[txtPhone.Text].Email;
            txtmkh.Text = data.KH2[txtPhone.Text].Makh;

        }
        //kiểm tra kí tự số
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                txtGiamGia.Enabled = true;
                txtGiamGia.Focus();
                txtGiam.Text = "0";
                label1.Visible = true;
            }
            else
            {
                txtGiamGia.Enabled = false;
                txtGiamGia.Text = "";
                txtGiam.Text = "";
                label1.Visible = false;
            }
        }


        private void tinhGG()
        {
            if (string.IsNullOrEmpty(txtGiamGia.Text))
            {
                epLoi.SetError(txtGiamGia, null);
                return;
            }
            if (string.IsNullOrEmpty(txtSL.Text))
            {
                epLoi.SetError(txtSL, "Không được bỏ trống số lượng hàng ");
                return;
            }
            if (IsNumber(txtGiamGia.Text) == true)
            {
                if (Convert.ToInt32(txtGiamGia.Text) > 99)
                {
                    epLoi.SetError(txtGiamGia, "chỉ được phép giảm từ 0-99%");
                }
                if (Convert.ToInt32(txtGiamGia.Text) < 99)
                {
                    int a = Convert.ToInt32(txtGia.Text) * Convert.ToInt32(txtSL.Text);
                    txtGiam.Text = (a * Convert.ToInt32(txtGiamGia.Text) / 100).ToString();
                    epLoi.SetError(txtGiamGia, null);
                }
            }

            else
            {
                epLoi.SetError(txtGiamGia, "chỉ được phép nhập số nguyên");
                txtGiam.Text = "0";
            }
        }
        private void txtGiamGia_EditValueChanged(object sender, EventArgs e)
        {
            tinhGG();
        }

        private void tabHoaDon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSL_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSL.Text))
                {
                    txtTongGT.Text = "0";
                    txtBalance.Text = "0";
                    txtGiam.Text = "0";
                    epLoi.SetError((Control)sender, null);
                    return;
                }
                else
                {
                    if (Convert.ToInt64(txtSL.Text) > 1000)
                    {
                        txtTongGT.Text = "0";
                        txtBalance.Text = "0";
                        txtGiam.Text = "0";
                        epLoi.SetError(txtSL, "số lượng vượt quá mức cho phép");

                    }
                }
                if (IsNumber(txtSL.Text) == true && Convert.ToInt32(txtSL.Text) < 1000)
                {
                    int a = Convert.ToInt32(txtGia.Text) * Convert.ToInt32(txtSL.Text);
                    txtTongGT.Text = String.Format("{0:$#,##}", a);
                    tinhGG();
                    epLoi.SetError(txtSL, null);
                }
                else
                {
                    epLoi.SetError((Control)sender, "chỉ được phép nhập số nguyên");
                    txtTongGT.Text = "0";
                    txtSL.Text = "";
                    txtSL.Focus();
                }
            }
            catch
            {

            }

        }

        private void thanhtien()
        {

            if (string.IsNullOrEmpty(txtSL.Text))
            {

                return;
            }
            if (IsNumber(txtSL.Text) == true && checkEdit1.Checked == false)
            {
                int a = Convert.ToInt32(txtGia.Text) * Convert.ToInt32(txtSL.Text);

                //txtTongGT.Text = String.Format("{0:$#,##}", a);
                txtBalance.Text = String.Format("{0:$#,##}", a);
            }
            if (IsNumber(txtSL.Text) == true && checkEdit1.Checked == true)
            {
                int a = Convert.ToInt32(txtGia.Text) * Convert.ToInt32(txtSL.Text);
                int b = Convert.ToInt32(txtGiam.Text);
                int c = (a - b);
                txtBalance.Text = String.Format("{0:$#,##}", c);
            }
            else
            {

            }

        }

        private void txtTongGT_EditValueChanged(object sender, EventArgs e)
        {
            thanhtien();
        }

        //hàm xử lý lưu hoá đơn bán lẻ
        string makh;
        private void LuuHDBL()
        {
            double giam=0;
            if(!string.IsNullOrEmpty(txtGiam.Text))
            {
                giam = Convert.ToDouble(txtGiam.Text);
            }
            DateTime get = DateTime.Now;
            string mahd = "HD0" + (DH.Instance.DHtop1() + 1).ToString();
            //lưu cả 2 cho bán lẻ
            if (string.IsNullOrEmpty(txtmkh.Text))

            {
                MessageBox.Show("null");
                if (DH.Instance.insert(txtHoTen.Text, txtDiaChi.Text, txtPhone.Text, txtEmail.Text, masp, Convert.ToInt32(txtSL.Text), giam, manv))
                {
                    if (DH.Instance.insert2(txtHoTen.Text, txtDiaChi.Text, txtPhone.Text, txtEmail.Text, masp, Convert.ToInt32(txtSL.Text), giam, manv, 1))
                    {
                        string str = "<b> Mã hóa đơn</ b >:" + mahd + "\n<b> Lập vào ngày: </ b > " + get.ToString("dd / MM / yyyy lúc HH:mm") + "\n<b> Lập bởi:</ b > " + data.NV[manv].Hoten + "\n<b> Khách hàng:</ b > " + txtHoTen.Text;

                        XtraMessageBox.Show("Đã lưu lại hóa đơn này\n" + str, "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True);
                        makh = kh2.Instance.DHtop1().ToString();
                        if (SaveObj())
                        {

                        }
                    }
                }
            }
            //lưu sản hẩm cho hoá đơn
            else
            {
                if (DH.Instance.insertDH(masp, Convert.ToInt32(txtSL.Text),giam, manv, txtmkh.Text, 1))
                {
                    string str = "<b> Mã hóa đơn: " + mahd + "\n<b> Lập vào ngày: " + get.ToString("dd / MM / yyyy lúc HH:mm") + "\n<b> Lập bởi:</ b > " + data.NV[manv].Hoten + "\n<b> Khách hàng:</ b > " + txtHoTen.Text;

                    XtraMessageBox.Show("Đã lưu lại hóa đơn này\n" + str, "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True);

                }
            }
        }

        private void txtGiam_EditValueChanged(object sender, EventArgs e)
        {
            thanhtien();
        }
        public KhachHang nhan;
        private bool SaveObj()
        {
            // Khởi tạo đối tượng NhanVien nếu chưa có
            nhan = new KhachHang();
            // Lấy họ tên đã được tách ra
            nhan.Makh = makh;
            nhan.Ngaynhap = DateTime.Now;
            nhan.Sdt = txtPhone.Text;
            nhan.Tenkh = txtHoTen.Text;
            nhan.Tennv = txtNV.Text;
            nhan.Diachi = txtDiaChi.Text;
            // Lưu vào obj

            //data.NV.Add(nhan);
            return true;

        }
        //xử lý button click_luu_in_thoat
        private void bgHoaDonButton_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((DevExpress.XtraBars.Docking2010.WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "save":
                    if (!isInputValid())
                    {
                        XtraMessageBox.Show("Vui lòng kiểm tra các giá trị nhập vào, một số giá trị không hợp lệ nên không thể lưu thông tin", "Lưu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    else
                    {
                        LuuHDBL();
                        this.Close();
                    }
                    break;

                //đóng
                case "close":
                    Close();
                    break;
            }
        }

        #region BB
        private string bbMaSp;
        private string bbMaNV;
        private void comboBoxEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ChonSanPhamBB();
        }
        private void ChonSanPhamBB()
        {
            using (var f = new ChonSP())
            {

                f.ID_Choose = sanPH.Masp;
                var result = f.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(f.ID_Choose))
                    {
                        sanPH.Masp = f.ID_Choose;
                        bbChonSP.Text = data.sp[sanPH.Masp].Tensp;
                        BBtxtGia.Text = data.sp[sanPH.Masp].Giatien.ToString();
                        BBtxtSL.Text = "1";
                        BBtxtSL.Enabled = true;
                        checkEdit2.Enabled = true;
                        bbMaSp = data.sp[sanPH.Masp].Masp;
                    }
                    else
                    {
                        MessageBox.Show("k có");
                    }
                }
            }
        }
        DaiLyDTO dl = new DaiLyDTO();
        private void ChonDaiLy()
        {
            using (var f = new ChonDaiLy())
            {

                f.ID_Choose = dl.Madl;
                var result = f.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(f.ID_Choose))
                    {
                        dl.Madl = f.ID_Choose;
                        BBchonDaiLy.Text = data.DL[dl.Madl].Tendaily.ToString();
                        bbMaNV = data.DL[dl.Madl].Manv;
                        BBtxtNhanVien.Text = data.DL[dl.Madl].Tennv.ToString();


                    }
                    else
                    {
                        MessageBox.Show("k có");
                    }
                }
            }
        }

        private void comboBoxEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ChonDaiLy();
        }

        private void BBluu()
        {
            DateTime get = DateTime.Now;
            string mahd = "HD0" + (DH.Instance.DHtop1() + 1).ToString();
            //lưu cả 2 cho bán lẻ
            if (string.IsNullOrEmpty(BBtxtMakh.Text))

            {
                //HAMF LUWU
            }
            //lưu sản hẩm cho hoá đơn
            else
            {

            }

        }
        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((DevExpress.XtraBars.Docking2010.WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "save":
                    if (!isInputValidBB())
                    {
                        XtraMessageBox.Show("Vui lòng kiểm tra các giá trị nhập vào, một số giá trị không hợp lệ nên không thể lưu thông tin", "Lưu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    else
                    {
                        
                        LuuHDBB();

                    }
                    break;

                //đóng
                case "close":
                    Close();
                    break;
            }
        }

        #endregion
        //
        private void setTextboxKHBB()
        {
            BBtxtHoTen.Text = data.KH2[BBtxtPhone.Text].Tenkh;
            BBtxtDC.Text = data.KH2[BBtxtPhone.Text].Diachi;
            BBtxtEmail.Text = data.KH2[BBtxtPhone.Text].Email;
            BBtxtMakh.Text = data.KH2[BBtxtPhone.Text].Makh;

        }
        private void SetTextBoxBBEnabled(bool enabled)
        {
            BBtxtDC.Enabled = enabled;
            BBtxtEmail.Enabled = enabled;
            BBtxtHoTen.Enabled = enabled;

            // txtPhone.Enabled = enabled;
        }

        private void BBtxtPhone_EditValueChanged(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(data.KH2[BBtxtPhone.Text].Sdt)))
            {
                epLoi.SetError((Control)sender, "Số điện thoại đã tồn tại");
                BBtxtPhone.Properties.Appearance.BorderColor = Color.Red;
                if (XtraMessageBox.Show("Số điện thoại này đã tồn tại.bạn chỉ được phép dùng lại khách hàng đã lưu hoặc dùng số điện thoại mới\n" + "Bạn muốn dùng lại thông tin khách hàng?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    BBtxtPhone.Enabled = false;
                    setTextboxKHBB();
                    linkLabel1.Visible = true;
                    SetTextBoxBBEnabled(false);
                    BBtxtPhone.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                    epLoi.SetError(BBtxtPhone, null);
                }

            }
            else
            {
                BBtxtPhone.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                epLoi.SetError(BBtxtPhone, null);
            }
            // kiểm tra số điện thoại nhập vào có chính xác hay ko
            // số điện thoại chính xác phải từ 7 đến 11 ký tự và ko có ký tự khác số
            string phone = ((Control)sender).Text;
            // nếu rỗng hoặc null thì ko kiểm tra
            if (String.IsNullOrEmpty(phone))
            {
                epLoi.SetError((Control)sender, null);
                return;
            }

            if (!isPhone(phone))
            {
                epLoi.SetError((Control)sender, "Số điện thoại hợp lệ phải từ 7 đến 13 chữ số, không chứa các ký tự khác số");
            }
            else
            {
                epLoi.SetError((Control)sender, null);
                // nếu hợp lệ thì replace các ký tự khoảng trắng dư thừa
                phone = phone.Trim();
                phone = phone.Replace(" ", String.Empty);
                BBtxtPhone.Text = phone;
            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == true)
            {
                BBtxtGiamGia.Enabled = true;
                BBtxtGiamGia.Focus();
                BBtxtGiam.Text = "0";
                label3.Visible = true;
            }
            else
            {
                BBtxtGiamGia.Enabled = false;
                BBtxtGiamGia.Text = "";
                BBtxtGiam.Text = "0";
                label1.Visible = false;
            }
        }
        private void bbGG()
        {
            try
            {
                if (string.IsNullOrEmpty(BBtxtGiamGia.Text))
                {
                    epLoi.SetError(BBtxtGiamGia, null);
                    return;
                }
                if (string.IsNullOrEmpty(BBtxtSL.Text))
                {
                    epLoi.SetError(BBtxtSL, "không được bỏ trống số lượng hàng  ");
                    return;
                }
                if (IsNumber(BBtxtGiamGia.Text) == true)
                {
                    if (Convert.ToInt32(BBtxtGiamGia.Text) > 99)
                    {
                        epLoi.SetError(BBtxtGiamGia, "chỉ được phép giảm từ 0-99%");
                    }
                    if (Convert.ToInt32(BBtxtGiamGia.Text) < 99)
                    {
                        int a = Convert.ToInt32(BBtxtGia.Text) * Convert.ToInt32(BBtxtSL.Text);
                        BBtxtGiam.Text = (a * Convert.ToInt32(BBtxtGiamGia.Text) / 100).ToString();
                        epLoi.SetError(BBtxtGiamGia, null);
                    }
                }

                else
                {
                    epLoi.SetError(BBtxtGiamGia, "chỉ được phép nhập số nguyên");
                    txtGiam.Text = "0";
                }
            }
            catch { }
        }
        private void BBtxtSL_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(BBtxtSL.Text))
                {
                    BBtxtTongGiaTri.Text = "0";
                    BBtxtThanhTien.Text = "0";
                    BBtxtGiam.Text = "0";
                    epLoi.SetError((Control)sender, null);
                    return;
                }

                else
                {
                    if (Convert.ToInt64(BBtxtSL.Text) > 1000)
                    {
                        BBtxtTongGiaTri.Text = "0";
                        BBtxtThanhTien.Text = "0";
                        BBtxtGiam.Text = "0";
                        epLoi.SetError(BBtxtSL, "số lượng vượt quá mức cho phép");
                    }
                }
                if (IsNumber(BBtxtSL.Text) == true && Convert.ToInt32(BBtxtSL.Text) < 1000)
                {
                    int a = Convert.ToInt32(BBtxtGia.Text) * Convert.ToInt32(BBtxtSL.Text);
                    BBtxtTongGiaTri.Text = String.Format("{0:$#,##}", a);
                    bbGG();
                    epLoi.SetError(BBtxtSL, null);
                }
                else
                {
                    epLoi.SetError((Control)sender, "chỉ được phép nhập số nguyên");
                    BBtxtTongGiaTri.Text = "0";
                    BBtxtSL.Text = "";
                    BBtxtSL.Focus();
                }
            }
            catch { }
        }

        private void BBtxtGiamGia_EditValueChanged(object sender, EventArgs e)
        {
            bbGG();
        }
        private void tonggiaBB()
        {
            if (string.IsNullOrEmpty(BBtxtSL.Text))
            {

                return;
            }
            if (IsNumber(BBtxtSL.Text) == true && checkEdit2.Checked == false)
            {
                int a = Convert.ToInt32(BBtxtGia.Text) * Convert.ToInt32(BBtxtSL.Text);

                //txtTongGT.Text = String.Format("{0:$#,##}", a);
                BBtxtThanhTien.Text = a.ToString();
            }
            if (IsNumber(BBtxtSL.Text) == true && checkEdit2.Checked == true)
            {
                int a = Convert.ToInt32(BBtxtGia.Text) * Convert.ToInt32(BBtxtSL.Text);
                int b = Convert.ToInt32(BBtxtGiam.Text);
                //txtTongGT.Text = String.Format("{0:$#,##}", a);
                BBtxtThanhTien.Text = (a - b).ToString();
            }
            else
            {

            }
        }
        private void BBtxtTongGiaTri_EditValueChanged(object sender, EventArgs e)
        {
            tonggiaBB();
            bbGG();
        }

        private void BBtxtGiam_EditValueChanged(object sender, EventArgs e)
        {
            tonggiaBB();
        }


        public bool isInputValid()
        {

            // biến bool trả về giá trị true nếu tất cả input đều valid
            // Các input ko được null hoặc emply: id, fullname
            // Các input cần kiểm tra giá trị nhập hợp lệ: phone, email
            bool isValid = true;
            // kiểm tra  điện thoại, chỉ kiểm tra nếu != null hoặc emply
            if (!isPhone(txtPhone.Text) && !String.IsNullOrEmpty(txtPhone.Text))
            {
                // hiển thị lỗi
                txtPhone.Properties.Appearance.BorderColor = Color.Red;
                isValid = false;
                epLoi.SetError(txtPhone, "Số điện thoại không hợp lệ, số điện phải phải từ 7 đến 11 chữ số");
            }

            // reset lại border color
            else
            {
                if (string.IsNullOrEmpty(txtPhone.Text) && String.IsNullOrEmpty(txtPhone.Text))
                {
                    txtPhone.Properties.Appearance.BorderColor = Color.Red;
                    epLoi.SetError(txtPhone, "không được bỏ trống sđt");
                    isValid = false;
                }
                else
                {
                    epLoi.SetError(BBtxtPhone, null);
                    txtPhone.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                }
            }

            // Kiểm tra tên và id có bị null hay ko
            if (String.IsNullOrEmpty(txtHoTen.Text))
            {
                txtHoTen.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(txtHoTen, "Tên nhân viên không được bỏ trống");
                isValid = false;
            }
            else
            {
                epLoi.SetError(txtHoTen, null);
                txtPhone.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
            }
            if (string.IsNullOrEmpty(ChonSP.Text))
            {
                ChonSP.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(ChonSP, "Sản phẩm không được bỏ trống");
                isValid = false;

            }
            else
            {
                epLoi.SetError(ChonSP, null);
                ChonSP.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
            }
            if (string.IsNullOrEmpty(txtSL.Text))
            {
                txtSL.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(txtSL, "Số lượng không được bỏ trống");
                isValid = false;
            }
            else
            {
                epLoi.SetError(txtSL, null);
                txtSL.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
            }

            //
            if (string.IsNullOrEmpty(txtNV.Text))
            {
                txtNV.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(txtNV, "không được bỏ trống nhân viên ");
                isValid = false;
            }
            else
            {
                epLoi.SetError(txtNV, null);
                txtNV.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
            }

            return isValid;
        }

        private void txtNV_TextChanged(object sender, EventArgs e)
        {
            epLoi.SetError(txtNV, null);
            txtNV.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
        }

        private void ChonSP_TextChanged(object sender, EventArgs e)
        {
            epLoi.SetError(ChonSP, null);
            ChonSP.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
        }

        //băt lỗi cho bb
        public bool isInputValidBB()
        {

            // biến bool trả về giá trị true nếu tất cả input đều valid
            // Các input ko được null hoặc emply: id, fullname
            // Các input cần kiểm tra giá trị nhập hợp lệ: phone, email
            bool isValid = true;
            // kiểm tra  điện thoại, chỉ kiểm tra nếu != null hoặc emply
            if (!isPhone(BBtxtPhone.Text) && !String.IsNullOrEmpty(txtPhone.Text))
            {
                // hiển thị lỗi
                BBtxtPhone.Properties.Appearance.BorderColor = Color.Red;
                isValid = false;
                epLoi.SetError(BBtxtPhone, "Số điện thoại không hợp lệ, số điện phải phải từ 7 đến 11 chữ số");
            }

            // reset lại border color
            else
            {
                if (string.IsNullOrEmpty(BBtxtPhone.Text) && String.IsNullOrEmpty(BBtxtPhone.Text))
                {
                    BBtxtPhone.Properties.Appearance.BorderColor = Color.Red;
                    epLoi.SetError(txtPhone, "không được bỏ trống sđt");
                    isValid = false;
                }
                else
                {
                    epLoi.SetError(BBtxtPhone, null);
                    BBtxtPhone.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                }

            }

            // Kiểm tra tên và id có bị null hay ko
            if (String.IsNullOrEmpty(BBtxtHoTen.Text))
            {
                BBtxtHoTen.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(BBtxtHoTen, "Tên khách hàng không được bỏ trống");
                isValid = false;
            }
            else
            {
                epLoi.SetError(BBtxtHoTen, null);
                BBtxtHoTen.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
            }
            if (string.IsNullOrEmpty(bbChonSP.Text))
            {
                bbChonSP.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(bbChonSP, "Sản phẩm không được bỏ trống");
                isValid = false;

            }
            else
            {
                epLoi.SetError(bbChonSP, null);
                bbChonSP.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
            }
            if (string.IsNullOrEmpty(BBtxtSL.Text))
            {
                BBtxtSL.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(BBtxtSL, "Số lượng không được bỏ trống");
                isValid = false;
            }
            else
            {
                epLoi.SetError(BBtxtSL, null);
                BBtxtSL.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
            }

            //
            if (string.IsNullOrEmpty(BBchonDaiLy.Text))
            {
                BBchonDaiLy.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(BBchonDaiLy, "không được bỏ trống Đại lý ");
                isValid = false;
            }
            else
            {
                epLoi.SetError(BBchonDaiLy, null);
                BBchonDaiLy.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
            }

            return isValid;
        }

        private void bbChonSP_TextChanged(object sender, EventArgs e)
        {
            epLoi.SetError(bbChonSP, null);
            bbChonSP.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
        }

        private void BBchonDaiLy_TextChanged(object sender, EventArgs e)
        {

            epLoi.SetError(BBchonDaiLy, null);
            BBchonDaiLy.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;

        }

        private void checkssdtBB()
        {
            if (string.IsNullOrEmpty(BBtxtPhone.Text))
            {
                XtraMessageBox.Show("Phải nhập số điện thoại trước", "Thông báo", MessageBoxButtons.OK);
                BBtxtPhone.Focus();
            }
        }

        private void BBtxtHoTen_EditValueChanged(object sender, EventArgs e)
        {
            checkssdtBB();
        }

        private void BBtxtDC_EditValueChanged(object sender, EventArgs e)
        {
            checkssdtBB();
        }

        private void LuuHDBB()
        {
            double giam = 0;
            if (!string.IsNullOrEmpty(BBtxtGiam.Text))
            {
                giam = Convert.ToDouble(BBtxtGiam.Text);
            }

            DateTime get = DateTime.Now;
            string mahd = "HD0" + (DH.Instance.DHtop1() + 1).ToString();
            //lưu cả 2 cho bán lẻ
            if (string.IsNullOrEmpty(BBtxtMakh.Text))

            {
                if (DH.Instance.insert(BBtxtHoTen.Text, BBtxtDC.Text, BBtxtPhone.Text, BBtxtEmail.Text, bbMaSp, Convert.ToInt32(BBtxtSL.Text), giam, bbMaNV))
                {
                    if (DH.Instance.insert2(BBtxtHoTen.Text, BBtxtDC.Text, BBtxtPhone.Text, BBtxtEmail.Text, bbMaSp, Convert.ToInt32(BBtxtSL.Text), giam, bbMaNV, 2))
                    {
                        string str = "<b> Mã hóa đơn :" + mahd + "\n<b> Lập vào ngày :  " + get.ToString("dd / MM / yyyy lúc HH:mm") + "\n<b> Lập bởi:  " + data.NV[bbMaNV].Hoten + "\n<b> Khách hàng: " + BBtxtHoTen.Text;

                        XtraMessageBox.Show("Đã lưu thành công hoá đơn bán buôn\n" + str, "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True);
                        makh = kh2.Instance.DHtop1().ToString();
                        if (SaveObj())
                        {
                            this.Close();
                        }
                    }
                }
            }
            //lưu sản hẩm cho hoá đơn
            else
            {
                if (DH.Instance.insertDH(bbMaSp, Convert.ToInt32(BBtxtSL.Text), giam, bbMaNV, BBtxtMakh.Text, 2))
                {
                    string str = "<b> Mã hóa đơn: " + mahd + "\n<b> Lập vào ngày: " + get.ToString("dd / MM / yyyy lúc HH:mm") + "\n<b> Lập bởi:</ b > " + data.NV[bbMaNV].Hoten + "\n<b> Khách hàng:</ b > " + BBtxtHoTen.Text;

                    XtraMessageBox.Show("Đã lưu lại hóa đơn này\n" + str, "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True);

                }
            }

        }

        private void linkLabel1_Click_1(object sender, EventArgs e)
        {
            BBtxtDC.Enabled = true;
            BBtxtEmail.Enabled = true;
            BBtxtHoTen.Enabled = true;
            BBtxtPhone.Enabled = true;
            BBtxtDC.Text = "";
            BBtxtEmail.Text = "";
            BBtxtHoTen.Text = "";
            BBtxtPhone.Text = "";
        }

        private void BBtxtEmail_EditValueChanged(object sender, EventArgs e)
        {
            checkssdtBB();
            // kiểm tra email nhập vào có hợp lệ hay ko
            string email = ((Control)sender).Text;
            if (String.IsNullOrEmpty(email))
            {
                epLoi.SetError((Control)sender, null);
                return;
            }
            if (!isEmail(email))
            {
                epLoi.SetError((Control)sender, "Email có định dạng không hợp lệ");
            }
            else
            {
                epLoi.SetError((Control)sender, null);

            }
        }
    }
}

