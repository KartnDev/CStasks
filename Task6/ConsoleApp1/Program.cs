using System;
using System.Collections.Generic;
using System.Data.Entity;

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

        public StudentContext(string nameOrConnection) : base("DbConnection")
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            using (StudentContext db = new StudentContext("DbConnection"))
            {

                Group groupRadioPhysics = new Group { ID = 1, name = "RadioPhysics" };
                Group groupMicroElectrics = new Group { ID = 2, name = "MicroElectrics" };
                Group groupGeneralPhysics = new Group { ID = 3, name = "GeneralPhysics" };

                db.Groups.Add(groupRadioPhysics);
                db.Groups.Add(groupMicroElectrics);
                db.Groups.Add(groupGeneralPhysics);
                db.SaveChanges();

                var groups = db.Groups;
                Console.WriteLine("Список объектов:");
                foreach (var item in groups)
                {
                    Console.WriteLine("Group No.{0} Is {1}", item.ID, item.name);
                }


            }
            Console.ReadLine();
        }
    }
}
