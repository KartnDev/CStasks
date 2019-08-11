using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EntityApp
{
 
    public class Student
    {
        public int ID { get; set; }
        public int groupID { get; set; }
        public string name { get; set; }
    }



    public class Group
    {
        public int ID { get; set; }
        public string name { get; set; }
    }



    public class StudentContext : DbContext
    {
        public StudentContext(string nameOrConnection) : base("DbConnection1"){}
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
    public class Program
    {
        private static int StudentCount;

        public Program()
        {
            StudentCount = 0;
        }
        private static void ViewAllStudentAtGroup(StudentContext db, int GroupID)
        {
            foreach (var student in db.Students)
            {
                if (student.groupID == GroupID)
                {
                    Console.WriteLine("Student {0} is {1}", student.ID, student.name);
                } 
            }
        }
        private static void ViewAllStudentsByGroups(StudentContext db)
        {
            foreach (var group in db.Groups)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("Group №{0} is {1}", group.ID, group.name);
                Console.WriteLine();
                foreach (var student in db.Students)
                {
                    if (student.groupID == group.ID)
                    {
                        Console.WriteLine("Student {0} is {1} from {2}",
                            student.ID, student.name, group.name);
                    }
                }
            }
        }
        private static void ViewAllGroups(StudentContext db)
        {
            foreach(var group in db.Groups)
            {
                Console.WriteLine("Group №{0} is {1}", group.ID, group.name);
            }
        }
        private static void FillContent(StudentContext db)
        {
            db.Groups.Add( new Group { ID = 1, name = "RadioPhysics" });
            db.Groups.Add(new Group { ID = 2, name = "MicroElectrics" });
            db.Groups.Add(new Group { ID = 3, name = "GeneralPhysics" });
            // TODO ЗАПОЛНЕНИЕ ЦАРЯМИ РОССИИ
            db.Students.Add(new Student { ID = 1, name = "zxc", groupID = 1 });
            db.Students.Add(new Student { ID = 2, name = "sdsd", groupID = 3 });
            db.Students.Add(new Student { ID = 3, name = "asfsdfad", groupID = 1 });
            db.Students.Add(new Student { ID = 4, name = "er", groupID = 2 });
            db.Students.Add(new Student { ID = 5, name = "dsfdsf", groupID = 2 });
            db.Students.Add(new Student { ID = 6, name = "afsdfsafdsf", groupID = 1 });
            db.Students.Add(new Student { ID = 7, name = "1r32rewf", groupID = 3 });
            db.Students.Add(new Student { ID = 8, name = "5urtc", groupID = 2 });
            db.Students.Add(new Student { ID = 9, name = "gdsfghgfh", groupID = 1 });
            db.Students.Add(new Student { ID = 10, name = "Vcxvc", groupID = 3 });
            db.Students.Add(new Student { ID = 11, name = "efec", groupID = 1 });
            db.SaveChanges();

        }
        private static void AddStudentToDB(StudentContext db, string studentName, int GroupID)
        {
            db.Students.Add(new Student { name = studentName, groupID = GroupID });
            db.SaveChanges();
            StudentCount++;
        }
        private static void RemoveStudentFromDB(StudentContext db, int StudentID)
        {
            // TODO check ID student should be legal
            var toDelete = new Student { ID = StudentID};
            db.Entry(toDelete).State = EntityState.Deleted;
            db.SaveChanges();
            StudentCount--;
        }
        private static int DoBinaryVote(string message)
        {
            Console.WriteLine(message);
            string vote = Console.ReadLine();

            if (vote == "1")
            {
                Console.WriteLine("You choose first action!");
                return 1;
            }
            else if (vote == "2")
            {
                Console.WriteLine("You choose second action!");
                return 2;
            }
            else
            {
                Console.WriteLine("Wrong key ..\n");
                DoBinaryVote(message);
            }
            return 0;
        }




        public static void Main(string[] args)
        {
            using (StudentContext db = new StudentContext("DbConnection"))
            {
                /// 1)вывод студентов
                /// группа - номер
                /// студент 1 ФИО
                /// студент 2 ФИО
                /// ....
                /// студент Н фио
                /// группа - номер 
                /// ...........
                
                ViewAllStudentsByGroups(db);



                // 2) вопрос 
               Console.WriteLine("\n");
               if( DoBinaryVote
                    ("Choose one step: \n 1. Add Student (key1)\t\t2. Remove Student (key2)") == 1)
                {
                    //3)
                    Console.WriteLine("\nChoose group ID..");
                    ViewAllGroups(db);
                    string groupID = Console.ReadLine();
                    Console.WriteLine("\nInsert student name...");
                    string name = Console.ReadLine();
                    AddStudentToDB(db, name, int.Parse(groupID));
                }
                else
                {
                    //4)
                    Console.WriteLine("\nChoose group ID..");
                    ViewAllGroups(db);
                    string groupID = Console.ReadLine();
                    ViewAllStudentAtGroup(db, int.Parse(groupID));
                    Console.WriteLine("\nInsert student ID...");
                    string studentID = Console.ReadLine();

                }
                Console.Read();
            } 
        }
    }
}
