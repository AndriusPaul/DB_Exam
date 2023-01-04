using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Exam
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department > Departments { get; set; }
        public Lecture()
        {
        }
        public Lecture(int id)
        {
            Id = id;
        }
        public Lecture(string name)
        {
            Name= name;
            Departments= new List<Department>();
        }
    }
}
