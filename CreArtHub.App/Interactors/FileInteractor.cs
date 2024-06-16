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
    public class FileInteractor
    {
        private IRepository<File> repos;
        private IUnitWork unitWork;

        public FileInteractor(IRepository<File> repos, IUnitWork unitWork)
        {
            this.repos = repos;
            this.unitWork = unitWork;
        }
        public async Task<Response> Create(FileDto FileDto)
        {
            var response = new Response<FileDto>();
            try
            {
                await repos.CreateAsync(FileDto.ToEntity());
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

        public async Task<Response> DeleteByPath(string Path)
        {
            try
            {
                var file = await repos.GetAllAsync();
                await repos.DeleteByIdAsync(file.FirstOrDefault(x=>x.FilePath == Path).Id);
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

        public async Task<Response<FileDto>> GetById(int id)
        {
            try
            {
                var entity = await repos.GetByIdAsync(id);
                return new Response<FileDto>()
                {
                    IsSuccess = true,
                    Value = entity.ToDto()
                };
            }
            catch (NullReferenceException ex)
            {
                return new Response<FileDto>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Запись не найдена"
                };
            }
            catch (Exception ex)
            {
                return new Response<FileDto>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }

        public async Task<Response<IEnumerable<FileDto>>> GetAll()
        {
            try
            {
                var list = await repos.GetAllAsync();
                if (list == null)
                    return new Response<IEnumerable<FileDto>>()
                    {
                        IsSuccess = true,
                        Value = null
                    };
                else
                    return new Response<IEnumerable<FileDto>>()
                    {
                        IsSuccess = true,
                        Value = list.Select(e => e.ToDto())
                    };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<FileDto>>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }
		public async Task<Response<IEnumerable<FileDto>>> GetAllByUserId(int id)
		{
			try
			{
				var list = await repos.GetAllAsync();
				if (list == null)
					return new Response<IEnumerable<FileDto>>()
					{
						IsSuccess = true,
						Value = null
					};
				else
					return new Response<IEnumerable<FileDto>>()
					{
						IsSuccess = true,
						Value = list.Where(x=>x.Post.AuthorId == id).Select(e => e.ToDto())
					};
			}
			catch (Exception ex)
			{
				return new Response<IEnumerable<FileDto>>()
				{
					IsSuccess = false,
					ErrorInfo = ex.Message,
					ErrorMessage = "Ошибка получения"
				};
			}
		}

		public async Task<Response<IEnumerable<FileDto>>> GetAllByPostId(int postId)
        {
            try
            {
                var list = await repos.GetAllAsync();
                if (list == null)
                    return new Response<IEnumerable<FileDto>>()
                    {
                        IsSuccess = true,
                        Value = null
                    };
                else
                    return new Response<IEnumerable<FileDto>>()
                    {
                        IsSuccess = true,
                        Value = list.Where(x=>x.PostId == postId).Select(e => e.ToDto())
                    };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<FileDto>>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }
        public async Task<Response<IEnumerable<FileDto>>> GetCurrentCountNoSub(int count)
        {
            try
            {
                var list = await repos.GetAllAsync();
                if (list == null)
                    return new Response<IEnumerable<FileDto>>()
                    {
                        IsSuccess = true,
                        Value = null
                    };
                else
                    return new Response<IEnumerable<FileDto>>()
                    {
                        IsSuccess = true,
                        Value = list.Take(count).Select(e => e.ToDto())
                    };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<FileDto>>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }
        public async Task<Response> Update(FileDto FileDto)
        {
            try
            {
                await repos.UpdateAsync(FileDto.ToEntity());
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
