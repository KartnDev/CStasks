using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task9
{
    public interface IDBSession
    {
        Task PushData(string StudentName, int groupID);
        Task<List<Student>> GetDataListByGroup(int Group);
        Task EditData(int ID, string StudentName, int groupID, string newName, int newGroup);
        Task RemoveData(int ID, string StudentName, int groupID);
    }
}
