using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Dall_Ball;
using Dall_Ball.DTO;
using Excel = Microsoft.Office.Interop.Excel;


namespace SHOPKID
{
    public partial class NhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        NhanVien_Dall_Ball nv = new NhanVien_Dall_Ball();

        bool add = false, update = false;

        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            //Load DataGrid
            loadcomboxGioiTinh();
            loadcomboxchucvu();
            loaddulieunv();
            hienthi(true);
            dateNgaySinh.EditValue = DateTime.Now;

            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnIn.Enabled = true;
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();
            binds(true);


        }
        public void loaddulieunv()
        {
            dsNhanVien.DataSource = nv.loaddulieunhanvien();
        }

        public void binds(bool t)

        {
            if (t)
            {
                txtMaNV.DataBindings.Clear();
                txtMaNV.DataBindings.Add("Text", dsNhanVien.DataSource, "MANV");
                txtTenNV.DataBindings.Clear();
                txtTenNV.DataBindings.Add("Text", dsNhanVien.DataSource, "TenNV");
                txtSocmnd.DataBindings.Clear();
                txtSocmnd.DataBindings.Add("Text",dsNhanVien.DataSource,"SoCMND");
                dateNgaySinh.DataBindings.Clear();
                dateNgaySinh.DataBindings.Add("Text", dsNhanVien.DataSource, "NgaySinh");
                cboChucVu.DataBindings.Clear();
                cboChucVu.DataBindings.Add("Text", dsNhanVien.DataSource, "TenCv");
                txtDiachi.DataBindings.Clear();
                txtDiachi.DataBindings.Add("Text", dsNhanVien.DataSource, "DiaChi");
                txtSdt.DataBindings.Clear();
                txtSdt.DataBindings.Add("Text", dsNhanVien.DataSource, "SDT");
                cboChucVu.DataBindings.Clear();
                cboChucVu.DataBindings.Add("Text",dsNhanVien.DataSource,"TenCV");
            }
            else
            {
                txtMaNV.DataBindings.Clear();
                txtTenNV.DataBindings.Clear();
                txtSocmnd.DataBindings.Clear();
                dateNgaySinh.DataBindings.Clear();
                txtDiachi.DataBindings.Clear();
                txtSdt.DataBindings.Clear();
                cboChucVu.DataBindings.Clear();

            }




        }

        public void hienthi(bool t)
        {
            if (t)
            {
                rdNam.Enabled = false;
                rdNu.Enabled = false;
                txtMaNV.Enabled = false;
                txtSdt.Enabled = false;
                dateNgaySinh.Enabled = false;
                txtDiachi.Enabled = false;               
                txtTenNV.Enabled = false;
                btnLuu.Enabled = false;
                txtSocmnd.Enabled = false;
                cboChucVu.Enabled = false;
                

            }
            else
            {
                cboChucVu.Enabled = true;
                rdNam.Enabled = true;
                rdNu.Enabled = true;
                txtSocmnd.Enabled = true;
                txtSdt.Enabled = true;
                dateNgaySinh.Enabled = true;
                txtDiachi.Enabled = true;
                txtTenNV.Enabled = true;
                btnLuu.Enabled = true;

            }
        }

        public void resetValues()
        {


            txtSdt.Text = "";
            //CboGioiTinh.SelectedIndex = 0;
            //cboChucVu.SelectedIndex = 0;
            txtTenNV.Text = "";
            txtMaNV.Text = "";
            txtDiachi.Text = "";
            txtSocmnd.Text = "";
            dateNgaySinh.EditValue = DateTime.Now.ToShortDateString();

        }
        public void loadcomboxchucvu()
        {
            cboChucVu.DataSource = nv.LoadChucVu();
            cboChucVu.DisplayMember = "Tencv";
            cboChucVu.ValueMember = "Macv";
        }

        public void loadcomboxGioiTinh()
        {
            
               
            
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                resetValues();
                hienthi(false);
                add = true;
                update = false;
                binds(false);
                btnLuu.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnIn.Enabled = false;
                btnThem.Enabled = false;
                if (gridView1.RowCount <= 0)
                {
                    txtMaNV.Text = "NV001";
                }
                else
                    txtMaNV.Text = nv.getmaNhanVien(txtMaNV.Text);
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!");
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                update = true;
                add = false;
                hienthi(false);
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
                btnIn.Enabled = false;
                btnSua.Enabled = false;
                binds(false);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!");

            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount <= 0)
                {
                    XtraMessageBox.Show("Không có nhân viên");
                    return;
                }


                if (XtraMessageBox.Show("Bạn có muốn Xóa", "Đồng Ý Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<string> dsmahoadonxuat = new List<string>();
                    dsmahoadonxuat = nv.mahdxuattheonv(txtMaNV.Text);
                    List<string> dsmahoadonnhap = new List<string>();


                    //for (int i = 0; i < dsmahoadonxuat.Count; i++)
                    //{
                    //    hdxuat.xoa1chitethoadonall(dsmahoadonxuat[i].ToString());
                    //    hdxuat.xoa1HoadonNhap(dsmahoadonxuat[i].ToString());
                    //}

                    nv.xoa1NhanVien(txtMaNV.Text);

                    XtraMessageBox.Show("Thành công");
                    NhanVien_Load(sender, e);
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!");
            }
            
        }


        public bool kiemtradulieuhop()
        {
            if (txtTenNV.Text == string.Empty)
            {
                XtraMessageBox.Show("Tên Nhân Viên Không Để Trống");
                return false;
            }
            if (txtDiachi.Text == string.Empty)
            {
                XtraMessageBox.Show("Địa Chỉ Không Để Trống");
                return false;
            }
            if (txtSdt.Text == string.Empty)
            {

                XtraMessageBox.Show("Số Điện Thoại Không Để Trống");
                return false;
            }
            if (!kiemtrasso(txtSocmnd.Text))
            {
                XtraMessageBox.Show("Nhập số cho Chứng minh nhân dân");
                return false;
            }
           
            if (!kiemtrasso(txtSdt.Text))
            {
                XtraMessageBox.Show("Nhập Số Cho Thông Tin Điện Thoại");
                return false;
            }
            return true;
        }
        public bool kiemtrasso(string x)
        {
            int a = 0;
            bool t = int.TryParse(x, out a);
            if (t)
            {
                return true;
            }
            else
                return false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSocmnd.Text.Length != 9)
                {
                    XtraMessageBox.Show("Bạn phải nhập đúng độ dài số CMND là 9 số");
                    return;
                }
                else if (txtSdt.Text.Length!=10)
                {
                    XtraMessageBox.Show("Bạn phải nhập đúng độ dài số điện thoại là 10 số");
                    return;
                }
                string gioitinh = "";
                if (rdNam.Checked)
                {
                    gioitinh = "Nam";
                }
                else
                {
                    gioitinh = "Nữ";
                }
                DateTime ns = DateTime.Parse(dateNgaySinh.EditValue.ToString());
                DateTime nvl = DateTime.Parse(dateNgaySinh.EditValue.ToString());
                if (add)
                {
                    if (kiemtradulieuhop())
                    {

                        if (XtraMessageBox.Show("Bạn có muốn  thêm  nhân viên này", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            nv.them1NhanVien(txtMaNV.Text, txtTenNV.Text, ns, txtDiachi.Text, txtSdt.Text, gioitinh
                            , txtSocmnd.Text, cboChucVu.SelectedValue.ToString());
                            XtraMessageBox.Show("Thêm Thành công");
                            NhanVien_Load(sender, e);
                        }

                    }

                }
                if (update)
                {
                    if (kiemtradulieuhop())
                    {

                        if (XtraMessageBox.Show("Bạn có muốn  sửa nhân viên này", "Đồng Ý Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            nv.sua1NhanVien(txtMaNV.Text, txtTenNV.Text, ns, txtDiachi.Text, txtSdt.Text, gioitinh
                            , txtSocmnd.Text, cboChucVu.SelectedValue.ToString());
                            XtraMessageBox.Show("Sửa Thành công");
                            NhanVien_Load(sender, e);
                        }

                    }
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!");
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            NhanVien_Load(sender, e);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;





            workbook = application.Workbooks.Add(Type.Missing);
            application.Visible = true;
            application.WindowState = Excel.XlWindowState.xlMaximized;
            //getdatabase   
            workbook.Worksheets.Add();
            worksheet = workbook.Sheets[1];



            worksheet.Cells[1, 1] = "Thông Tin Nhân Viên";
            worksheet.Cells[3, 1] = "STT";
            worksheet.Cells[3, 2] = "Mã Nhân Viên";
            worksheet.Cells[3, 3] = "Tên Nhân Viên";
            worksheet.Cells[3, 4] = "Giới Tính";
            worksheet.Cells[3, 5] = "Ngày Sinh";
            worksheet.Cells[3, 6] = "Số CMND";
            worksheet.Cells[3, 7] = "Số điện thoại";
            worksheet.Cells[3, 8] = "Địa Chỉ";
            worksheet.Cells[3, 9] = "Chức vụ";



            List<NhanVienDTO> k = new List<NhanVienDTO>();
            k = nv.dsnhanvien();

            for (int i = 0; i < k.Count; i++)
            {
                worksheet.Cells[i + 4, 1] = i + 1;
                worksheet.Cells[i + 4, 2] = k[i].Manv1;
                worksheet.Cells[i + 4, 3] = k[i].Tennv1;
                worksheet.Cells[i + 4, 4] = k[i].Gioitinh1;
                worksheet.Cells[i + 4, 5] = k[i].Ngaysinh1;
                worksheet.Cells[i + 4, 6] = k[i].Socmnd1;
                worksheet.Cells[i + 4, 7] = k[i].Sdt1;
                worksheet.Cells[i + 4, 8] = k[i].Diachi1;
                worksheet.Cells[i + 4, 9] = k[i].Tencv1;

            }
            // định dạng trang
            worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
            worksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            worksheet.PageSetup.LeftMargin = 0;
            worksheet.PageSetup.RightMargin = 0;
            worksheet.PageSetup.BottomMargin = 0;
            worksheet.PageSetup.TopMargin = 0;

            //định dạng cột

            worksheet.Range["A1", "K100"].Font.Name = "Times New Roman";
            worksheet.Range["A1", "K100"].Font.Size = 14;
            worksheet.Range["A1", "K1"].MergeCells = true;
            worksheet.Range["A1", "K3"].Font.Bold = true;

            // kẻ bảng
            worksheet.Range["A3", "I" + (k.Count + 3)].Borders.LineStyle = 1;


            // định dạng các dòng
            worksheet.Range["A1", "K1"].HorizontalAlignment = 3;
            worksheet.Range["A3", "K3"].HorizontalAlignment = 3;
            worksheet.Range["A4", "K4" + k.Count.ToString()].HorizontalAlignment = 3;

            worksheet.Columns.AutoFit();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string gioitinh = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GioiTinh").ToString();
            if (gioitinh == "Nam")
            {
                rdNam.Checked = true;

            }
            else
            {
                rdNu.Checked = true;

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ChucVu cv = new ChucVu();
            
            cv.ShowDialog();
        }
    }
}
