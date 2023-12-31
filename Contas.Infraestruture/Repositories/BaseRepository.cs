﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contas.Domain.Interfaces;
using Contas.Domain.Models;
using Contas.Infrastructure.Context;


namespace Contas.Infrastructure.Repositories
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseModel, new()
    {
        protected readonly ContaDbContext Db;
        protected readonly DbSet<TModel> DbSet;

        public BaseRepository(ContaDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TModel>();
        }

        public virtual async Task<IList<TModel>> Buscar() =>
            await DbSet.AsNoTracking().ToListAsync();

        public virtual async Task<TModel> BuscarPorId(int id) =>
             await DbSet.FindAsync(id);

        public virtual async Task Criar(TModel model)
        {

            DbSet.Add(model);
            await SaveChanges();

        }

        public virtual async Task Alterar(TModel model)
        {

            DbSet.Update(model);
            await SaveChanges();

        }

        public virtual async Task Deletar(int id)
        {
            DbSet.Remove(new TModel { Id = id });
            await SaveChanges();
        }

        public virtual async Task AlterarVarios(IEnumerable<TModel> model)
        {
            DbSet.UpdateRange(model);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
