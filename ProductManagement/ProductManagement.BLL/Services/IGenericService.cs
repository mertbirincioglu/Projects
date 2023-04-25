using ProductManagement.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.BLL.Services
{
    public  interface IGenericService<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        //Task<IList<T>> GetAllByFilterAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T dto);
        Task<T> UpdateAsync(T dto);
        Task<T> DeleteAsync(T dto);
    }
}
