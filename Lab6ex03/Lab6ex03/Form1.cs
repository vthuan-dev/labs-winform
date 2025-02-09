using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab6ex03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadPhong();
            LoadNgayThanhToan();
            
            // Đăng ký sự kiện click cho các nút
            btnThem.Click += btnThem_Click;
            btnLuu.Click += btnLuu_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsData.TestConnection();
            LoadNgayThanhToan();
            LoadSoPhong();
            btnThem_Click(null, null);
        }

        private void LoadSoPhong()
        {
            try
            {
                DataTable dt = clsData.GetPhong();
                ttSoPhong.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ttSoPhong.Items.Add(row["MaPhong"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load phòng: {ex.Message}");
            }
        }

        private void LoadNgayThanhToan()
        {
            try 
            {
                // Thêm ngày hiện tại vào ComboBox
                ttNgaytt.Items.Add(DateTime.Now.ToString("yyyy-MM-dd"));
                ttNgaytt.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load ngày thanh toán: {ex.Message}");
            }
        }

        private void LoadPhong()
        {
            try
            {
                DataTable dt = clsData.GetPhong();
                ttSoPhong.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    // Thêm cả MaPhong và TenPhong vào ComboBox
                    string maPhong = row["MaPhong"].ToString();
                    string tenPhong = row["TenPhong"].ToString();
                    ttSoPhong.Items.Add(maPhong);
                }
                
                // Set SelectedIndex = -1 để không chọn giá trị mặc định
                ttSoPhong.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load phòng: {ex.Message}");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy số hóa đơn lớn nhất và cộng 1
                using (SqlConnection con = new SqlConnection(clsData.ConnectionString))
                {
                    con.Open();
                    string query = "SELECT ISNULL(MAX(SoHD), 0) FROM KhachHang";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        int maxSoHD = Convert.ToInt32(cmd.ExecuteScalar());
                        soHD.Text = (maxSoHD + 1).ToString();
                    }
                }

                // Xóa trắng các ô nhập
                ttHoten.Clear();
                ttCCCD.Clear();
                ttSotien.Clear();

                // Reset combobox Số phòng về trạng thái không chọn
                if (ttSoPhong.Items.Count > 0)
                {
                    ttSoPhong.SelectedIndex = -1;
                }

                // Set ngày thanh toán về ngày hiện tại
                ttNgaytt.Items.Clear();
                ttNgaytt.Items.Add(DateTime.Now.ToString("yyyy-MM-dd"));
                ttNgaytt.SelectedIndex = 0;

                // Focus vào ô họ tên
                ttHoten.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo hợp đồng mới: {ex.Message}");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(soHD.Text))
                {
                    MessageBox.Show("Vui lòng nhấn nút Thêm để tạo số hợp đồng mới!");
                    return;
                }

                if (string.IsNullOrEmpty(ttHoten.Text) || 
                    string.IsNullOrEmpty(ttCCCD.Text) || 
                    string.IsNullOrEmpty(ttSotien.Text) ||
                    ttSoPhong.SelectedItem == null ||
                    ttNgaytt.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                int soHopDong = int.Parse(soHD.Text);
                string tenKH = ttHoten.Text.Trim();
                string soCMND = ttCCCD.Text.Trim();
                decimal soTien;
                if (!decimal.TryParse(ttSotien.Text, out soTien))
                {
                    MessageBox.Show("Số tiền không hợp lệ!");
                    return;
                }
                
                DateTime ngayTT = DateTime.Parse(ttNgaytt.Text);
                int maPhong = int.Parse(ttSoPhong.Text);

                if (clsData.SaveKhachHang(soHopDong, tenKH, soCMND, soTien, ngayTT, maPhong))
                {
                    MessageBox.Show("Lưu thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
