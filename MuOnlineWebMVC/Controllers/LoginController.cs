using System;
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
using MuOnlineWebMVC.Extensions.Alerts;
using MuOnlineWebMVC.Models.ViewModels;
using System.Diagnostics;

namespace MuOnlineWebMVC.Controllers
{
    public class LoginController : Controller
    {
        ApplicationDbContext _dbContext { get; set; }
        public static string erro = "false";
        public static int countErro = 0;
        public LoginController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult _signUp()
        {
            if(countErro == 2) { countErro = 0; erro = "false"; }
            ViewData["Erro"] = erro;
            countErro++;
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _signUp(LoginViewModel model)
        {
            erro = "false";
            var logar = await _dbContext.MembInfo.Where(p => p.MembId.Equals(model.UserName)).Where(p => p.MembPwd.Equals(model.Password)).FirstOrDefaultAsync();

            if (logar == null)
            {
                countErro = 1;
                erro = "Login ou senha inválidos.";
                return RedirectToAction("Index", "Home");
            }           
            
            if (ModelState.IsValid)
            {
                try
                {
                    erro = "false";
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, model.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Name, model.UserName));
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index","Painel");
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
                    return RedirectToAction(nameof(HomeController.Index)).WithSuccess("Seja bem-vindo!","Cadastro realizado com sucesso!");
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