﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QuanLyBanHang
{
    public partial class Form3 : Form
    {
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtTable
        SqlDataAdapter daTable = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtTable = null;
        string strConnectionString = @"Data Source=DESKTOPOFLUAN\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        // Đối tượng kết nối
       
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Xử lý danh mục
                int intDM = Convert.ToInt32(this.Text);
                switch (intDM)
                {
                    case 1:
                        lblDM.Text = "Danh Mục Thành Phố";
                        daTable = new SqlDataAdapter("SELECT ThanhPho, TenThanhPho FROM THANHPHO", conn);
                        break;
                    case 2:
                        lblDM.Text = "Danh Mục Khách Hàng";
                        daTable = new SqlDataAdapter("SELECT MaKH, TenCTy FROM KHACHHANG", conn);
                        break;
                    case 3:
                        lblDM.Text = "Danh Mục Nhân Viên";
                        daTable = new SqlDataAdapter("SELECT MaNV, Ho, Ten FROM NHANVIEN", conn);
                        break;
                    case 4:
                        lblDM.Text = "Danh Mục Sản Phẩm";
                        daTable = new SqlDataAdapter("SELECT MaSP, TenSP, DonViTinh, DonGia FROM SANPHAM",
                        conn);
                        break;
                    case 5:
                        lblDM.Text = "Danh Mục Hóa Đơn";
                        daTable = new SqlDataAdapter("SELECT MaHD,  MaKH, MaNV FROM HOADON", conn);
                        break;
                    case 6:
                        lblDM.Text = "Danh Mục Chi Tiết Hóa Đơn";
                        daTable = new SqlDataAdapter("SELECT * FROM CHITIETHOADON", conn);
                        break;
                    default:
                        break;
                }
                // Vận chuyển dữ liệu lên DataTable dtTable
                dtTable = new DataTable();
                dtTable.Clear();
                daTable.Fill(dtTable);
                // Đưa dữ liệu lên DataGridView
                dgvDANHMUC.DataSource = dtTable;
                // Thay đổi độ rộng cột
                dgvDANHMUC.AutoResizeColumns();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table.Lỗi rồi!!!");
            }

        }

        private void btnTrolai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
