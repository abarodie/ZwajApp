using System.Collections.Generic;
using System.Threading.Tasks;
using ZawajApp.api.Models;

namespace ZawajApp.api.Data
{
    public interface IZawajRepository
    {
         void Add <T>(T entity) where T:class;

        void Delete <T>(T entity) where T:class;

        Task <bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int id);
    }
}