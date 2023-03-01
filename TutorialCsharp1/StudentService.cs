using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TutorialCsharp1
{
    class StudentService
    {
        List<Student> _lstStudents;
        private Student _student;
        private string _input;
        FileStream _fs;
        BinaryFormatter _bf;
        private string _parth = @"D:\Curriculum\C#\Luyện tập\C#1\TutorialCsharp1\TutorialCsharp1\Data.bin";
        public StudentService()
        {
            _lstStudents = new List<Student>
            {
                new Student(ten: "Long", sdt: "0902096529", msv: "PH15746", nghanh:1),
                new Student(ten: "Long1", sdt: "0302096529", msv: "PH15747", nghanh:2),
                new Student(ten: "Long2", sdt: "0102096529", msv: "PH15748", nghanh:3),
                new Student(ten: "Long4", sdt: "032096529", msv: "PH15749", nghanh:1),
                new Student(ten: "Long5", sdt: "08702096529", msv: "PH15745", nghanh:1),
            };

        }
        public void aadStudent()
        {
            Console.WriteLine("Mời bạn nhập số lượng muốn thêm: ");
            _input = Console.ReadLine();
            for (int i = 0; i < Convert.ToInt32(_input); i++)
            {
                _student = new Student();
                Console.WriteLine("Mời bạn nhập tên");
                _student.Ten = Console.ReadLine();
                Console.WriteLine("Mời bạn nhập sdt");
                _student.Sdt = Console.ReadLine();
                Console.WriteLine("Mời bạn nhập msv");
                _student.Msv = Console.ReadLine();
                string temp;
                do
                {
                    Console.WriteLine("Mời bạn nhập nghanh: ");
                    Console.WriteLine("1. UDPM");
                    Console.WriteLine("2. MOB");
                    Console.WriteLine("3. WEB");
                    Console.WriteLine("Bạn học nghanh nào");
                    temp = Console.ReadLine();
                    switch (temp)
                    {
                        case "1":
                            _student.Nghanh = 1;
                            break;
                        case "2":
                            _student.Nghanh = 2;
                            break;
                        case "3":
                            _student.Nghanh = 3;
                            break;
                        default:
                            Console.WriteLine("Nghành học không có vui lòng chọn lại");
                            break;
                    }
                } while (!(temp == "1" || temp == "2" || temp == "3"));
                _lstStudents.Add(_student);
            }
        }
        public void editStudent()
        {
            int temp = getIndex();
            if (temp == -1)
            {
                Console.WriteLine("Không tìm thấy dữ liệu");
                return;
            }

            Console.WriteLine("Các thông tin cần sửa");
            Console.WriteLine("1. Sửa tên");
            Console.WriteLine("2. Sửa sdt");
            Console.WriteLine("3. Sửa nghành");
            Console.WriteLine("Mời bạn chọn chức năng: ");
            _input = Console.ReadLine();
            switch (_input)
            {
                case "1":
                    Console.WriteLine("Mời bạn nhập tên");
                    _lstStudents[temp].Ten = Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Mời bạn nhập sdt");
                    _lstStudents[temp].Sdt = Console.ReadLine();
                    break;
                case "3":
                    string tempInput;
                    do
                    {
                        Console.WriteLine("Mời bạn nhập nghanh: ");
                        Console.WriteLine("1. UDPM");
                        Console.WriteLine("2. MOB");
                        Console.WriteLine("3. WEB");
                        Console.WriteLine("Bạn học nghanh nào");
                        tempInput = Console.ReadLine();
                        switch (tempInput)
                        {
                            case "1":
                                _lstStudents[temp].Nghanh = 1;
                                break;
                            case "2":
                                _lstStudents[temp].Nghanh = 2;
                                break;
                            case "3":
                                _lstStudents[temp].Nghanh = 3;
                                break;
                            default:
                                Console.WriteLine("Nghành học không có vui lòng chọn lại");
                                break;
                        }
                    } while (!(tempInput == "1" || tempInput == "2" || tempInput == "3"));
                    break;
            }
        }



        public void removeStundent()
        {
            int temp = getIndex();
            if (temp == -1)
            {
                Console.WriteLine("Không tìm thấy dữ liệu");
                return;
            }
            _lstStudents.RemoveAt(temp);
            Console.WriteLine("xóa thành công");
        }
        public void getStudent()
        {
            foreach (var x in _lstStudents)
            {
                x.InRaManHinh();
            }
        }
        public void findStudent()
        {
            int temp = getIndex();
            if (temp == -1)
            {
                Console.WriteLine("Không tìm thấy dữ liệu");
                return;
            }
            _lstStudents[temp].InRaManHinh();
        }
        public void SaveFile()
        {
            try
            {
                _fs = new FileStream(_parth, FileMode.Create);
                _bf = new BinaryFormatter();
                _bf.Serialize(_fs, _lstStudents);
                _fs.Close();
                Console.WriteLine("Luu thanh cong");
                return;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            Console.WriteLine("Luu that bai");
        }
        public void OpenFile()
        {
            try
            {
                _fs = new FileStream(_parth, FileMode.Open);
                _bf = new BinaryFormatter();
                var data = _bf.Deserialize(_fs);
                _lstStudents = new List<Student>();
                _lstStudents = (List<Student>)data;
                _fs.Close();
                Console.WriteLine("Doc file thanh cong");
                return;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            Console.WriteLine("Doc file that bai");
        }
        public int getIndex()
        {
            _input = GetInputValue(msg: "mã");
            for (int i = 0; i < _lstStudents.Count; i++)
            {
                if (_lstStudents[i].Msv == _input)
                {
                    return i;

                }
            }
            return -1;
        }
        public string GetInputValue(string msg)
        {
            Console.WriteLine($"Mời bạn nhập {msg}");
            return Console.ReadLine();
        }
    }
}
