using CreArtHub.App.Data;
using CreArtHub.App.Mappers;
using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Data;
using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.App.Interactors
{
    public class ProductInteractor
    {
        private IRepository<Product> repos;
        private IUnitWork unitWork;

        public ProductInteractor(IRepository<Product> repos, IUnitWork unitWork)
        {
            this.repos = repos;
            this.unitWork = unitWork;
        }
        public async Task<Response> Create(ProductDto Dto)
        {
            var response = new Response<ProductDto>();
            try
            {
                await repos.CreateAsync(Dto.ToEntity());
                await unitWork.Commit();
                return new Response() { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка создания"
                };
            }
        }
        public async Task<Response> Delete(int id)
        {
            try
            {
                await repos.DeleteByIdAsync(id);
                await unitWork.Commit();
                return new Response()
                {
                    IsSuccess = true
                };
            }
            catch (NullReferenceException ex)
            {
                return new Response()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Запись не найдена"
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка удаления"
                };
            }
        }
        public async Task<Response<ProductDto>> GetById(int id)
        {
            try
            {
                var entity = await repos.GetByIdAsync(id);
                return new Response<ProductDto>()
                {
                    IsSuccess = true,
                    Value = entity.ToDto()
                };
            }
            catch (NullReferenceException ex)
            {
                return new Response<ProductDto>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Запись не найдена"
                };
            }
            catch (Exception ex)
            {
                return new Response<ProductDto>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }

        public async Task<Response<IEnumerable<ProductDto>>> GetAll()
        {
            try
            {
                var list = await repos.GetAllAsync();
                if (list == null)
                    return new Response<IEnumerable<ProductDto>>()
                    {
                        IsSuccess = true,
                        Value = null
                    };
                else
                    return new Response<IEnumerable<ProductDto>>()
                    {
                        IsSuccess = true,
                        Value = list.Select(e => e.ToDto())
                    };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<ProductDto>>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }

        public async Task<Response> Update(ProductDto Dto)
        {
            try
            {
                await repos.UpdateAsync(Dto.ToEntity());
                await unitWork.Commit();
                return new Response()
                {
                    IsSuccess = true
                };
            }
            catch (NullReferenceException ex)
            {
                return new Response()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Запись не найдена"
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }
    }
}
