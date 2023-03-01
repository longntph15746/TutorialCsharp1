using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialCsharp1
{
    [Serializable]
    class Student : Person
    {
        private string msv;
        private int nghanh;
        //1:UDPM
        //2:MOB
        //3:WEB

        public Student()
        {

        }
        public Student(string ten, string sdt, string msv, int nghanh) : base(ten, sdt)
        {
            this.nghanh = nghanh;
            this.msv = msv;
        }
        public string Msv
        {
            get => msv;
            set => msv = value;
        }
        public int Nghanh
        {
            get => nghanh;
            set => nghanh = value;
        }
        public override void InRaManHinh()
        {
            Console.WriteLine($"{Ten} | {Sdt} | {msv} | {Convert.ToString(Nghanh == 1 ? "UDPM" : Nghanh == 2 ? "MOB" : "WEB")}");
        }
    }
}
