using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriaCSharp.Models;

namespace TriaCSharp.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Cliente[]> GetAllClientesAsync();
        Task<Cliente[]> GetAllClientesNameAsync();
        Task<Cliente> GetClienteAsyncById(int cliId);

        Task<Produto[]> GetAllProdutosAsync();
    }
}
