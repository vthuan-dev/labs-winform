using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab08_prjSinhVien
{
    public partial class frmTrangCanBo : Form
    {
        object mamon;
        public frmTrangCanBo()
        {
            InitializeComponent();
        }
        void setcboMon()
        {
            try
            {
                clsConnectDB.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter("select distinct gd.MaMon, TenMon " +
                    "from GiangDay gd join CanBo cb on gd.MaCB = cb.MaCB " +
                    "join MonHoc mh on gd.MaMon=mh.MaMon " +
                    "where gd.MaCB="+frmDangNhap.mCanBoOrigin.MaSo, clsConnectDB.con);
                
 
                DataSet ds = new DataSet();
                da.Fill(ds, "dsMon");
                DataTable dt = ds.Tables["dsMon"];
                cboMonHoc.DataSource = dt;
                cboMonHoc.ValueMember = "MaMon";
                cboMonHoc.DisplayMember = "TenMon";
                clsConnectDB.CloseConnection();
                cboMonHoc.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void setcboLop()
        {
            try
            {
                clsConnectDB.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter("select distinct gd.MaLop, l.TenLop " +
                    "from GiangDay gd " +
                    "join Lop l on gd.MaLop=l.MaLop " +
                    "where MaCB=" +frmDangNhap.mCanBoOrigin.MaSo + 
                    " and MaMon="+"'"+cboMonHoc.SelectedValue+"'", clsConnectDB.con);

                DataSet ds = new DataSet();
                da.Fill(ds, "dsLop");
                DataTable dt = ds.Tables["dsLop"];
                cboMaLop.DataSource = dt;
                cboMaLop.ValueMember = "MaLop";
                cboMaLop.DisplayMember = "TenLop";
                clsConnectDB.CloseConnection();
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmTrangCanBo_Load(object sender, EventArgs e)
        {
            string info = frmDangNhap.mCanBoOrigin.HoTen + " " + frmDangNhap.mCanBoOrigin.MaSo;
            lbCanBoInfo.Text = info;
            setcboMon();
            setcboLop();
            dtgridDSSV.DataSource = null;
            
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap.mCanBoOrigin = null;
            this.Close();
        }

        private void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonHoc.SelectedIndex == -1)
            {
                return;
            }
            setcboLop();
            cboMaLop.SelectedIndex = -1;
            dtgridDSSV.DataSource = null;
        }

        private void cboMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaLop.SelectedIndex == -1)
            {
                lbConfirm.Text = "";
                return;
            }
            else if (cboMonHoc.SelectedIndex != -1)
            {
                lbConfirm.Text = Convert.ToString(cboMonHoc.SelectedValue) + "/" + Convert.ToString(cboMaLop.SelectedValue);
                try
                {

                    clsConnectDB.OpenConnection();
                    SqlDataAdapter da = new SqlDataAdapter(
                        "select sv.MSSV, sv.HoSV, sv.TenSV, dsv.DiemSo from GiangDay gd " +
                        "join SinhVien sv on gd.MaLop=sv.LopSV " +
                        "left join DiemSV dsv on sv.MSSV=dsv.MaSV and dsv.MaMon=gd.MaMon " +
                        "where gd.MaCB='" + frmDangNhap.mCanBoOrigin.MaSo +
                        "' and gd.MaMon='" + cboMonHoc.SelectedValue +
                        "' and gd.MaLop='" + cboMaLop.SelectedValue +
                        "' order by MSSV asc;"
                        , clsConnectDB.con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "DSSinhVien");
                    dtgridDSSV.DataSource = ds.Tables["DSSinhVien"];
                    clsConnectDB.CloseConnection();
                    dtgridDSSV.Columns["MSSV"].ReadOnly = true;
                    dtgridDSSV.Columns["HoSV"].ReadOnly = true;
                    dtgridDSSV.Columns["TenSV"].ReadOnly = true;
                    dtgridDSSV.Columns["DiemSo"].ReadOnly = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                clsConnectDB.OpenConnection();
                for (int i = 0; i < dtgridDSSV.Rows.Count; i++)
                {
                    string mssv = dtgridDSSV.Rows[i].Cells["MSSV"].Value?.ToString();
                    object mamon = cboMonHoc.SelectedValue;
                    string diemso = dtgridDSSV.Rows[i].Cells["DiemSo"].Value?.ToString();
                    if (diemso == "") diemso = "-4";
                    
                    SqlCommand com = new SqlCommand("UptDiem", clsConnectDB.con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@MSSV", SqlDbType.NVarChar).Value = mssv;
                    com.Parameters.AddWithValue("@MaMon", SqlDbType.NVarChar).Value = mamon;
                    com.Parameters.AddWithValue("@DiemSo", SqlDbType.Float).Value = diemso;

                    com.ExecuteNonQuery();
                }
                clsConnectDB.CloseConnection();
                MessageBox.Show("Lưu điểm thành công", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
