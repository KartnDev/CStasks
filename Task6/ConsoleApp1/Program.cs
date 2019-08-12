//********************************************************************************
//* Check App.config and <connectionStrings>                                     *
//* it has non-defualt configuration connectionString=...                        *
//* DBConsoleApi class have Fill_DB method which can be invoked once to fill DB  *
//* Cherkasov Dmitry | Task 6 | ORM | Entity Framework                           *
//********************************************************************************


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

    public class DBConsoleApi
    {
        
        private static int StudentCount; 
        private const int GroupCount = 3;
        public DBConsoleApi()
        {
            StudentCount = 0;
            using (StudentContext dbSession = new StudentContext("DbConnection"))
            {
                foreach (var student in dbSession.Students)
                {
                    StudentCount++;
                }
            }
        }
        public int GetStudentCount()
        {
            return StudentCount;
        }
        private List<int> GetValidStudentsIDAtGroup(StudentContext db, int GroupID)
        {
            var result = new List<int>();
            foreach(var item in db.Students)
            {
                if(item.groupID == GroupID)
                {
                    result.Add(item.ID);
                }
            }
            return result;
        }
        private int ReadIntWithCheckRange(List<int> ValidIndexes)
        {
            try
            {
                int ReadedInt = int.Parse(Console.ReadLine());
                if (!ValidIndexes.Contains(ReadedInt))
                {
                    Console.WriteLine("Wrong key given...");
                    return ReadIntWithCheckRange(ValidIndexes);
                }
                return ReadedInt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ReadIntWithCheckRange(ValidIndexes);
            }
        }
        private int ReadIntWithCheckRange(int Range)
        {
            try
            {
                int ReadedInt = int.Parse(Console.ReadLine());
                if (ReadedInt < 0 || ReadedInt > Range)
                {
                    Console.WriteLine("Wrong key given...");
                    return ReadIntWithCheckRange(Range);
                }
                return ReadedInt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ReadIntWithCheckRange(Range);
            }
        }
        public void ViewAllStudentAtGroup(StudentContext db, int GroupID)
        {
            foreach (var student in db.Students)
            {
                if (student.groupID == GroupID)
                {
                    Console.WriteLine("Student {0} is {1}", student.ID, student.name);
                }
            }
        }
        public void ViewAllStudentsByGroups(StudentContext db)
        {
            foreach (var group in db.Groups)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("Group №{0} is {1}:", group.ID, group.name);
                Console.WriteLine("========================================");
                Console.WriteLine();
                foreach (var student in db.Students)
                {
                    if (student.groupID == group.ID)
                    {
                        Console.WriteLine("Student {0} is {1} from {2}",
                            student.ID, student.name, group.name);
                    }
                }
                Console.WriteLine('\n');
            }
        }
        public void ViewAllGroups(StudentContext db)
        {
            foreach (var group in db.Groups)
            {
                Console.WriteLine("Group №{0} is {1}", group.ID, group.name);
            }
        }
        private static void FillContent()
        {
            using (StudentContext db = new StudentContext("DbConnection"))
            {
                db.Groups.Add(new Group { ID = 1, name = "RadioPhysics" });
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

        }
        public void AddStudentToDB(string studentName, int GroupID)
        {
            using (StudentContext dbSession = new StudentContext("DbConnection"))
            {
                dbSession.Students.Add(new Student { name = studentName, groupID = GroupID });
                dbSession.SaveChanges();
            }
            StudentCount++;
        }
        public void RemoveStudentFromDB(int StudentID)
        {
            using (StudentContext dbSession = new StudentContext("DbConnection"))
            {
                var toDelete = new Student { ID = StudentID };
                dbSession.Students.Attach(toDelete);
                dbSession.Students.Remove(toDelete);
                dbSession.SaveChanges();
            }
            StudentCount--;
        }
        private int DoBinaryVote(string message)
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
        public void StartAskSession()
        {
            using (StudentContext dbView = new StudentContext("DbConnection"))
            {
                /// 1)
                
                ViewAllStudentsByGroups(dbView);
                // 2) Ask 
                Console.WriteLine("\n");

                if (DoBinaryVote
                     ("Choose one step: \n 1. Add Student (key1)\t\t2. Remove Student (key2)") == 1)
                {
                    //3)
                    Console.WriteLine("\nChoose group ID... (1 - {0})", GroupCount);
                    ViewAllGroups(dbView);
                    int groupID = ReadIntWithCheckRange(GroupCount);
                    Console.WriteLine("\nInsert student name...");
                    string name = Console.ReadLine();
                    AddStudentToDB(name, groupID);
                    Console.WriteLine("Студент " + name + "добавлен..\n");
                    ViewAllStudentsByGroups(dbView);
                }
                else
                {
                    //4)
                    Console.WriteLine("\nChoose group ID... (1 - {0})", GroupCount);
                    ViewAllGroups(dbView);
                    int groupID = ReadIntWithCheckRange(GroupCount);
                    ViewAllStudentAtGroup(dbView, groupID);
                    Console.WriteLine("\nInsert student ID...");
                    int studentID = ReadIntWithCheckRange(GetValidStudentsIDAtGroup(dbView, groupID));
                    RemoveStudentFromDB(studentID);
                    ViewAllStudentsByGroups(dbView);
                }
            }
            if (DoBinaryVote
                      ("\nChoose one step: \n 1. Return to menu (key1)\t\t2. Exit (key2)") == 1)
            {
                Console.WriteLine("\n\n\n========================================");
                StartAskSession();
            }

        }
    }

    public class Program
    {
        
        public static void Main(string[] args)
        {
            DBConsoleApi DbSession = new DBConsoleApi();
            DbSession.StartAskSession();
        }
    }
}
