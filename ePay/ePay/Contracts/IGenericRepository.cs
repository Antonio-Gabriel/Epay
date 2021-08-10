using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ePay.Contracts
{
    interface IGenericRepository<Entity> where Entity:class
    {
        int Create(Entity entity);
        DataTable Read();
        int Update(Entity entity);
        int Delete(int id);
        DataTable Search(string name);
    }
}
