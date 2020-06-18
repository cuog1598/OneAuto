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

namespace QL_OneAuto.GUI
{
    public partial class TT_NV :  DevExpress.XtraEditors.XtraForm
    {
       
        public People NhanVien;
        public TT_NV()
        {
            InitializeComponent();
            //gridControl1.DataSource = DataProvider.Instance.ExecuteQuery("select * from DonHang where MaNV=" + NhanVien.Id);

        }
        void loadcbb()
        {
            comboBox2.DataSource = cListPeoPle.Instance.LoadCbb();
            comboBox2.DisplayMember = "TenLoai";
            comboBox2.ValueMember = "MaLoai";
          
        }
        public void SetData(People x)
        {
            try
            {
                // lấy dữ liệu từ đối tượng và set vào các textbox
                txtEmail.Text = x.Email;
                txtHoTen.Text = x.Hoten;
                txtMaNV.Text = x.Id.ToString();
                txtPhone.Text = x.Phone;
                txtNgaySinh.Text = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(x.Ngaysinh));
                txtDiaChi.Text = x.Diachi;

                comboBox2.Text = x.Tenloai;
            }
            catch { }
             
        }

        private void TT_NV_Shown(object sender, EventArgs e)
        {
            NhanVien.GetFullInfo();
            SetData(NhanVien);
            SetTextBoxEnabled(false);
        }
        private void SetTextBoxEnabled(bool enabled  )
        {
            comboBox2.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtHoTen.Enabled = enabled;
            txtNgaySinh.Enabled = enabled;
            txtPhone.Enabled = enabled;
        }

        private void txtNgaySinh_EditValueChanged(object sender, EventArgs e)
        {
            // kiểm tra ngày sinh nhập vào có hợp lệ hay ko
            DateTime ngaySinh =  txtNgaySinh.DateTime;
            if (ngaySinh >= DateTime.Now)
            {
                epLoi.SetError((Control)sender, "Ngày sinh không hợp lệ");
            }
            else
            {
                // kiểm tra nhân viên này đủ tuổi hợp tác lao động hay chưa (>= 16 tuổi)
                if (ngaySinh.AddYears(16) > DateTime.Now)
                {
                    epLoi.SetError(txtNgaySinh, "Nhân viên phải từ 16 tuổi trở lên");
                }
                else
                if (ngaySinh.Year <1900)
                {
                    epLoi.SetError(txtNgaySinh, "năm sinh không hợp lệ");
                }
                else
                {
                    epLoi.SetError(txtNgaySinh, null);
                    // bật biến bool đã thay đổi giá trị
                    
                }


            }
        }

        private void bgInfoNV_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            int a = Convert.ToInt32(comboBox2.SelectedValue);
            string tag = ((DevExpress.XtraBars.Docking2010.WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "edit":
                    // mở tính năng chỉnh sửa
                    SetTextBoxEnabled(true);
                    loadcbb();
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
                        
                            if (cListPeoPle.Instance.Update(txtHoTen.Text, txtPhone.Text, txtDiaChi.Text, txtEmail.Text, Convert.ToDateTime(txtNgaySinh.EditValue), txtMaNV.Text, a))
                            {
                            if (SaveObj())
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

        public People nhan;
        private bool SaveObj()
        {
            // Khởi tạo đối tượng NhanVien nếu chưa có
            nhan = new People();
            // Lấy họ tên đã được tách ra

            // Lưu vào obj
            nhan.Id = txtMaNV.Text;
            nhan.Phone = txtPhone.Text;
            nhan.Email = txtEmail.Text;
            nhan.Diachi = txtDiaChi.Text;
            nhan.Ngaysinh = txtNgaySinh.Text;
            nhan.Hoten = txtHoTen.Text;
            nhan.Tenloai = comboBox2.Text;
           // nhan.Ngaytao = txtNgaySinh.DateTime;
            //data.NV.Add(nhan);
            return true;

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
            if (String.IsNullOrEmpty(phone) || txtPhone.Text=="             " || txtPhone.Text.Length==13)
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
            if (!isPhone(txtPhone.Text) && !String.IsNullOrEmpty(txtPhone.Text) )
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
            if (String.IsNullOrEmpty(txtHoTen.Text))
            {
                txtHoTen.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(txtHoTen, "Tên nhân viên không được bỏ trống");
                isValid = false;
            }
            else
            {
                txtHoTen.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                epLoi.SetError(txtHoTen, null);
            }
            if (String.IsNullOrEmpty(txtMaNV.Text))
            {
                txtMaNV.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(txtMaNV, "Mã nhân viên không được bỏ trống");
                isValid = false;
            }
            
            
            // Kiểm tra giới tính có bị edit thành value khác "Nam, Nữ" hay ko?
             
            // kiểm tra ngày tháng năm sinh đối chiếu với hiện tại, tuổi >=  0 và <= 100
            DateTime ngSinh = txtNgaySinh.DateTime;
            if (ngSinh >= DateTime.Now)
            {
                txtNgaySinh.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(txtNgaySinh, "Ngày sinh của nhân viên không hợp lệ");
                isValid = false;
            }
            else
            {
                // kiểm tra nhân viên này đủ tuổi hợp tác lao động hay chưa (>= 16 tuổi)
                if (ngSinh.AddYears(16) > DateTime.Now)
                {
                    txtNgaySinh.Properties.Appearance.BorderColor = Color.Red;
                    epLoi.SetError(txtNgaySinh, "Nhân viên phải đủ 16 tuổi trở lên");
                    isValid = false;
                }
                else
                {
                    txtNgaySinh.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                    epLoi.SetError(txtNgaySinh, null);
                }
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
            if (! isEmail(email))
            {
                epLoi.SetError((Control)sender, "Email có định dạng không hợp lệ");
            }
            else
            {
                epLoi.SetError((Control)sender, null);
                
            }

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
