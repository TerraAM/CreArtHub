using CreArtHub.App.Interactors;
using CreArtHub.Shared.Dto;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CreArtHub.Shared.Model;

namespace CreArtHub.Client.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserInteractor interactor;
		private readonly RoleInteractor roleInteractor;
		public AccountController(UserInteractor interactor, RoleInteractor roleInteractor)
		{
			this.interactor = interactor;
			this.roleInteractor = roleInteractor;
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				var userResponce = await interactor.GetByEmail(model.Email);
				UserDto user = userResponce.Value;
				if (user == null)
				{
					// добавляем пользователя в бд
					user = new UserDto
					{
						Name = model.Name,
						Email = model.Email,
						Password = model.Password
					};
					RoleDto userRole = roleInteractor.GetByName("user").Result.Value;
					if (userRole != null)
						user.RoleId = userRole.Id;

					await interactor.Create(user);

					user.Role = userRole;

					await Authenticate(user); // аутентификация

					return RedirectToAction("Index", "Home");
				}
				else
					ModelState.AddModelError("", "Некорректные логин и(или) пароль");
			}
			return View(model);
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				var user = interactor.CheckEmailAndPassword(model.Email, model.Password).Result.Value;
				if (user != null)
				{
					await Authenticate(user); // аутентификация

					return RedirectToAction("Index", "Home");
				}
				ModelState.AddModelError("", "Некорректные логин и(или) пароль");
			}
			return View(model);
		}
		public async Task<IActionResult> Logout()
		{
			// Выполнить деавторизацию
			await HttpContext.SignOutAsync();

			// Перенаправить на страницу после деавторизации (например, на главную страницу)
			return RedirectToAction("Login", "Account");
		}
		private async Task Authenticate(UserDto user)
		{
			// создаем один claim
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
			};
			// создаем объект ClaimsIdentity
			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
				ClaimsIdentity.DefaultRoleClaimType);
			// установка аутентификационных куки
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}
        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
