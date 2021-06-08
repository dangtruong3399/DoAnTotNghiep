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
using DevExpress.XtraGrid.Views.Grid;

namespace SHOPKID
{
    public partial class PhanQuyen : DevExpress.XtraEditors.XtraUserControl
    {

        DangNhap_Dall_Ball dn = new DangNhap_Dall_Ball();
        PhanQuyen_DAl_Ball pq = new PhanQuyen_DAl_Ball();
         List<Quyen> qk = new List<Quyen>();
        public PhanQuyen()
        {
            InitializeComponent();
        }
        public void Load_PhanQuyen(object sender, EventArgs e)
        {
            load_tk();

        }

        public void load_tk()
        {
            gridTaiKhoan.DataSource = pq.load_username();
           
        }
        public void load_quyen()
        {
          
            string tk = gridViewTK.GetRowCellValue(gridViewTK.FocusedRowHandle, "UserName").ToString();
            gridQuyenNow.DataSource = pq.getAll(tk);
        }
        public void load_quyenchuaco()
        {
            string tk = gridViewTK.GetRowCellValue(gridViewTK.FocusedRowHandle, "UserName").ToString();
            gridQuyenChuaCo.DataSource = pq.load_quyenchuaco(tk);
        }
        private void gridViewTK_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            load_quyen();
            load_quyenchuaco();
        }

        private void gridTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewQuyenchuaco.RowCount <= 0)
                {
                    return;
                }
                string tk = gridViewTK.GetRowCellValue(gridViewTK.FocusedRowHandle, "UserName").ToString();
                string idquyen = gridViewQuyenchuaco.GetRowCellValue(gridViewQuyenchuaco.FocusedRowHandle, "IDform").ToString();
                pq.insertQuyen(tk, idquyen);
                if (XtraMessageBox.Show("Bạn có muốn thêm quyền này cho nhân viên", "Đồng ý thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    XtraMessageBox.Show("Thêm quyền thành công");
                    load_quyen();
                    load_quyenchuaco();
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string tk = gridViewTK.GetRowCellValue(gridViewTK.FocusedRowHandle, "UserName").ToString();
                string idquyen = gridViewDaco.GetRowCellValue(gridViewDaco.FocusedRowHandle, "IDform").ToString();
                pq.deleteQuyen(tk, idquyen);
                if (XtraMessageBox.Show("Bạn có thật sự muốn bỏ quyền này cho nhân viên", "Đồng ý bỏ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    XtraMessageBox.Show("Bỏ quyền thành công");
                    load_quyen();
                    load_quyenchuaco();
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!!!");
            }
            
        }
    }

        
}
