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
    public partial class KhachHang : DevExpress.XtraEditors.XtraUserControl
    {
        KhachHang_Dall_Ball kh = new KhachHang_Dall_Ball();
        bool add = false, update = false;

        public KhachHang()
        {
            InitializeComponent();
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            loadview();
            hienthi(true);
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            bind(true);

            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();
            bind(true);
        }
        public void hienthi(bool t)
        {
            if (t)
            {
                rdNam.Enabled = false;
                rdNu.Enabled = false;
                txtMaKH.Enabled = false;
                txtSDT.Enabled = false;
               
                txtDiaChi.Enabled = false;
                txtTenKH.Enabled = false;
                btnLuu.Enabled = false;
             



            }
            else
            {

                rdNam.Enabled = true;
                rdNu.Enabled = true;
               
                txtSDT.Enabled = true;
          
                txtDiaChi.Enabled = true;
                txtTenKH.Enabled = true;
                btnLuu.Enabled = true;

            }
        }

        public void loadview()
        {

            dsKhachHang.DataSource = kh.getdskhachhang();

        }

        public void bind(bool t)
        {
            if (t)
            {
                txtMaKH.DataBindings.Clear();
                txtMaKH.DataBindings.Add("Text", dsKhachHang.DataSource, "MAKH");
                txtTenKH.DataBindings.Clear();
                txtTenKH.DataBindings.Add("Text", dsKhachHang.DataSource, "TenKH");
                txtDiaChi.DataBindings.Clear();
                txtDiaChi.DataBindings.Add("Text", dsKhachHang.DataSource, "DiaChi");
                txtSDT.DataBindings.Clear();
                txtSDT.DataBindings.Add("Text", dsKhachHang.DataSource, "SDT");
                
            }
            else
            {
                txtMaKH.DataBindings.Clear();
                txtTenKH.DataBindings.Clear();
                txtDiaChi.DataBindings.Clear();
                txtSDT.DataBindings.Clear();
               

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GioiTinh").ToString() == "Nam")

                    rdNam.Checked = true;


                else

                {
                    rdNu.Checked = true;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                hienthi(false);
                //txtMaKhachHang.Enabled = false;
                add = false;
                update = true;
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                bind(false);
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!");
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                txtDiaChi.Text = "";
                bind(false);
                hienthi(false);

                txtSDT.Text = "";
                txtDiaChi.Text = "";

                txtTenKH.Text = "";
                txtMaKH.Text = "";
                btnLuu.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnThem.Enabled = false;


                if (gridView1.RowCount <= 0)
                {
                    txtMaKH.Text = "KH001";

                }
                else
                {
                    txtMaKH.Text = kh.getmakhachhang("KH00");
                }
                bind(false);
                add = true;
                update = false;
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!");
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            KhachHang_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string gioitinh = "";

                if (rdNam.Checked)
                {
                    gioitinh = "Nam";
                }
                else
                    gioitinh = "Nữ";
                //DateTime ngaysinh = DateTime.Parse(dateNgaySinh.EditValue.ToString());
                if (txtTenKH.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Không Được Bỏ Trống Tên Khách Hàng");
                    return;

                }
                else if (txtSDT.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Không Được Bỏ Trống SĐT");
                    return;
                }
                //else if (txtSoCMND.Text.Length <= 0)
                //{
                //    XtraMessageBox.Show("Không được bỏ trống số CMND");
                //}
                else if (!kiemtraso(txtSDT.Text))
                {
                    XtraMessageBox.Show("Bạn phải nhập số tại mục số điện thoại");
                    return;
                }
                else if(txtSDT.Text.Length!=10)
                {
                    XtraMessageBox.Show("Bạn phải nhập đúng độ dài số điện thoại là 10 số");
                    return;
                }
                //else if (!kiemtraso(txtSoCMND.Text))
                //{
                //    XtraMessageBox.Show("Bạn phải nhập số tại mục số chứng minh nhân dân");
                //}
                if (add)
                {



                    DialogResult rs;
                    rs = XtraMessageBox.Show("Bạn có muốn thêm  không", "Đồng ý thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (rs == DialogResult.Yes)
                    {

                        kh.them1khachhang(txtMaKH.Text, txtTenKH.Text, txtSDT.Text, txtDiaChi.Text, gioitinh);
                        XtraMessageBox.Show("Thêm Thành Công");
                        KhachHang_Load(sender, e);
                    }


                }
                if (update)
                {

                    DialogResult rs;
                    rs = XtraMessageBox.Show("Bạn có muốn sửa  không", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (rs == DialogResult.Yes)
                    {

                        kh.sua1KhachHang(txtMaKH.Text, txtTenKH.Text, txtSDT.Text, txtDiaChi.Text, gioitinh);
                        XtraMessageBox.Show("Sửa Thành Công");
                        KhachHang_Load(sender, e);

                    }
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!");
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có muốn Xóa", "Đồng Ý Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<string> madh = new List<string>();
                    kh.xoa1KhachHang(txtMaKH.Text);
                    XtraMessageBox.Show("Xóa Thành công");
                    KhachHang_Load(sender, e);
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!");
            }
           
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



            worksheet.Cells[1, 1] = "Thông Tin Khách Hàng";
            worksheet.Cells[3, 1] = "STT";
            worksheet.Cells[3, 2] = "Mã Khách Hàng";
            worksheet.Cells[3, 3] = "Tên Khách Hàng";
            worksheet.Cells[3, 4] = "Giới Tính";
            //worksheet.Cells[3, 5] = "Ngày Sinh";
            worksheet.Cells[3, 5] = "Số Điện Thoại";
            //worksheet.Cells[3, 7] = "Số CMND";
            worksheet.Cells[3, 6] = "Địa Chỉ";



            List<KhachHangDTO> k = new List<KhachHangDTO>();
            k = kh.GetkhAll();

            for (int i = 0; i < k.Count; i++)
            {
                worksheet.Cells[i + 4, 1] = i + 1;
                worksheet.Cells[i + 4, 2] = k[i].Makh1;
                worksheet.Cells[i + 4, 3] = k[i].Tenkh1;
                worksheet.Cells[i + 4, 4] = k[i].Gioitinh1;
                //worksheet.Cells[i + 4, 5] = k[i].Ngaysinh1;
                worksheet.Cells[i + 4, 5] = k[i].Sdt1;
                //worksheet.Cells[i + 4, 7] = k[i].Socmnd1;
                worksheet.Cells[i + 4, 6] = k[i].Diachi1;




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
            worksheet.Range["A3", "H" + (k.Count + 3)].Borders.LineStyle = 1;


            // định dạng các dòng
            worksheet.Range["A1", "K1"].HorizontalAlignment = 3;
            worksheet.Range["A3", "K3"].HorizontalAlignment = 3;
            worksheet.Range["A4", "K4" + k.Count.ToString()].HorizontalAlignment = 3;

            worksheet.Columns.AutoFit();
        }

        public bool kiemtraso(string x)
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
    }
}
