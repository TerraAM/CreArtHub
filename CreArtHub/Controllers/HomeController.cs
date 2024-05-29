using CreArtHub.App.Interactors;
using CreArtHub.Shared.Dto;
using CreArtHub.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

		public HomeController(PostInteractor postInteractor, UserInteractor userInteractor, FeedBackInteractor feedBackInteractor, FileInteractor fileinteractor, SubscriptionInteractor subscriptionInteractor)
        {
            this.postInteractor = postInteractor;
            this.userInteractor = userInteractor;
			this.feedBackInteractor = feedBackInteractor;
            this.fileinteractor = fileinteractor;
            this.subscriptionInteractor = subscriptionInteractor;
		}

        // GET: Home
        public ActionResult Index()
        {
            return View(postInteractor.GetCurrentCountNoSub(3).Result.Value);
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
        public ActionResult Create(IFormCollection collection)
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
                Subscriptions = subscriptionResponse.Value
            };

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
			if (User.Identity.IsAuthenticated)
			{
                await feedBackInteractor.Create(feedBackDto);
				return View();
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
