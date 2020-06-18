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
    public partial class ThemNhanVien :DevExpress.XtraEditors.XtraForm
    {
        public People NhanVien;
        public ThemNhanVien()
        {
            InitializeComponent();
            comboBox2.DataSource = cListPeoPle.Instance.LoadCbb();
            comboBox2.DisplayMember = "TenLoai";
            comboBox2.ValueMember = "MaLoai";
            
             
        }
        bool isPhone(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phone, "^[0-9]{7,13}$");
        }

        public void SetData(People x)
        {
            // lấy dữ liệu từ đối tượng và set vào các textbox
            x.Email=txtEmail.Text;


             x.Id = txtMaNV.Text;
            x.Phone= txtPhone.Text ;
             x.Ngaysinh = txtNgaySinh.Text;
             x.Diachi= txtDiaChi.Text ;
             x.Tenloai= comboBox2.Text ;
             x.Hoten= txtHoTen.Text ;
        }
        private void txtPhone_EditValueChanged(object sender, EventArgs e)
        {
            // kiểm tra số điện thoại nhập vào có chính xác hay ko
            // số điện thoại chính xác phải từ 7 đến 11 ký tự và ko có ký tự khác số
            string phone = ((Control)sender).Text;
            // nếu rỗng hoặc null thì ko kiểm tra
            if (String.IsNullOrEmpty(phone) )
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
            if (String.IsNullOrEmpty(txtHoTen.Text))
            {
                txtHoTen.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(txtHoTen, "Tên nhân viên không được bỏ trống");
                isValid = false;
            }
            else
            {

                if (!(String.IsNullOrEmpty(data.KH[txtMaNV.Text].Id)))
                {
                    txtMaNV.Properties.Appearance.BorderColor = Color.Red;
                    isValid = false;
                    epLoi.SetError(txtMaNV, "Mã số nhân viên đã tồn tại");
                }
                txtHoTen.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                epLoi.SetError(txtHoTen, null);
            }
            if (String.IsNullOrEmpty(txtMaNV.Text))
            {
                txtMaNV.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(txtMaNV, "Mã nhân viên không được bỏ trống");
                isValid = false;
            }

            if (String.IsNullOrEmpty(txtNgaySinh.Text))
            {
                txtMaNV.Properties.Appearance.BorderColor = Color.Red;
                epLoi.SetError(txtNgaySinh, "ngày sinh không được bỏ trống");
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

        private void bgInfoNV_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((DevExpress.XtraBars.Docking2010.WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "close":
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
                        insert();
                        
                        this.Close();
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
            nhan.Ngaytao= DateTime.Now;
            //data.NV.Add(nhan);
            return true;
            
        }

        private void insert()
        {
                    DateTime a = Convert.ToDateTime(txtNgaySinh.EditValue);
            if (SaveObj())
            {
                if (cListPeoPle.Instance.insert(txtHoTen.Text, txtPhone.Text, txtDiaChi.Text, txtEmail.Text, a, txtMaNV.Text, Convert.ToInt32(comboBox2.SelectedValue)))
                {

                    XtraMessageBox.Show("Lưu thành công thông tin nhân viên", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
                
            
        }
        private void txtMaNV_EditValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNV.Text)) return;
            
            if (!(String.IsNullOrEmpty(data.KH[txtMaNV.Text].Id)))
            {
                txtMaNV.Properties.Appearance.BorderColor = Color.Red;
                
                epLoi.SetError(txtMaNV, "Mã số nhân viên đã tồn tại");
            }
             
            else
            {
                txtMaNV.Properties.Appearance.BorderColor = SystemColors.ActiveBorder;
                epLoi.SetError(txtMaNV, null);
            }
        }

        private void txtNgaySinh_EditValueChanged(object sender, EventArgs e)
        {
            // kiểm tra ngày sinh nhập vào có hợp lệ hay ko
            DateTime ngaySinh = txtNgaySinh.DateTime;
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
                    if (ngaySinh.Year < 1900)
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
        //kiểm tra định dạng email
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
    }
}
