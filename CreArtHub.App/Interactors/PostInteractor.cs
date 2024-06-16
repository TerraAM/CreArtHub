using CreArtHub.App.Data;
using CreArtHub.App.Mappers;
using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Data;
using CreArtHub.Shared.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.App.Interactors
{
    public class PostInteractor
    {
        private IRepository<Post> repos;
        private IUnitWork unitWork;

        public PostInteractor(IRepository<Post> repos, IUnitWork unitWork)
        {
            this.repos = repos;
            this.unitWork = unitWork;
        }
        public async Task<Response> Create(PostDto Dto)
        {
            var response = new Response<PostDto>();
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
        public async Task<Response<PostDto>> GetById(int id)
        {
            try
            {
                var entity = await repos.GetByIdAsync(id);
                return new Response<PostDto>()
                {
                    IsSuccess = true,
                    Value = entity.ToDto()
                };
            }
            catch (NullReferenceException ex)
            {
                return new Response<PostDto>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Запись не найдена"
                };
            }
            catch (Exception ex)
            {
                return new Response<PostDto>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }

        public async Task<Response<IEnumerable<PostDto>>> GetAll()
        {
            try
            {
                var list = await repos.GetAllAsync();
                if (list == null)
                    return new Response<IEnumerable<PostDto>>()
                    {
                        IsSuccess = true,
                        Value = null
                    };
                else
                    return new Response<IEnumerable<PostDto>>()
                    {
                        IsSuccess = true,
                        Value = list.Select(e => e.ToDto())
                    };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<PostDto>>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }

        public async Task<Response<IEnumerable<PostDto>>> GetAllNoSub()
        {
            try
            {
                var list = await repos.GetAllAsync();
                if (list == null)
                    return new Response<IEnumerable<PostDto>>()
                    {
                        IsSuccess = true,
                        Value = null
                    };
                else
                    return new Response<IEnumerable<PostDto>>()
                    {
                        IsSuccess = true,
                        Value = list.Where(x=>!x.BySub).Select(e => e.ToDto())
                    };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<PostDto>>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }

        public async Task<Response<IEnumerable<PostDto>>> GetAllBySearch(string searchAuthor, string searchTitle)
        {
            try
            {
                var list = await repos.GetAllAsync();
                if (list == null)
                    return new Response<IEnumerable<PostDto>>()
                    {
                        IsSuccess = true,
                        Value = null
                    };
                else
                {
                    if (!String.IsNullOrEmpty(searchAuthor))
                    {
                        list = list.Where(p => p.Author.Name.ToLower().Contains(searchAuthor.ToLower()));
                    }
                    if (!String.IsNullOrEmpty(searchTitle))
                    {
                        list = list.Where(p => p.Title.ToLower().Contains(searchTitle.ToLower()));
                    }
                    return new Response<IEnumerable<PostDto>>()
                    {
                        IsSuccess = true,
                        Value = list.Select(e => e.ToDto())
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<PostDto>>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }

        public async Task<Response<IEnumerable<PostDto>>> GetAllBySearchNoSub(string searchAuthor, string searchTitle)
        {
            try
            {
                var list = await repos.GetAllAsync();
                if (list == null)
                    return new Response<IEnumerable<PostDto>>()
                    {
                        IsSuccess = true,
                        Value = null
                    };
                else 
                {
                    if (!String.IsNullOrEmpty(searchAuthor))
                    {
                        list = list.Where(p => !p.BySub && p.Author.Name.ToLower().Contains(searchAuthor.ToLower()));
                    }
                    if (!String.IsNullOrEmpty(searchTitle))
                    {
                        list = list.Where(p => !p.BySub && p.Title.ToLower().Contains(searchTitle.ToLower()));
                    }
                    return new Response<IEnumerable<PostDto>>()
                    {
                        IsSuccess = true,
                        Value = list.Select(e => e.ToDto())
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<PostDto>>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }

        public async Task<Response<IEnumerable<PostDto>>> GetAllByAuthorEmail(string email)
        {
            try
            {
                var list = await repos.GetAllAsync();
                if (list == null)
                    return new Response<IEnumerable<PostDto>>()
                    {
                        IsSuccess = true,
                        Value = null
                    };
                else
                    return new Response<IEnumerable<PostDto>>()
                    {
                        IsSuccess = true,
                        Value = list.Where(x=>x.Author.Email == email).Select(e => e.ToDto())
                    };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<PostDto>>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка получения"
                };
            }
        }

        public async Task<Response<IEnumerable<PostDto>>> GetCurrentCountNoSub(int count)
		{
			try
			{
				var list = await repos.GetAllAsync();
                if (list == null)
                    return new Response<IEnumerable<PostDto>>()
                    {
                        IsSuccess = true,
                        Value = null
                    };
                else
                    return new Response<IEnumerable<PostDto>>()
                    {
                        IsSuccess = true,
                        Value = list.Where(x=>!x.BySub).Take(count).Select(e => e.ToDto())
					};
			}
			catch (Exception ex)
			{
				return new Response<IEnumerable<PostDto>>()
				{
					IsSuccess = false,
					ErrorInfo = ex.Message,
					ErrorMessage = "Ошибка получения"
				};
			}
		}

		public async Task<Response> Update(PostDto Dto)
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
