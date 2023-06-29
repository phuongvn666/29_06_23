/*
 Sinh viên hãy lập trình hướng đối tượng bằng C++ thực hiện các việc sau:
 - Xây dựng lớp PhuongTienGiaoThong (phương tiện giao thông):
 +) Thuộc tính: Hãng sản xuất (chuỗi ký tự), Tên phương tiện (chuỗi ký tự), 
 Năm sản xuất (số nguyên), Vận tốc tối đa (float). 
 +) Phương thức: Hàm thiết lập,  hàm nhập, hàm xuất. 
 - Xây dựng lớp OTo (ô tô) kế thừa lớp PhuongTienGiaoThong 
 bổ sung thêm: Thuộc tính: Số chỗ ngồi (int), Kiểu động cơ (chuỗi ký tự). 
 Phương thức:   - Hàm thiết lập, hàm huỷ bỏ, hàm nhập, hàm xuất.  
- Vận tốc cơ sở: được tính bằng vận tốc tối đa chia cho số bánh.   
- Nạp chồng toán tử < (phương tiện giao thông có <Vận tốc cơ sở= nhỏ hơn thì nhỏ hơn).
Chương trình chính:  1) (3 điểm) Nhập từ bàn phím thông tin của một phương tiện giao thông PhuongTienGiaoThong.
2) (2 điểm) Hiển thị thông tin của phương tiện giao thông vừa nhập ra màn hình.
3) (2 điểm) Nhập thông tin cho n đối tượng OTO bao gồm: Hãng sản xuất, 
Tên phương tiện, Năm sản xuất, Vận tốc tối đa, số chỗ ngồi, kiểu động cơ. 
4) (1 điểm) In ra màn hình thông tin của n đối tượng OTO cùng với vận tốc cơ sở.
5) (2 điểm) Sắp xếp danh sách các đối tượng OTO theo thứ tự giảm dần của vận tốc cơ sở.
  */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baiso1
{
    public class PhuongTienGiaoThong
    {
        private string _hangSanxuat;
        private string _tenPhuongtien;
        private int _namSanxuat;
        private float _vantocToida;





        public PhuongTienGiaoThong(string tenhang ="", string phuongtien="", int sonam=0, float tocdo=0)
        {
            _hangSanxuat = tenhang;
            _tenPhuongtien = phuongtien;
            _namSanxuat = sonam;
            _vantocToida = tocdo;
        }

        public string HangSanxuat { get => _hangSanxuat; set => _hangSanxuat = value; }
        public string TenPhuongtien { get => _tenPhuongtien; set => _tenPhuongtien = value; }
        public int NamSanxuat { get => _namSanxuat; set => _namSanxuat = value; }
        public float VantocToida { get => _vantocToida; set => _vantocToida = value; }

        public void NhapThongtin()
        {
            Console.WriteLine("Nhap Thong tin phuong tien!");
            Console.Write("Ten hang san xuat: ");
            HangSanxuat = Console.ReadLine();
            Console.Write("Ten phuong tien: ");
            TenPhuongtien = Console.ReadLine();
            Console.Write("Nam san xuat: ");
            NamSanxuat = int.Parse(Console.ReadLine());
            Console.Write("Van toc toi da: ");
            VantocToida = float.Parse(Console.ReadLine());
        }
        public void XuatThongtin()
        {
            Console.WriteLine("Thong tin phuong tien!");
            Console.WriteLine("Hang san xuat: " + HangSanxuat);
            Console.WriteLine("Phuong tien: " + TenPhuongtien);
            Console.WriteLine("Nam san xuat: " + NamSanxuat);
            Console.WriteLine("Van toc toi da: " + VantocToida);
        }

    }
    public class OTo : PhuongTienGiaoThong
    {
        private int _soChongoi;
        private string _kieuDongco;

        public int SoChongoi { get => _soChongoi; set => _soChongoi = value; }
        public string KieuDongco { get => _kieuDongco; set => _kieuDongco = value; }

        public OTo(string tenhang="", string phuongtien="", int sonam=0, float tocdo=0, int chongoi=0, string dongcoxang="")
            : base(tenhang, phuongtien, sonam, tocdo)
        {
            _soChongoi = chongoi;
            _kieuDongco = dongcoxang;
        }



        ~OTo()
        {
            Console.WriteLine("Da xoa");
        }
        public void NhapThongtin()
        {
            base.NhapThongtin();
            Console.Write("So cho ngoi: ");
            SoChongoi = int.Parse(Console.ReadLine());
            Console.Write("Kieu Dong co: ");
            KieuDongco = Console.ReadLine();
        }
        public void XuatThongtin()
        {
            base.XuatThongtin();
            Console.WriteLine("So cho ngoi: " + SoChongoi);
            Console.WriteLine("Kieu dong co: " + KieuDongco);
        }
        public float VantocCoso()
        {
            return VantocToida / 4;
        }
        public static bool operator >(OTo oto1, OTo oto2)
        {
            return oto1.VantocCoso() > oto2.VantocCoso();
        }
        public static bool operator <(OTo oto1, OTo oto2)
        {
            return oto1.VantocCoso() < oto2.VantocCoso();
        }


    }
    internal class Program
    {

        static void Main(string[] args)
        {
            /*
             * Cau 1,2:
            PhuongTienGiaoThong pt1 = new PhuongTienGiaoThong();
            pt1.NhapThongtin();
            pt1.XuatThongtin();
            */

            int soXe;
            Console.Write("So luong xe: ");
            soXe = int.Parse(Console.ReadLine());
            OTo[] danhsachOto = new OTo[soXe];
            for (int i = 0; i < soXe; i++) danhsachOto[i] = new OTo();
            for (int i = 0; i < soXe; i++) danhsachOto[i].NhapThongtin();
            Console.WriteLine("Danh sach oto: ");
            for (int i = 0; i < soXe; i++)
            {
                Console.WriteLine("- - - - - -  - - -  - - - ");
                danhsachOto[i].XuatThongtin();
                float vantoccoso = danhsachOto[i].VantocCoso();
                Console.WriteLine("Van Toc Co So: " + vantoccoso);
                Console.WriteLine("- - -  - - - - - - - - -");
            }
            for(int i = 0; i < soXe; i++)
            {
                for(int j = 0; j < soXe - i - 1; j++)
                {
                    if (danhsachOto[j].VantocCoso() < danhsachOto[j + 1].VantocCoso())
                    {
                        OTo temp = new OTo();
                        temp = danhsachOto[j];
                        danhsachOto[j] = danhsachOto[j + 1];
                        danhsachOto[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("- - - - - -  - - -  - - - ");
            Console.WriteLine("- - - - - -  - - -  - - - ");
            Console.WriteLine("Danh sach da sap xep: ");
            for (int i = 0; i < soXe; i++)
            {
                danhsachOto[i].XuatThongtin();
                Console.WriteLine("Van Toc Co So: " + danhsachOto[i].VantocCoso());
            }
        }
    }
}
