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
    public class UserInteractor
    {
        private IRepository<User> repos;
        private IUnitWork unitWork;

        public UserInteractor(IRepository<User> repos, IUnitWork unitWork)
        {
            this.repos = repos;
            this.unitWork = unitWork;
        }
        public async Task<Response> Create(UserDto Dto)
        {
            var response = new Response<UserDto>();
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
        public async Task<Response<UserDto>> GetById(int id)
        {
            try
            {
                var entity = await repos.GetByIdAsync(id);
                return new Response<UserDto>()
                {
                    IsSuccess = true,
                    Value = entity.ToDto()
                };
            }
            catch (NullReferenceException ex)
            {
                return new Response<UserDto>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Запись не найдена"
                };
            }
            catch (Exception ex)
            {
                return new Response<UserDto>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }

		public async Task<Response<UserDto>> GetByEmail(string email)
		{
			try
			{
				var response = await repos.GetAllAsync();
                var entity = response.FirstOrDefault(x => x.Email == email);
				return new Response<UserDto>()
				{
					IsSuccess = true,
					Value = entity.ToDto()
				};
			}
			catch (NullReferenceException ex)
			{
				return new Response<UserDto>()
				{
					IsSuccess = false,
					ErrorInfo = ex.Message,
					ErrorMessage = "Запись не найдена"
				};
			}
			catch (Exception ex)
			{
				return new Response<UserDto>()
				{
					IsSuccess = false,
					ErrorInfo = ex.Message,
					ErrorMessage = "Ошибка получения"
				};
			}
		}

        public async Task<Response<UserDto>> CheckEmailAndPassword(string email, string password)
        {
            try
            {
				var response = await repos.GetAllAsync();
				var entity = response.FirstOrDefault(x => x.Email == email && x.Password == password);
				return new Response<UserDto>()
                {
                    IsSuccess = true,
                    Value = entity.ToDto()
                };
            }
            catch (NullReferenceException ex)
            {
                return new Response<UserDto>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Запись не найдена"
                };
            }
            catch (Exception ex)
            {
                return new Response<UserDto>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }

        public async Task<Response<IEnumerable<UserDto>>> GetAll()
        {
            try
            {
                var list = await repos.GetAllAsync();
                if (list == null)
                    return new Response<IEnumerable<UserDto>>()
                    {
                        IsSuccess = true,
                        Value = null
                    };
                else
                    return new Response<IEnumerable<UserDto>>()
                    {
                        IsSuccess = true,
                        Value = list.Select(e => e.ToDto())
                    };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<UserDto>>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }

        public async Task<Response> Update(UserDto Dto)
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
