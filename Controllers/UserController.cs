using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCommune.DataModels.Users;
using MyCommune.Models;
using MyCommune.Models.ViewModel.User;
using MyCommune.Services.Account;
using MyCommune.Services.Users;

namespace MyCommune.Controllers
{

    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper, IAccountService accountService)
        {
            _userService = userService;
            _mapper = mapper;
            _accountService = accountService;
        }
        public IActionResult Index()
        {
            var data = _userService.GetAll().ToList();
            List<UserDetailViewModel> lstData = _mapper.Map<List<User>, List<UserDetailViewModel>>(data);
            return View(lstData);
        }

        [HttpGet]
        public ViewResult GetView(Guid id)
        {
            var user = _userService.GetUser(id);
            UserDetailViewModel udv = _mapper.Map<User, UserDetailViewModel>(user);
            return View("~/Views/User/User.cshtml", udv);
        }

        [HttpPost]
        public IActionResult UpdateUser(UserDetailViewModel udvm)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserDetailViewModel, User>(udvm);
                ServiceResponse svc = _userService.UpdateUser(user);
                if (svc.Status == StatusType.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", svc.ErrorMessage);
                    return View("~/Views/User/User.cshtml", udvm);
                }

            }
            return View("~/Views/User/User.cshtml", udvm);
        }


    }
}
