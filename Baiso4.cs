/*
Xây dựng lớp đối tượng HANGHOA gồm:
- Thành phần dữ liệu (Không cho phép truy cập từ ngoài class): 
mã hàng, tên hàng - Phương thức: o Hàm khởi tạo, hàm nhập, hàm xuất. 
- Xây dựng lớp đối tượng MAYTINH kế thừa từ lớp HANGHOA có thêm  
o Thuộc tính: nhà sản xuất, năm sản xuất, giá bán niêm yết. 
o Thuộc tính tĩnh: tỷ lệ khuyến mại 
o Phương thức: hàm tạo đặt thông tin mặc định, hàm nhập, hàm xuất, 
hàm tính giá bán thực tế (=giá bán niêm yết - giá bán niêm yết* tỷ lệ khuyến mại )
Chương trình chính:  
1) (3 điểm) Nhập từ bàn phím thông tin của một hàng hóa
2) (2 điểm) Hiển thị thông tin hàng hóa đó ra màn hình. 
3) (2 điểm) Nhập thông tin cho n đối tượng MAYTINH. 
4) (1 điểm) In ra màn hình thông tin của n đối tượng MAYTINH.
5) (1 điểm) Hiển thị ra màn hình các máy tính của nhà sản xuất SAMSUNG. 
6) (1 điểm) In ra màn hình tên các máy tính có giá bán thực tế thấp nhất. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baiso4
{
    public class HANGHOA
    {
        private int _maHang;
        private string _tenHang;


        public HANGHOA(int maHang = 0, string tenHang = "")
        {
            MaHang = maHang;
            TenHang = tenHang;
        }

        public int MaHang { get => _maHang; set => _maHang = value; }
        public string TenHang { get => _tenHang; set => _tenHang = value; }

        public void NhapThongtin()
        {
            Console.WriteLine("Nhap thong tin hang hoa: ");
            Console.Write("Ma hang: ");
            _maHang = int.Parse(Console.ReadLine());
            Console.Write("Ten hang hoa: ");
            _tenHang = Console.ReadLine();
        }
        public void XuatThongtin()
        {
            Console.WriteLine("Thong tin hang hoa: ");
            Console.WriteLine("Ma hang: " + _maHang);
            Console.WriteLine("Ten hang hoa" + _tenHang);
        }
    }
    public class MAYTINH : HANGHOA
    {
        private string _nhaSanxuat;
        private int _namSanxuat;
        private int _giaNiemyet;
        public static double tileKhuyenmai = 0.1;

        public string NhaSanxuat { get => _nhaSanxuat; set => _nhaSanxuat = value; }
        public int NamSanxuat { get => _namSanxuat; set => _namSanxuat = value; }
        public int GiaNiemyet { get => _giaNiemyet; set => _giaNiemyet = value; }

        public MAYTINH(int maHang=0, string tenHang="", string nhaSanxuat = "", int namSanxuat = 0, int giaNiemyet = 0)
        : base(maHang, tenHang)
        {
            _nhaSanxuat = nhaSanxuat;
            _namSanxuat = namSanxuat;
            _giaNiemyet = giaNiemyet;
        }
        public double GiaBan()
        {
            return (_giaNiemyet - _giaNiemyet * tileKhuyenmai);
        }
        public void NhapThongtin()
        {
            base.NhapThongtin();
            Console.Write("Nha san xuat: ");
            _nhaSanxuat = Console.ReadLine();
            Console.Write("Nam san xuat: ");
            _namSanxuat = int.Parse(Console.ReadLine());
            Console.Write("Gia niem yet: ");
            _giaNiemyet = int.Parse(Console.ReadLine());
        }
        public void XuatThongtin()
        {
            base.XuatThongtin();
            Console.WriteLine("Nha san xuat: " + _nhaSanxuat);
            Console.WriteLine("Nam san xuat: " + _namSanxuat);
            Console.WriteLine("Gia niem yet: " + _giaNiemyet);
            Console.WriteLine("Gia ban thuc te: " + GiaBan());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cau 1+2:
            //HANGHOA hh = new HANGHOA();
            //hh.NhapThongtin();
            //hh.XuatThongtin();
            int soLuong;
            Console.Write("Nhap so luong may tinh: ");
            soLuong = int.Parse(Console.ReadLine());
            MAYTINH[] danhsachMaytinh = new MAYTINH[soLuong];
            for (int i = 0; i < soLuong; i++) danhsachMaytinh[i] = new MAYTINH();
            foreach (MAYTINH mt in danhsachMaytinh) mt.NhapThongtin();
            Console.WriteLine("Danh sach may tinh: ");
            foreach(MAYTINH mt in danhsachMaytinh)
            {
                Console.WriteLine("- - - - - - - - - - - - - - - ");
                mt.XuatThongtin();
            }
            Console.WriteLine("May tinh SAMSUNG: ");
            foreach(MAYTINH mt in danhsachMaytinh)
            {
                if(mt.NhaSanxuat == "SAMSUNG") 
                { 
                    mt.XuatThongtin();
                    Console.WriteLine("- - - - - - - - - - - - - - - -");
                }
            }
            double giaThapnhat = danhsachMaytinh[0].GiaNiemyet;
            foreach(MAYTINH mt in danhsachMaytinh)
            {
                if (mt.GiaBan() < giaThapnhat) giaThapnhat = mt.GiaBan();
            }
            Console.WriteLine("Danh sach may tinh gia thap nhat:");
            foreach(MAYTINH mt in danhsachMaytinh)
            {
                if(mt.GiaBan() == giaThapnhat)
                {
                    mt.XuatThongtin();
                    Console.WriteLine("- - - - - - - - - - - - - - - -");
                }
            }
        }
    }
}
