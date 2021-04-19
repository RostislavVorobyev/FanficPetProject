using FictionLogicLayer;
using FictionLogicLayer.Models;
using FictionLogicLayer.ServiceInterfaces;
using FictionUILayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FictionUILayer.Controllers
{
    public class FanficController : Controller
    {
        private readonly IFanficService _fanficService;
        private readonly ITagService _tagService;
        private readonly IGenreService _genreService;
        private readonly IRatingService _ratingService;
        private readonly ICommentaryService _commentaryService;

        public FanficController(IFanficService fanficService, ITagService tagService, IGenreService genreService, IRatingService ratingService, ICommentaryService commentaryService)
        {
            _fanficService = fanficService;
            _tagService = tagService;
            _genreService = genreService;
            _ratingService = ratingService;
            _commentaryService = commentaryService;
        }

        public IActionResult Read(int id)
        {
            var fanfic = _fanficService.Get(id);
            return View(fanfic);
        }

        [HttpGet]
        public IActionResult Edit(int fanficId)
        {
            FanficDTO fanfic = _fanficService.Get(fanficId);
            return View(fanfic);
        }

        [HttpPost]
        public IActionResult Edit(int fanficId, string newName, string newDescription)
        {
            FanficDTO fanfic = _fanficService.Get(fanficId);
            fanfic.Name = newName;
            fanfic.Description = newDescription;
            _fanficService.Update(fanfic);
            return RedirectToAction("Read", "Fanfic", new { id = fanficId });
        }

        [HttpGet]
        public IActionResult Delete(int fanficId)
        {
            var fanfic = _fanficService.Get(fanficId);
            _fanficService.Delete(fanfic);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Create()
        {
            FanficCreationViewModel creationModel = new FanficCreationViewModel
            {
                Genres = _genreService.GetAll(),
                Tags = _tagService.GetAll(),
            };
            return View(creationModel);
        }

        [HttpPost]
        public ActionResult Create(string name, string desctiption, int genreId)
        {
            var authorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _fanficService.Create(name, desctiption, authorId, genreId);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AddComment(string text, int fanficId)
        {
            var authorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _commentaryService.Create(text, authorId, fanficId);
            return RedirectToAction("Read", "Fanfic", new { id = fanficId });
        }

        [HttpPost]
        public ActionResult Rate(int fanficId, int ratingValue)
        {
            var authorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _ratingService.Rate(fanficId, authorId, ratingValue);
            return RedirectToAction("Read", "Fanfic", new {id = fanficId });
        }
    }
}
