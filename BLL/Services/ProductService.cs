using System;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork.Interfaces;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(
                              nameof(unitOfWork));
        }

        public async Task<ProductDTO> GetProductAsync(Guid id)
        {
            var region = await GetByIdAsync(id);

            return new ProductDTO()
            {
                Id = region.Id,
                Description = region.Description,
                Name = region.Name
            };
        }

        public async Task<ProductDTO> AddProductAsync(ProductDTO region)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var entity = new Product()
            {
                Description = region.Description,
                Name = region.Name
            };

            var result = await _unitOfWork.InsertAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ProductDTO()
            {
                Id = result.Id,
                Description = result.Description,
                Name = result.Name
            };
        }

        public async Task RemoveProductAsync(Guid id)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var region = await GetByIdAsync(id);
            _unitOfWork.Remove(region);
            await _unitOfWork.CommitAsync();
        }

        private async Task<Product> GetByIdAsync(Guid id)
        {
            var region = await _unitOfWork.GetByIdAsync<Product>(id);

            if (region == null)
            {
                throw new Exception("Product with following id was not found");
            }

            return region;
        }
    }
}