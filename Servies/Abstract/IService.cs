using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Abstract
{
	public partial interface IService<EntityType, IDType, TDbContext>
	{
		EntityType Get(IDType id);
		ICollection<EntityType> GetList();
		void Create(EntityType entity);
		void Delete(IDType id);
	}
    public partial interface IService<EntityType, IDType, TDbContext>
    {
		Task<EntityType> GetAsync(IDType id);
		Task<ICollection<EntityType>> GetListAsync();
		Task CreateAsync(EntityType entity);
		Task DeleteAsync(IDType id);
	}
}
