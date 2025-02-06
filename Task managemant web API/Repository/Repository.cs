using Microsoft.EntityFrameworkCore;
using Task_managemant_web_API.Data;
using Task_managemant_web_API.Models;
using Task_managemant_web_API.Repository.Base;

namespace Task_managemant_web_API.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppDbContext _Context;
		private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext Context)
        {
            _Context = Context;
			_dbSet = _Context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			await _Context.SaveChangesAsync();
			return entity;
		}

		public async Task DeleteAsync(T entity)
		{
			_dbSet.Remove(entity);
			await _Context.SaveChangesAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return	await _dbSet.ToListAsync();
		}

		public async Task<User> GetAllUserInfoByIdAsync(int id)
		{
			var User =await _Context.Users.Include(u => u.stickyNotes)
									   .Include(u => u.Tasks)
									   .Include(u => u.Notebooks)
		                               .Include(u => u.habits)
									  .FirstOrDefaultAsync(u => u.Id == id);
			
			return User;
		}

		public async Task<T> GetByIdAsync(int id)
		{
	
			return await _dbSet.FindAsync(id);
		}

		public async Task UpdateAsync(T entity)
		{
			_dbSet.Attach(entity);
			_Context.Entry(entity).State = EntityState.Modified;
			await _Context.SaveChangesAsync();
		}

	}
}
