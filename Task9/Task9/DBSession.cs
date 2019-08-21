using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Task9
{
    public class StudentContext : DbContext
    {
        public StudentContext(string connection) : base(connection)
        { }
        public DbSet<Student> Students { get; set; }
    }

    public class DBSession : IDBSession
    {
        private const string ConnectionString =
            @"Server=SQL1;Database=StudentDB;Trusted_Connection=True;";
        public Task EditData(int ID, string StudentName, int groupID, string newName, int newGroup)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> GetDataListByGroup(int Group)
        {
            using (StudentContext context = new StudentContext(ConnectionString))
            {
                List<Student> studentList = await context.Students.ToListAsync();
                return studentList;
            }
        }
        public List<Student> students(int group)
        {
            using (StudentContext context = new StudentContext(ConnectionString))
            {
                List<Student> studentList = new List<Student>();

                foreach (var item in context.Students)

                    if (item.groupID == group)
                    {
                        studentList.Add(item);
                    }
                return studentList;
            }

           
        }
    
    public async Task PushData(string StudentName, int GroupID)
    {
        var pushStudent = new Student() { name = StudentName, groupID = GroupID };
        using (StudentContext context = new StudentContext(ConnectionString))
        {
            context.Students.Add(pushStudent);
        }
    }
    public async Task RemoveData(int argID, string StudentName, int GroupID)
    {
        var pushStudent = new Student() { name = StudentName, groupID = GroupID, ID = argID };
        using (StudentContext context = new StudentContext(ConnectionString))
        {
            context.Students.Remove(pushStudent);
        }
    }
}
}
