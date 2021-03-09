using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using triaCSharp.Data;
using TriaCSharp.Models;

namespace TriaCSharp.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository (DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Cliente[]> GetAllClientesAsync()
        {
            IQueryable<Cliente> query = _context.Clientes;

            

            query = query.AsNoTracking()
                         .OrderBy(c => c.createdAt);
            //ordenando por data

            return await query.ToArrayAsync();
        }

        public async Task<Cliente[]> GetAllClientesNameAsync()
        {
            IQueryable<Cliente> query = _context.Clientes;

            

            query = query.AsNoTracking()
                         .OrderBy(c => c.Name);
            //ordenando por data

            return await query.ToArrayAsync();
        }

        public async Task<Produto[]> GetAllProdutosAsync()
        {
            IQueryable<Produto> query = _context.Produtos;

            

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);
            //ordenando por data

            return await query.ToArrayAsync();
        }

        public async Task<Cliente> GetClienteAsyncById(int cliId)
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query.Include(a => a.Produto);

            query = query.AsNoTracking()
                         .OrderBy(cli => cli.createdAt)
                         .Where(cli => cli.Id == cliId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
