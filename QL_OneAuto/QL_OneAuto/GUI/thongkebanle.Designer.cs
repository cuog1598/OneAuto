namespace QL_OneAuto.GUI
{
    partial class thongkebanle
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaDH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiaTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiamGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThanhTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.listTheoNgayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rDataSet2 = new QL_OneAuto.rDataSet2();
            this.listTheoNgayTableAdapter = new QL_OneAuto.rDataSet2TableAdapters.listTheoNgayTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listTheoNgayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXem
            // 
            this.btnXem.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnXem.Appearance.Options.UseFont = true;
            this.btnXem.Location = new System.Drawing.Point(578, 18);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(99, 28);
            this.btnXem.TabIndex = 33;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(307, 22);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 21);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "Chọn năm :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(32, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 21);
            this.labelControl1.TabIndex = 30;
            this.labelControl1.Text = "Chọn tháng:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(134, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 35;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(416, 22);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 36;
            this.comboBox2.Click += new System.EventHandler(this.comboBox2_Click);
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaDH,
            this.colTenSP,
            this.colSDT,
            this.colTenKH,
            this.colDiaChi,
            this.colNgayNhap,
            this.colSL,
            this.colGiaTien,
            this.colGiamGia,
            this.colThanhTien,
            this.colTenNV});
            this.gridView1.DetailHeight = 360;
            this.gridView1.FooterPanelHeight = 30;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupRowHeight = 30;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 30;
            this.gridView1.ViewCaptionHeight = 30;
            // 
            // colMaDH
            // 
            this.colMaDH.Caption = "Mã đơn hàng";
            this.colMaDH.FieldName = "MaDH";
            this.colMaDH.Name = "colMaDH";
            this.colMaDH.Visible = true;
            this.colMaDH.VisibleIndex = 0;
            this.colMaDH.Width = 70;
            // 
            // colTenSP
            // 
            this.colTenSP.Caption = "Tên sản phẩm";
            this.colTenSP.FieldName = "TenSP";
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.Visible = true;
            this.colTenSP.VisibleIndex = 1;
            this.colTenSP.Width = 95;
            // 
            // colSDT
            // 
            this.colSDT.Caption = "SĐT";
            this.colSDT.FieldName = "SDT";
            this.colSDT.Name = "colSDT";
            this.colSDT.Visible = true;
            this.colSDT.VisibleIndex = 4;
            this.colSDT.Width = 89;
            // 
            // colTenKH
            // 
            this.colTenKH.Caption = "Tên khách hàng";
            this.colTenKH.FieldName = "TenKH";
            this.colTenKH.Name = "colTenKH";
            this.colTenKH.Visible = true;
            this.colTenKH.VisibleIndex = 2;
            this.colTenKH.Width = 117;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Caption = "Địa chỉ";
            this.colDiaChi.FieldName = "DiaChi";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 3;
            this.colDiaChi.Width = 91;
            // 
            // colNgayNhap
            // 
            this.colNgayNhap.Caption = "ngày nhập";
            this.colNgayNhap.FieldName = "NgayNhap";
            this.colNgayNhap.Name = "colNgayNhap";
            this.colNgayNhap.Visible = true;
            this.colNgayNhap.VisibleIndex = 5;
            this.colNgayNhap.Width = 91;
            // 
            // colSL
            // 
            this.colSL.Caption = "Số lượng";
            this.colSL.FieldName = "SL";
            this.colSL.Name = "colSL";
            this.colSL.Visible = true;
            this.colSL.VisibleIndex = 7;
            this.colSL.Width = 91;
            // 
            // colGiaTien
            // 
            this.colGiaTien.Caption = "Giá tiền";
            this.colGiaTien.FieldName = "GiaTien";
            this.colGiaTien.Name = "colGiaTien";
            this.colGiaTien.Visible = true;
            this.colGiaTien.VisibleIndex = 6;
            this.colGiaTien.Width = 91;
            // 
            // colGiamGia
            // 
            this.colGiamGia.FieldName = "GiamGia";
            this.colGiamGia.Name = "colGiamGia";
            this.colGiamGia.Visible = true;
            this.colGiamGia.VisibleIndex = 8;
            this.colGiamGia.Width = 91;
            // 
            // colThanhTien
            // 
            this.colThanhTien.Caption = "Thành tiền";
            this.colThanhTien.FieldName = "ThanhTien";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.Visible = true;
            this.colThanhTien.VisibleIndex = 9;
            this.colThanhTien.Width = 91;
            // 
            // colTenNV
            // 
            this.colTenNV.Caption = "Nhân viên nhập";
            this.colTenNV.FieldName = "TenNV";
            this.colTenNV.Name = "colTenNV";
            this.colTenNV.Visible = true;
            this.colTenNV.VisibleIndex = 10;
            this.colTenNV.Width = 114;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.listTheoNgayBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gridControl1.Location = new System.Drawing.Point(0, 90);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1049, 289);
            this.gridControl1.TabIndex = 23;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // listTheoNgayBindingSource
            // 
            this.listTheoNgayBindingSource.DataMember = "listTheoNgay";
            this.listTheoNgayBindingSource.DataSource = this.rDataSet2;
            // 
            // rDataSet2
            // 
            this.rDataSet2.DataSetName = "rDataSet2";
            this.rDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listTheoNgayTableAdapter
            // 
            this.listTheoNgayTableAdapter.ClearBeforeFill = true;
            // 
            // thongkebanle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "thongkebanle";
            this.Size = new System.Drawing.Size(1049, 379);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listTheoNgayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDH;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSP;
        private DevExpress.XtraGrid.Columns.GridColumn colSDT;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKH;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayNhap;
        private DevExpress.XtraGrid.Columns.GridColumn colSL;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaTien;
        private DevExpress.XtraGrid.Columns.GridColumn colGiamGia;
        private DevExpress.XtraGrid.Columns.GridColumn colThanhTien;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNV;
        private System.Windows.Forms.BindingSource listTheoNgayBindingSource;
        private rDataSet2 rDataSet2;
        private rDataSet2TableAdapters.listTheoNgayTableAdapter listTheoNgayTableAdapter;
    }
}
