/*
 * Xây dựng lớp đối tượng NGUOI gồm:
 * - Thành phần dữ liệu (Không cho phép truy cập từ ngoài class):
 * mã định danh, họ tên người 
 * - Phương thức: o Hàm khởi tạo, hàm huỷ, hàm nhập, hàm xuất. 
 * - Xây dựng lớp đối tượng NHANVIEN kế thừa từ lớp NGUOI có thêm  
 * o Thuộc tính thêm: năm sinh, hệ số lương  
 * o Thuộc tính tĩnh: tiền phụ cấp 
 * o Phương thức: hàm tạo đặt thông tin mặc định, hàm nhập, hàm xuất, 
 * ,hàm tính lương (=hệ số lương x 1550 + tiền phụ cấp) o 
 * Hàm nạp chồng toán tử > để so sánh hai Nhân viên theo hệ số lương  
 * (nhân viên có hệ số lương cao hơn sẽ lớn hơn). 
 * Chương trình chính:
 * 1) (3 điểm) Nhập từ bàn phím thông tin của một người bao gồm: mã định danh, họ tên người.
 * 2) (2 điểm) Hiển thị thông tin người đó ra màn hình. 
 * 3) (2 điểm) Nhập thông tin cho n đối tượng NHANVIEN bao gồm: mã định danh, họ tên nhân viên, năm sinh, hệ số lương.
 * 4) (1 điểm) In ra màn hình thông tin của n đối tượng NHANVIEN cùng với lương. 
 * 5) (2 điểm) Sắp xếp danh sách nhân viên theo thứ tự giảm dần theo hệ số lương. 
 * Hiển thị danh sách sau khi sắp.
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baiso2
{
    class NGUOI
    {
        private int _maDinhDanh;
        private string _hoTen;
        public NGUOI(int MaDinhDanh = 0, string HoTen = "")
        {
            _maDinhDanh = MaDinhDanh;
            _hoTen = HoTen;
        }

        ~NGUOI()
        {
            Console.WriteLine("Da xoa");

        }

        public int MaDinhDanh { get => _maDinhDanh; set => _maDinhDanh = value; }
        public string HoTen { get => _hoTen; set => _hoTen = value; }

        public void NhapThongtin()
        {
            Console.WriteLine("Thong tin nhan dang:");
            Console.Write("Nhap ma dinh danh: ");
            MaDinhDanh = int.Parse(Console.ReadLine());
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();
        }
        public void XuatThongtin()
        {
            Console.WriteLine("Thong tin nhan dang");
            Console.WriteLine("Ma dinh danh: " + MaDinhDanh);
            Console.WriteLine("Ho va ten: " + HoTen);
        }
    }
    class NHANVIEN : NGUOI
    {
        private int _namSinh;
        private int _heSoluong;
        static int tienPhucap = 3000;

        public int NamSinh { get => _namSinh; set => _namSinh = value; }
        public int HeSoluong { get => _heSoluong; set => _heSoluong = value; }

        public NHANVIEN(int MaDinhDanh = 0, string HoTen = "", int NamSinh = 0, int HeSoluong = 0) : base(MaDinhDanh, HoTen)
        {
            this.NamSinh = NamSinh;
            this.HeSoluong = HeSoluong;
        }

        public NHANVIEN()
        {
        }

        public void NhapThongtin()
        {
            base.NhapThongtin();
            Console.WriteLine("Nhap nam sinh");
            NamSinh = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap he so luong");
            HeSoluong = int.Parse(Console.ReadLine());
        }
        public void XuatThongtin()
        {
            base.XuatThongtin();
            Console.WriteLine("Nam sinh: " + NamSinh);
            Console.WriteLine("He so luong: " + HeSoluong);
        }
        public int TinhLuong()
        {
            return HeSoluong * 1550 + tienPhucap;
        }
        public static bool operator >(NHANVIEN so1, NHANVIEN so2)
        {
            return so1.HeSoluong > so2.HeSoluong;
        }
        public static bool operator <(NHANVIEN so1, NHANVIEN so2)
        {
            return so1.HeSoluong < so2.HeSoluong;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Cau 1+2:
            NGUOI nguoi1 = new NGUOI();
            nguoi1.NhapThongtin();
            nguoi1.XuatThongtin();
            */
            int tongNhanvien;
            Console.Write("Nhap so luong nhan vien:");
            tongNhanvien = int.Parse(Console.ReadLine());
            NHANVIEN[] danhsachNhanvien = new NHANVIEN[tongNhanvien];
            for (int i = 0; i < danhsachNhanvien.Length; i++) danhsachNhanvien[i] = new NHANVIEN();
            foreach (NHANVIEN nhanvien in danhsachNhanvien) nhanvien.NhapThongtin();
            Console.WriteLine("Danh sach nhan vien: ");
            foreach (NHANVIEN nhanvien in danhsachNhanvien)
            {
                Console.WriteLine("- - - - - -  - - -  - - - ");
                nhanvien.XuatThongtin();
                Console.WriteLine("Luong: " + nhanvien.TinhLuong());
                Console.WriteLine("- - - - - -  - - -  - - - ");
            }
            Console.WriteLine("- - - - - -  - - -  - - - ");
            Console.WriteLine("- - - - - -  - - -  - - - ");
            for (int i = 0; i < danhsachNhanvien.Length;)
            {
                for (int j = 0; j < danhsachNhanvien.Length - i - 1; j++)
                {
                    if (danhsachNhanvien[j] < danhsachNhanvien[j + 1])
                    {
                        NHANVIEN tg = new NHANVIEN();
                        tg = danhsachNhanvien[j];
                        danhsachNhanvien[j] = danhsachNhanvien[j + 1];
                        danhsachNhanvien[j + 1] = tg;
                    }
                }
            }
            Console.WriteLine("Danh sach nhan vien sap xep theo he so luong: ");
            foreach (NHANVIEN nhanvien in danhsachNhanvien)
            {
                Console.WriteLine("- - - - - -  - - -  - - - ");
                nhanvien.XuatThongtin();
                Console.WriteLine("Luong: " + nhanvien.TinhLuong());
                Console.WriteLine("- - - - - -  - - -  - - - ");
            }
        }
    }
}
