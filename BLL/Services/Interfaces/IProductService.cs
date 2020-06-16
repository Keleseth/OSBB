using System;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductAsync(Guid id);
        Task<ProductDTO> AddProductAsync(ProductDTO region);
        Task RemoveProductAsync(Guid id);
    }
}