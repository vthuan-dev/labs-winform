using System;
using System.Data;
using System.Windows.Forms;

namespace Lab6ex03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsData.TestConnection();
            LoadNgayThanhToan();
            LoadSoPhong();
        }

        private void LoadSoPhong()
        {
            ttSoPhong.Items.Clear();
            DataTable dt = clsData.GetSoPhong();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Phong"] != DBNull.Value)
                {
                    ttSoPhong.Items.Add(row["Phong"].ToString());
                }
            }
        }

        private void LoadNgayThanhToan()
        {
            ttNgaytt.Items.Clear();
            DataTable dt = clsData.GetNgayThanhToan();
            foreach (DataRow row in dt.Rows)
            {
                if (row["NgayTT"] != DBNull.Value)
                {
                    ttNgaytt.Items.Add(Convert.ToDateTime(row["NgayTT"]).ToString("yyyy-MM-dd"));
                }
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            int soHDMoi = clsData.GetNextSoHD();
            soHD.Text = soHDMoi.ToString();

            ttHoten.Text = "";
            ttCCCD.Text = "";
            ttSotien.Text = "";
            ttNgaytt.SelectedIndex = -1;
            ttSoPhong.SelectedIndex = -1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                int soHDValue = Convert.ToInt32(soHD.Text);
                string tenKHValue = ttHoten.Text;
                string soCMNDValue = ttCCCD.Text;
                decimal soTienValue = Convert.ToDecimal(ttSotien.Text);
                DateTime ngayTTValue = Convert.ToDateTime(ttNgaytt.SelectedItem); // Lấy ngày thanh toán từ ComboBox
                int maPhongValue = Convert.ToInt32(ttSoPhong.SelectedItem?.ToString() ?? "0"); // Kiểm tra nếu maPhongValue hợp lệ

                // Kiểm tra và lưu vào cơ sở dữ liệu
                if (clsData.SaveKhachHang(soHDValue, tenKHValue, soCMNDValue, soTienValue, ngayTTValue, maPhongValue))
                {
                    // Nếu lưu thành công, làm mới lại form và tải lại dữ liệu
                    MessageBox.Show("Lưu hóa đơn thành công!");
                    LoadSoPhong();
                    LoadNgayThanhToan();
                }
                else
                {
                    MessageBox.Show("Lưu hóa đơn thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập dữ liệu: " + ex.Message);
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
