using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaasService.Models;
using KaasService.Repositories;
using System.Linq;


namespace KaasService.Repositories
{
    public interface IKaasRepository
    {
        Task<List<Kaas>> FindAllAsync();
        Task<Kaas> FindByIdAsync(int id);
        Task<List<Kaas>> FindBySmaakAsync(string begin);
        Task UpdateAsync(Kaas brouwer);
    }
}
