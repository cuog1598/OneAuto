using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_OneAuto.DAO;

namespace QL_OneAuto.GUI
{
    public partial class TTDL : DevExpress.XtraEditors.XtraForm
    {
        public bool type = false;
        public DaiLyDTO daily;

        public TTDL()
        {
            InitializeComponent();
           
        }
        bool isPhone(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phone, "^[0-9]{7,13}$");
        }
        private void txtPhone_EditValueChanged(object sender, EventArgs e)
        {


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
                // bật biến bool đã thay đổi giá trị

            }


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
                epLoi.SetError(txtPhone, null);
                txtPhone.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
            }

            // Kiểm tra tên và id có bị null hay ko
            if (String.IsNullOrEmpty(txtTenNhanVien.Text))
            {
                TxtTenDaiLy.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(txtTenNhanVien, "Tên nhân viên không được bỏ trống");
                isValid = false;
            }
            else
            {
                txtTenNhanVien.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                epLoi.SetError(txtTenNhanVien, null);
            }
            if (String.IsNullOrEmpty(txtMaDL.Text))
            {
                txtMaDL.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(txtMaDL, "Mã đại lý không được để trống");
                isValid = false;
            }
            else
            {
                txtMaDL.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                epLoi.SetError(txtMaDL, null);
            }

            if (String.IsNullOrEmpty(TxtTenDaiLy.Text))
            {
                txtMaDL.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(TxtTenDaiLy, "tên đại lý không được để trống");
                isValid = false;
            }
            else
            {
                TxtTenDaiLy.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                epLoi.SetError(TxtTenDaiLy, null);
            }
            if (String.IsNullOrEmpty(txtPhone.Text))
            {
                txtPhone.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(txtPhone, "Số điện thoại không được bỏ trống");
                isValid = false;
            }
            else
            {
                txtPhone.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                epLoi.SetError(txtPhone, null);
            }
            return isValid;
        }
        static public bool isEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        private void txtEmail_EditValueChanged(object sender, EventArgs e)
        {


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
        private string madl;
        public void SetData(DaiLyDTO x)
        {
            try
            {
                // lấy dữ liệu từ đối tượng và set vào các textbox
                madl = x.Madl;
                TxtTenDaiLy.Text = x.Tendaily;
                txtMaDL.Text = x.Madl.ToString();
                txtPhone.Text = x.Sdt;
                txtDiaChi.Text = x.Diachi;
                txCHuDAiLy.Text = x.Tenchudaily.ToString();
                txtTenNhanVien.Text = x.Tennv;

            }
            catch { }

        }

        private void SetTextBoxEnabled(bool enabled)
        {
            TxtTenDaiLy.Enabled = enabled;
            txCHuDAiLy.Enabled = enabled;
            txtTenNhanVien.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtPhone.Enabled = enabled;
        }
        private void TTDL_Shown(object sender, EventArgs e)
        {
            
        }

        private void bgInfoNV_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((DevExpress.XtraBars.Docking2010.WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "edit":
                    // mở tính năng chỉnh sửa
                    SetTextBoxEnabled(true);
                    // ẩn button chỉnh sửa, mở các button save
                    for (int i = 0; i < bgInfoNV.Buttons.Count; i++)
                    {
                        string btntag = bgInfoNV.Buttons[i].Properties.Tag.ToString();
                        if (btntag == "edit") bgInfoNV.Buttons[i].Properties.Visible = false;
                        if (btntag == "save") bgInfoNV.Buttons[i].Properties.Visible = true;
                    }
                    break;
                case "close":
                    // thoát
                    this.Close();
                    break;
                case "save":
                    // lưu lại thông tin
                    // Kiểm tra các input có thỏa hay ko
                    if (!isInputValid())
                    {
                        XtraMessageBox.Show("Vui lòng kiểm tra các giá trị nhập vào, một số giá trị không hợp lệ nên không thể lưu thông tin", "Lưu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    else
                    {
                        if (type == true)
                        {
                            themDL();
                            this.Close();
                        }
                        else
                        {
                            if (update())
                            {
                                if (XtraMessageBox.Show("Lưu thành công thông tin nhân viên", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                {
                                    SetTextBoxEnabled(false);
                                    for (int i = 0; i < bgInfoNV.Buttons.Count; i++)
                                    {
                                        string btntag = bgInfoNV.Buttons[i].Properties.Tag.ToString();
                                        if (btntag == "edit") bgInfoNV.Buttons[i].Properties.Visible = true;
                                        if (btntag == "save") bgInfoNV.Buttons[i].Properties.Visible = false;
                                    }

                                }
                            }
                        }
                    }
       
            break;
        
            }
        }

        private bool update()
        {
            if (DaiLy.Instance.Update(txtMaDL.Text, txCHuDAiLy.Text, txtDiaChi.Text, txtPhone.Text, TxtTenDaiLy.Text, txtEmail.Text))
            {
                if (SaveObj())
                {
                    return true;
                }
                return true;
            }
            else return false;
        }

        public DaiLyDTO nhan;
        private bool SaveObj()
        {
            // Khởi tạo đối tượng NhanVien nếu chưa có
            nhan = new DaiLyDTO();
            // Lấy họ tên đã được tách ra
            // Lưu vào obj
            nhan.Madl = txtMaDL.Text;
            nhan.Sdt = txtPhone.Text;
            //nhan.Email = txtEmail.Text;
            nhan.Diachi = txtDiaChi.Text;
            nhan.Tenchudaily = txCHuDAiLy.Text;
            nhan.Tendaily = TxtTenDaiLy.Text;
            nhan.Tennv = txtTenNhanVien.Text;
            //data.NV.Add(nhan);
            return true;

        }

        void themDL()
        {
            if(
            DaiLy.Instance.insert(txtMaDL.Text,manv,txCHuDAiLy.Text,txtDiaChi.Text,txtPhone.Text,TxtTenDaiLy.Text,txtEmail.Text))
            {
                if (SaveObj())
                {
                    XtraMessageBox.Show("cập nhật thông tin đại lý thành công", "Thông báo!", MessageBoxButtons.OK);
                   
                }
               
            }
           
        }

 

        private void TTDL_Load(object sender, EventArgs e)
        {
            if (type)
            {
                SetTextBoxEnabled(true);
                txtMaDL.Enabled = true;
               
                
                // set title cho form
                lbTitle.Text = "Tạo mới đại lý";
                // Ẩn lịch làm
                txtNV.Visible = true;
                // hide, show các button close và save trong group
                for (int i = 0; i < bgInfoNV.Buttons.Count; i++)
                {
                    string tag = bgInfoNV.Buttons[i].Properties.Tag.ToString();
                    if ( tag == "save")
                    {
                        bgInfoNV.Buttons[i].Properties.Visible = true;
                    }
                    else
                    bgInfoNV.Buttons[i].Properties.Visible = false;
                }
            }
            else
            {
                tabNavigationPage1.PageVisible = true;
                lbTitle.Text = "Thông tin đại lý";
                SetData(daily);
            }
          
        }
 

        private void txtNV_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            chonnv();
        }
        string manv;
        People nhanvien = new People();
        private void chonnv()
        {
            using (var f1 = new ChonNhanVien())
            {

                f1.ID_Choose = nhanvien.Id;
                var result = f1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(f1.ID_Choose))
                    {
                        nhanvien.Id = f1.ID_Choose;
                        txtTenNhanVien.Text = data.NV[nhanvien.Id].Hoten;
                        manv = nhanvien.Id;
                    }
                    else
                    {
                        MessageBox.Show("k có");
                    }
                }
            }

        }

        private void txtMaDL_EditValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaDL.Text)) return;

            if (!(String.IsNullOrEmpty(data.DL[txtMaDL.Text].Madl)))
            {
                txtMaDL.Properties.Appearance.BorderColor = Color.Red;

                epLoi.SetError(txtMaDL, "Mã đại lý này đã tồn tại. nhập mã khác");
            }

            else
            {
                txtMaDL.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                epLoi.SetError(txtMaDL, null);
            }
        }
    }
}
