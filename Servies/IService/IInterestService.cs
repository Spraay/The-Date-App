using Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IInterestService
    {
        void Add(string name);

        void Add(Interest i);

        void Update(Guid id, string name);

        void Delete(Guid id);

        Interest Get(Guid id);

        Interest GetFirstByName(string name);

        List<Interest> GetList();

        bool Any();
        Task<List<Interest>> GetListAsync();
    }
}
