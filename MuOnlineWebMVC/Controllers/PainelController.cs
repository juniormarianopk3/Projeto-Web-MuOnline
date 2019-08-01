using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuOnlineWebMVC.Models;
using MuOnlineWebMVC.Models.ViewModels.PainelViewModels;
using MuOnlineWebMVC.Extensions.Alerts;
using MuOnlineWebMVC.Models.ViewModels;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace MuOnlineWebMVC.Controllers
{
    [Authorize]
    public class PainelController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHostingEnvironment _hosting;


        public PainelController(ApplicationDbContext dbContext, IHostingEnvironment hosting)
        {
            _dbContext = dbContext;
            _hosting = hosting;

        }
        public async Task<IActionResult> Index()
        {

            var userName = User.Identity.Name;
            var membInfo = await _dbContext.MembInfo.FirstOrDefaultAsync(x => x.MembId == userName);


            if (membInfo != null)

                return View(membInfo);

            return View();
        }

        public async Task<IActionResult> ToChangePassword(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var membInfo = await _dbContext.MembInfo.FindAsync(id);

            if (membInfo != null)
                return View(Mapper.Map<ToChangePasswordViewModel>(membInfo));

            else
                return NotFound();


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToChangePassword(ToChangePasswordViewModel model)
        {

            var membInfo = await _dbContext.MembInfo.FirstOrDefaultAsync(p => p.MembGuid == model.Id);
            //  var membInfo = Mapper.Map<MembInfo>(model);
            membInfo.MembPwd = model.Password;

            var pwdExist = await _dbContext.MembInfo.Where(p => p.MembPwd == model.Password).Where(p => p.MembGuid == model.Id).FirstOrDefaultAsync();
            if (pwdExist != null)
            {
                ModelState.AddModelError("", "A senha escolhida é a mesma que a senha atual!");
                return View(model);
            }
            if (ModelState.IsValid)
            {

                _dbContext.Update(membInfo);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(PainelController.Index), "Painel");
            }


            return View(model);

        }

        public async Task<IActionResult> Characters()
        {
            var username = User.Identity.Name;
            return View(await _dbContext.Character.Where(m => m.AccountId == username).ToListAsync());
        }

        public async Task<IActionResult> CharactersProfile(CharactersProfileViewModels models)
        {
            var userName = User.Identity.Name;
            var character = await _dbContext.Character.Where(p => p.AccountId == userName).FirstOrDefaultAsync(p => p.Name == models.Name);

            if (character != null)

                return View(Mapper.Map<CharactersProfileViewModels>(character));

            else
                return NotFound();

        }

        public async Task<IActionResult> ImageUpload(string Name)
        {

            var username = User.Identity.Name;
            var character = await _dbContext.Character.Where(p => p.AccountId == username)
                .FirstOrDefaultAsync(x => x.Name == Name);

            var nChar = Mapper.Map<ImageUploadViewModels>(character);


            if (character != null)

                return View(nChar);
            else
                return NotFound();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImageUpload(ImageUploadViewModels model)
        {

            var character = await _dbContext.Character.FirstOrDefaultAsync(p => p.Name == model.Name);

            if (ModelState.IsValid)
            {
                try
                {
                    var newFileName = string.Empty;

                    if (HttpContext.Request.Form.Files != null)
                    {
                        var fileName = string.Empty;
                        string PathDB = string.Empty;

                        var files = HttpContext.Request.Form.Files;

                        foreach (var file in files)
                        {
                            if (file.Length > 0)
                            {
                                //Getting FileName
                                fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                                //Assigning Unique Filename (Guid)
                                var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                                //Getting file Extension
                                var FileExtension = Path.GetExtension(fileName);

                                // concating  FileName + FileExtension
                                newFileName = myUniqueFileName + FileExtension;

                                // Combines two strings into a path.
                                fileName = Path.Combine(_hosting.WebRootPath, "photos") + $@"\{newFileName}";

                                //if you want to store path of folder in database
                                PathDB = "Characters/" + newFileName;
                                character.Image = newFileName;
                                using (FileStream fs = System.IO.File.Create(fileName))
                                {
                                    file.CopyTo(fs);
                                    fs.Flush();
                                }
                            }
                        }

                    }
                    _dbContext.Update(character);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(PainelController.Characters), "Painel").WithSuccess("Ok", "Imagem trocada com sucesso.");

                }

                catch (Exception e)
                {
                    ModelState.AddModelError("", "Erro ocorrido : \n" + e.Message);
                }

            }
            return View(model);

        }

        public async Task<IActionResult> ToChangeName(string Name)
        {
            var username = User.Identity.Name;
            var character = await _dbContext.Character.Where(p => p.AccountId == username).FirstOrDefaultAsync(p => p.Name == Name);



            if (character == null)
                return NotFound();

            else
                return View(Mapper.Map<ToChangeNameViewModels>(character));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> ToChangeName(ToChangeNameViewModels models)
        {

            var character = await _dbContext.Character.FirstOrDefaultAsync(p => p.AccountId == models.AccountId);
            character.Name = models.Name;

            if (ModelState.IsValid)
            {
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(PainelController.Index), "Painel");
            }

            return View(models);
        }
        public IActionResult ToChangeEmail(int? id)
        {
            var membInfo = _dbContext.MembInfo.FirstOrDefault(prop => prop.MembGuid == id);
            if (membInfo == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToChangeEmail(ToChangeEmailViewModel viewModel)
        {
            var pid = await _dbContext.MembInfo.FirstOrDefaultAsync(p => p.SnoNumb == viewModel.Pid);
            var membInfo = await _dbContext.MembInfo.FirstOrDefaultAsync(p => p.MembGuid == viewModel.Id);
            membInfo.MailAddr = viewModel.Email;

            if (pid == null)
            {
                ModelState.AddModelError("", "Personal id incorreto.");
                return View(viewModel);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(membInfo);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(PainelController.Index), "Painel");
                }

                catch (Exception e)
                {
                    ModelState.AddModelError("", "Erro ocorrido" + e);
                }
            }
            return View(viewModel);
        }
        public async Task<IActionResult> DeletePhoto(string Name)
        {
            var username = User.Identity.Name;
            var character = await _dbContext.Character.Where(p => p.AccountId == username).FirstOrDefaultAsync(p => p.Name == Name);

            if(character == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "O Personagem não pertence a esta conta." });
            }
            if(ModelState.IsValid)
            {
                character.Image = "nophoto.jpg";
                _dbContext.Update(character);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(PainelController.Characters), "Painel").WithSuccess("Ok", "Imagem excluída com sucesso.");
            }
            return View();
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




