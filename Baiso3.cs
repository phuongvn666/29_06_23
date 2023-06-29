/*
Xây dựng lớp đối tượng DATE gồm:
- Thành phần dữ liệu (Không cho phép truy cập từ ngoài class):
ngày, tháng, năm 
- Phương thức: o Hàm khởi tạo, hàm nhập, hàm xuất. 
- Xây dựng lớp đối tượng CANBO kế thừa từ lớp DATE có thêm 
o Thuộc tính: mã cán bộ, tên cán bộ, ngày tháng năm sinh(kế thừa từ lớp DATE), lương cơ bản 
o Thuộc tính tĩnh: tiền phụ cấp chức vụ 
o Phương thức: hàm tạo đặt thông tin mặc định, hàm nhập, hàm xuất,
hàm tính lương (=lương cơ bản + tiền phụ cấp chức vụ)
Chương trình chính:  
1) (3 điểm) Nhập từ bàn phím thông tin của một ngày tháng năm, 
2) (2 điểm) Hiển thị thông tin ngày tháng năm đó ra màn hình. 
3) (2 điểm) Nhập thông tin cho n đối tượng CANBO. 
4) (1 điểm) In ra màn hình thông tin của n đối tượng CANBO. 
5) (1 điểm) Hiển thị ra màn hình lương của n cán bộ. 
6) (1 điểm) In ra màn hình tên các cán bộ có lương thấp nhất.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baiso3
{
    class DATE
    {
        private int _ngay;
        private int _thang;
        private int _nam;

        public DATE(int ngay = 0, int thang = 0, int nam = 0)
        {
            _ngay = ngay;
            _thang = thang;
            _nam = nam;
        }

        public int Ngay { get => _ngay; set => _ngay = value; }
        public int Thang { get => _thang; set => _thang = value; }
        public int Nam { get => _nam; set => _nam = value; }

        public void NhapThongtin()
        {
            Console.WriteLine("Nhap Thong tin:");
            Console.Write("Ngay: ");
            Ngay = int.Parse(Console.ReadLine());
            Console.Write("Thang: ");
            Thang = int.Parse(Console.ReadLine());
            Console.Write("Nam: ");
            Nam = int.Parse(Console.ReadLine());
        }
        public void XuatThongtin()
        {
            Console.WriteLine("Thong tin can bo:");
            Console.WriteLine("Ngay sinh: " + Ngay + ", " + Thang + ", " + Nam);

        }
    }
    class CANBO : DATE
    {
        int _maCanbo;
        string _tenCanbo;
        int _luongCoban;
        static int phuCapChucvu = 3000;

        public int MaCanbo { get => _maCanbo; set => _maCanbo = value; }
        public string TenCanbo { get => _tenCanbo; set => _tenCanbo = value; }
        public int LuongCoban { get => _luongCoban; set => _luongCoban = value; }

        public CANBO(int Ngay=0, int Thang=0, int Nam=0, int MaCanbo=0, string TenCanbo="", int LuongCoban = 0)
            : base(Ngay, Thang, Nam)
        {
            _maCanbo = MaCanbo;
            _tenCanbo = TenCanbo;
            _luongCoban = LuongCoban;

        }
        public int TinhLuong()
        {
            return LuongCoban + phuCapChucvu;
        }
        public void NhapThongtin()
        {
            base.NhapThongtin();
            Console.Write("Ma can bo: ");
            MaCanbo = int.Parse(Console.ReadLine());
            Console.Write("Ho va ten: ");
            TenCanbo = Console.ReadLine();
            Console.Write("Luong co ban: ");
            LuongCoban = int.Parse(Console.ReadLine());
        }
        public void XuatThongtin()
        {
            base.XuatThongtin();
            Console.WriteLine("Ma: " + MaCanbo);
            Console.WriteLine("Ho va ten: " + TenCanbo);
            Console.WriteLine("Luong: " + TinhLuong());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /* Cau 1,2:
            DATE so1 = new DATE();
            so1.NhapThongtin();
            so1.XuatThongtin(); */
            int soLuong;
            Console.Write("Nhap so can bo:");
            soLuong = int.Parse(Console.ReadLine());
            CANBO[] danhsachCanbo = new CANBO[soLuong];
            for (int i = 0; i < danhsachCanbo.Length; i++) danhsachCanbo[i] = new CANBO();
            foreach (CANBO cbo in danhsachCanbo) cbo.NhapThongtin();
            Console.WriteLine("Danh sach can bo: ");
            foreach (CANBO cbo in danhsachCanbo)
            {
                cbo.XuatThongtin();
                Console.WriteLine("- - - - - -  - - - - - - -  - - -");
            }
            Console.WriteLine("Luong: ");
            foreach (CANBO cbo in danhsachCanbo)
            {
                Console.WriteLine("Can bo " + cbo.TenCanbo + " co luong: " + cbo.TinhLuong());
                Console.WriteLine("- - - - - -  - - - - - - -  - - -");
            }
            int luongThapnhat = danhsachCanbo[0].TinhLuong();
            foreach (CANBO cbo in danhsachCanbo)
            {
                if (cbo.TinhLuong() < luongThapnhat) luongThapnhat = cbo.TinhLuong();
            }
            Console.WriteLine("Can bo co luong thap nhat: ");
            foreach (CANBO cbo in danhsachCanbo)
            {
                if (cbo.TinhLuong() == luongThapnhat) Console.WriteLine(cbo.TenCanbo);
            }
        }
    }
}
