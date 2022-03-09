using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;
using Rookie.Ecom.DataAccessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Rookie.Ecom.Business.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IBaseRepository<ProductImage> _baseRepository;
        private readonly IMapper _mapper;

        public ProductImageService(IBaseRepository<ProductImage> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ProductImageInfoDto> AddAsync(ProductImageInfoDto productImageInfoDto)
        {
            Regex getImageIdFromGoogleDrive = new Regex(@"\/d\/(.+)\/");
            Match id = getImageIdFromGoogleDrive.Match(productImageInfoDto.ImageUrl);
            productImageInfoDto.ImageUrl =  id.ToString().TrimStart('/', 'd').Trim('/');
            //productImageInfoDto.PictureUrl
            var productImage = _mapper.Map<ProductImage>(productImageInfoDto);
            var item = await _baseRepository.AddAsync(productImage);
            return _mapper.Map<ProductImageInfoDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductImageInfoDto>> GetAllAsync()
        {
            var images = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<ProductImageInfoDto>>(images);
        }

        public async Task<IEnumerable<ProductImageInfoDto>> GetAllByProductIdAsync(Guid productId)
        {


            var allImages = await _baseRepository.GetAllAsync();
            var images = allImages.Where(x => x.ProductId == productId);
            

            return _mapper.Map<List<ProductImageInfoDto>>(images);
        }

        public async Task<ProductImageInfoDto> GetByIdAsync(Guid id)
        {
            var productImage = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<ProductImageInfoDto>(productImage);
        }

        public async Task<ProductImageInfoDto> GetByProductIdAsync(Guid productId)
        {
            var images = await _baseRepository.GetAllAsync();
            var firstImage = images.Where(x => x.ProductId == productId).First();

            return _mapper.Map<ProductImageInfoDto>(firstImage);
        }

       /* public async Task<PagedResponseModel<ProductImageInfoDto>> PagedQueryAsync(string name, int page, int limit)
        {
            throw new NotImplementedException();
        }*/

        public async Task UpdateAsync(ProductImageInfoDto productImageInfoDto)
        {
            var productImage = _mapper.Map<ProductImage>(productImageInfoDto);
            await _baseRepository.UpdateAsync(productImage);
        }

        public async Task UpdateByIdAsync(Guid id, UpdateProductImageDto updateProductImageDto)
        {
            var productImage = await _baseRepository.GetByIdAsync(id);

            _mapper.Map(updateProductImageDto, productImage);
            productImage.UpdatedDate = DateTime.Now;

            await _baseRepository.UpdateAsync(productImage);
        }
    }
}
