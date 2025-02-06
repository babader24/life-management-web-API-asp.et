using Task_managemant_web_API.Models;

namespace Task_managemant_web_API.Repository.Base
{
	public interface IRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();

		Task<T>	GetByIdAsync(int id);

		Task<T> AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task<User> GetAllUserInfoByIdAsync(int id);
	}
}
