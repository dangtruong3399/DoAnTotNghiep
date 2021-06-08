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
namespace SHOPKID
{
    public partial class HoaDonBanHang : DevExpress.XtraEditors.XtraUserControl
    {
        BanHang_Dall_Ball bh = new BanHang_Dall_Ball();

        public HoaDonBanHang()
        {
            InitializeComponent();
        }

        private void HoaDonBanHang_Load(object sender, EventArgs e)
        {
            txtDiaChi.Enabled = false;
            txtMaHD.Enabled = false;
            txtNhanVien.Enabled = false;
            dateNgayHD.Enabled = false;
            txtSoDT.Enabled = false;
            txtTenKH.Enabled = false;
            LoadHDBH();

        }
        public void LoadHDBH()
        {
            GirdHD.DataSource = bh.getAllHoadon();
            GirdHD.Refresh();
          
        }

        public void LoadChitiethd()
        {
            gridCTHD.DataSource = bh.getAllCTHoaDon(txtMaHD.Text);
        }

        private void gridViewHD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {

           
                if ( gridViewHD.RowCount> 0)
                {
                    txtMaHD.Text = gridViewHD.GetRowCellValue(gridViewHD.FocusedRowHandle,"MaHD").ToString();
                    dateNgayHD.Text = gridViewHD.GetRowCellValue(gridViewHD.FocusedRowHandle, "NgayLapHD").ToString();
                    txtNhanVien.Text= gridViewHD.GetRowCellValue(gridViewHD.FocusedRowHandle, "TenNV").ToString();
                    txtTenKH.Text = gridViewHD.GetRowCellValue(gridViewHD.FocusedRowHandle, "TenKH").ToString();
                    string makh = gridViewHD.GetRowCellValue(gridViewHD.FocusedRowHandle, "MaKH").ToString();
                    txtSoDT.Text = bh.getSDTKh(makh);
                    txtDiaChi.Text = bh.getDiaChiKh(makh);

                    Load_CTHD();
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!");
            }

        }
        public void Load_CTHD()
        {
            gridCTHD.DataSource = bh.getAllCTHoaDon(txtMaHD.Text);
            gridCTHD.Refresh();
        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

            
            if(txtTimKiem.Text.Length>0)
            {
                GirdHD.DataSource = bh.getIDHD(txtTimKiem.Text.Trim());
                GirdHD.Refresh();
                gridCTHD.DataSource = bh.getAllCTHoaDon(gridViewHD.GetRowCellValue(gridViewHD.FocusedRowHandle, "MaHD").ToString());
            }
            else
            {
                LoadHDBH();
            }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!");
            }
        }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                bh.deleteCTHD(txtMaHD.Text);
                if (bh.kiemtrachitiethd(txtMaHD.Text))
                {
                    bh.deletehd(txtMaHD.Text);
                }
                XtraMessageBox.Show("Xóa thành công");
                txtMaHD.Text = "";
            
                LoadChitiethd();
                LoadHDBH();
                if (gridViewHD.RowCount <= 0)
                {
                    txtSoDT.Text = "";
                    txtDiaChi.Text = "";
                    txtTenKH.Text = "";
                    txtMaHD.Text="";
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!");
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
