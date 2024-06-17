using CreArtHub.App.Interactors;
using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Dto;
using CreArtHub.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreArtHub.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostInteractor postInteractor;
        private readonly UserInteractor userInteractor;
        private readonly FeedBackInteractor feedBackInteractor;
		private readonly FileInteractor fileinteractor;
        private readonly SubscriptionInteractor subscriptionInteractor;
        private readonly SubscriberInteractor subscriberInteractor;

		public HomeController(PostInteractor postInteractor, 
            UserInteractor userInteractor, 
            FeedBackInteractor feedBackInteractor, 
            FileInteractor fileinteractor, 
            SubscriptionInteractor subscriptionInteractor,
			SubscriberInteractor subscriberInteractor)
        {
            this.postInteractor = postInteractor;
            this.userInteractor = userInteractor;
			this.feedBackInteractor = feedBackInteractor;
            this.fileinteractor = fileinteractor;
            this.subscriptionInteractor = subscriptionInteractor;
            this.subscriberInteractor = subscriberInteractor;
		}

        // GET: Home
        public ActionResult Index()
        {
            var homeModel = new HomeModel()
            {
                PostDtos = postInteractor.GetCurrentCountNoSub(3).Result.Value.ToList(),
                FileDtos = fileinteractor.GetCurrentCountNoSub(5).Result.Value.ToList()
            };
            return View(homeModel);
        }

        public ActionResult About()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> createSub(int SubscriptionId,int profileUserId, string UserEmail)
        {
            var UserId = userInteractor.GetByEmail(UserEmail).Result.Value.Id;
            try
            {
                SubscriberDto sub = new SubscriberDto()
                {
					SubscriptionId = SubscriptionId,
                    UserId = UserId
                };
                await subscriberInteractor.Create(sub);
				return RedirectToAction(nameof(Profile), new { id = profileUserId });
			}
            catch
            {
                return RedirectToAction(nameof(Profile), new { id = profileUserId });
            }
		}

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Profile/
		public async Task<IActionResult> Profile(int? id)
		{
            Response<UserDto> userResponse;
            Response<IEnumerable<SubscriptionDto>> subscriptionResponse;
            if (id == null)
            {
                userResponse = await userInteractor.GetByEmail(User.Identity.Name);
                subscriptionResponse = await subscriptionInteractor.GetAllByUserEmail(User.Identity.Name);
            } else {
                userResponse = await userInteractor.GetById((int)id);
                subscriptionResponse = await subscriptionInteractor.GetAllByUserId((int)id);
            }
            ProfileModel profile = new ProfileModel()
            {
                User = userResponse.Value,
            };
            if (subscriptionResponse.Value.Any())
            {
                profile.Subscriptions = subscriptionResponse.Value.ToList();
            }

            return View(profile);
		}

		// GET: Home/Contact/
		public async Task<IActionResult> Contact()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await userInteractor.GetByEmail(User.Identity.Name);
                FeedBackDto feedbackDto = new FeedBackDto() 
                { 
                    UserEmail = user.Value.Email,
                    UserName = user.Value.Name
                };
                return View(feedbackDto);
            }
			return View();
		}

		[HttpPost]
		// POST: Home/Contact/
		public async Task<IActionResult> Contact([Bind("id,UserName, UserEmail, Title, Context, isReaded")] FeedBackDto feedBackDto)
		{
			if (ModelState.IsValid)
			{
                await feedBackInteractor.Create(feedBackDto);
				return RedirectToAction(nameof(Index));
			}
			return View();
		}

		public async Task<IActionResult> Portfolio(int? id)
		{
			Response<IEnumerable<FileDto>> response;
            if (!User.IsInRole("admin"))
            {
                if (id == null)
                {
                    return NotFound();
                }
                else
                {
					response = await fileinteractor.GetAllByUserId((int)id);
                }
            }
            else 
            {
                response = await fileinteractor.GetAll();
            }
			return View(response.Value);
		}
	}
}
