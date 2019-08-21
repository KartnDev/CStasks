using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task9
{
    public class A
    {
        public List<Student> students(int group)
        {

            List<Student> studentList = new List<Student>();
            studentList.Add(new Student { ID = 1, name = "zxc", groupID = 1 });
            studentList.Add(new Student { ID = 2, name = "sdsd", groupID = 3 });
            studentList.Add(new Student { ID = 3, name = "asfsdfad", groupID = 1 });
            studentList.Add(new Student { ID = 4, name = "er", groupID = 2 });
            studentList.Add(new Student { ID = 5, name = "dsfdsf", groupID = 2 });
            studentList.Add(new Student { ID = 6, name = "afsdfsafdsf", groupID = 1 });
            studentList.Add(new Student { ID = 7, name = "1r32rewf", groupID = 3 });
            studentList.Add(new Student { ID = 8, name = "5urtc", groupID = 2 });
            studentList.Add(new Student { ID = 9, name = "gdsfghgfh", groupID = 1 });
            studentList.Add(new Student { ID = 10, name = "Vcxvc", groupID = 3 });
            studentList.Add(new Student { ID = 11, name = "efec", groupID = 1 });
            // foreach(var item in context.Students)
            //
            // if(item.groupID == group)
            //  {
            //      studentList.Add(item);
            // }
            //}
            List<Student> studentList1 = new List<Student>();

            foreach(var item in studentList)
            {
                if(item.groupID == group)
                {
                    studentList1.Add(item);
                }
            }

            return studentList1;

        }
    }
    public class Student
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int groupID { get; set; }
    }
   
}
