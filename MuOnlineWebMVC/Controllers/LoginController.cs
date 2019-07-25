using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MuOnlineWebMVC.Models;
using MuOnlineWebMVC.Models.AccountViewModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MuOnlineWebMVC.Models.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using MuOnlineWebMVC.Extensions.Alerts;
using MuOnlineWebMVC.Models.ViewModels;
using System.Diagnostics;

namespace MuOnlineWebMVC.Controllers
{

    public class LoginController : Controller
    {
        ApplicationDbContext _dbContext { get; set; }
        public LoginController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(string returnUrl)
        {
            var username = User.Identity.IsAuthenticated;

            if (username == true)
                return RedirectToAction(nameof(Error), new { Message = "Você tem que estar deslogado para executar essa operação" });
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            
            var logar = await _dbContext.MembInfo.Where(p => p.MembId.Equals(model.UserName)).Where(p => p.MembPwd.Equals(model.Password)).FirstOrDefaultAsync();

            if (logar == null)
            {
                ModelState.AddModelError("", "Login ou senha inválidos.");
                return View();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, model.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Name, model.UserName));
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction(nameof(PainelController.Index), "Painel");
                }
                
                catch(Exception e)
                {
                    ModelState.AddModelError("","Erro ocorrido : \n" + e.Message);
                }
            }
            return View();

        }

        public IActionResult Register()
        {
            var username = User.Identity.Name;
            if (username != null)
                return RedirectToAction(nameof(Error), new {Message = "Você precisa estar deslogado para executar essa operação."} );

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterMembInfoViewModel model)
        {

            var membInfo = Mapper.Map<MembInfo>(model);

            membInfo.BlocCode = "0";
            membInfo.Ctl1Code = "0";
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Add(membInfo);
                    await _dbContext.SaveChangesAsync();
                    ViewBag.Sucess = "Cadastro realizado com sucesso.";
                    return RedirectToAction(nameof(Index)).WithSuccess("Seja bem-vindo!","Cadastro realizado com sucesso!");
                }

                catch (Exception e)
                {
                    ModelState.AddModelError("", "Erro ocorrido: \n" + e.Message);
                }
            }
            return View(model).WithDanger("Erro ocorrido!","Preencha novamente o formulário de maneira correta!");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}