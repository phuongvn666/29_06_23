/*
 *Xây dựng lớp đối tượng SACH gồm:
 *- Thành phần dữ liệu (Không cho phép truy cập từ ngoài class):
 *mã sách, tên sách 
 *- Phương thức: o Hàm khởi tạo, hàm nhập, hàm xuất. 
 *- Xây dựng lớp đối tượng MUONTRA kế thừa từ lớp SACH có thêm  
 *o Thuộc tính: mã độc giả, mã sách (kế thừa từ lớp SACH), số lượng.
 *o Thuộc tính tĩnh: phí cược mượn trả o Phương thức: hàm tạo đặt thông tin mặc định,
 *hàm nhập, hàm xuất, hàm tính số tiền cược mượn trả (=số lượng*phí cược mượn trả) 
 *Chương trình chính:  
 *1) (3 điểm) Nhập từ bàn phím thông tin của một cuốn sách
 *2) (2 điểm) Hiển thị thông tin cuốn sách đó ra màn hình.
 *3) (2 điểm) Nhập thông tin cho n đối tượng MUONTRA. 
 *4) (1 điểm) In ra màn hình thông tin của n đối tượng MUONTRA.
 *5) (1 điểm) Hiển thị ra màn hình các độc giả có số lượng mượn >10 cuốn. 
 *6) (1 điểm) In ra màn hình mã các độc giả có số tiền cược nhiều nhất.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baiso5
{
    public class Book
    {
        private int _bookId;
        private string _bookTitle;

        public int BookId { get => _bookId; set => _bookId = value; }
        public string BookTitle { get => _bookTitle; set => _bookTitle = value; }
        public Book(int bookId = 0, string bookTitle = "")
        {
            _bookId = bookId;
            _bookTitle = bookTitle;
        }
        public void Input()
        {
            Console.WriteLine("Nhap thong tin sach: ");
            Console.Write("ID: ");
            BookId = int.Parse(Console.ReadLine());
            Console.Write("Ten sach: ");
            BookTitle = Console.ReadLine();
        }
        public void Output()
        {
            Console.WriteLine("Thong tin sach: ");
            Console.WriteLine("ID: " + BookId);
            Console.WriteLine("Ten sach: " + BookTitle);
        }
    }
    public class Reader:Book
    {
        private int _readerId;
        private int _quantity;

        public int ReaderId { get => _readerId; set => _readerId = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public static int fee = 10000;
        public Reader(int BookId=0,string BookTitle="",int readerId=0, int quantity=0)
            : base(BookId,BookTitle)
        {
            _readerId = readerId;
            _quantity = quantity;
        }
        public int Pay()
        {
            return Quantity * fee;
        }
        public void Input()
        {
            base.Input();
            Console.Write("Ma doc gia: ");
            ReaderId = int.Parse(Console.ReadLine());
            Console.Write("So luong sach muon: ");
            Quantity = int.Parse(Console.ReadLine());
        }
        public void Output()
        {
            base.Output();
            Console.WriteLine("Ma doc gia: "+ReaderId);
            Console.WriteLine("So luong sach da muon: "+Quantity);
            Console.WriteLine("So tien phai tra: " + Pay());
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cau 1+2:
            //Book book = new Book();
            //book.Input();
            //book.Output();
            int readerQuantity;
            Console.Write("Nhap so luowng doc gia: ");
            readerQuantity = int.Parse(Console.ReadLine());
            Reader[] readerList = new Reader [readerQuantity];
            for (int i = 0; i < readerQuantity; i++) readerList[i] = new Reader();
            foreach(Reader reader in readerList) reader.Input();
            Console.WriteLine("Danh sach doc gia: ");
            foreach(Reader reader in readerList)
            {
                reader.Output();    
                Console.WriteLine("- - - - - - - - - - - - - - - - - -");
            }
            Console.WriteLine("- - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Doc gia muon nhieu hon 10 cuon: ");
            foreach(Reader reader in readerList) if (reader.Quantity>10) reader.Output();
            int maxPay = readerList[0].Pay();
            foreach(Reader reader in readerList) if(reader.Pay()>maxPay) maxPay = reader.Pay();
            Console.WriteLine("Danh sach doc gia co so tien cuoc nhieu nhat:");
            foreach(Reader reader in readerList) if(reader.Pay() == maxPay) Console.WriteLine("Ma doc gia: " + reader.ReaderId);

        }
    }
}
