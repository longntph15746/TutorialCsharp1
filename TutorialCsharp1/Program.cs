using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialCsharp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            StudentService studentService = new StudentService();
            do
            {
                Console.WriteLine("Toturial C#1");
                Console.WriteLine("Quản lý sinh viên FPOLY");
                Console.WriteLine("1. Thêm");
                Console.WriteLine("2. Sửa");
                Console.WriteLine("3. Xóa");
                Console.WriteLine("4. In danh sách");
                Console.WriteLine("5. Tìm kiếm");
                Console.WriteLine("6. Lọc");
                Console.WriteLine("7. Đọc File");
                Console.WriteLine("8. Lưu File");
                Console.WriteLine("Mời bạn chọn chức năng: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        studentService.aadStudent();
                        break;
                    case "2":
                        studentService.editStudent();
                        break;
                    case "3":
                        studentService.removeStundent();
                        break;
                    case "4":
                        studentService.getStudent();
                        break;
                    case "5":
                        studentService.findStudent();
                        break;
                    case "6":
                        break;
                    case "7":
                        studentService.SaveFile();
                        break;
                    case "8":
                        studentService.OpenFile();
                        break;
                    default:
                        break;
                }
            } while (true);

        }
    }
}
