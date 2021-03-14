using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFAPPS.Domain
{
    public interface IDatabaseObject<T> where T : class
    {
        void Create(T data);
        void Delete(int id);
        void Delete(T data);
        void Update(T data);
        List<T> GetAllData();
        T GetDataById(int id);
    }
}
