using FictionLogicLayer.Entities;
using FictionLogicLayer.ServiceInterfaces;
using FictionUILayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FictionUILayer.Controllers
{
    public class ChapterController : Controller
    {
        private readonly IChapterService _chapterService;
        private readonly ILikeService _likeService;

        public ChapterController(IChapterService chapterService, ILikeService likeService)
        {
            _chapterService = chapterService;
            _likeService = likeService;
        }

        [HttpGet]
        [ActionName("details")]
        public IActionResult Details(int chapterId)
        {
            var chapter = _chapterService.Get(chapterId);
            return View(chapter);
        }

        [HttpGet]
        [ActionName("addchapter")]
        public IActionResult AddChapter(int fanficId)
        {
            ChapterCrationViewModel chapter = new ChapterCrationViewModel()
            {
                FanficId = fanficId
            };
            return View(chapter);
        }

        [HttpPost]
        public IActionResult AddChapter(string name, string text, int fanficId)
        {
            _chapterService.Create(name, text, fanficId, null);
            return RedirectToAction("Read", "Fanfic", new { id = fanficId });
        }

        [HttpGet]
        [ActionName("edit")]
        public IActionResult Edit(int chapterId)
        {
            ChapterDTO chapter = _chapterService.Get(chapterId);
            return View(chapter);
        }

        [HttpPost]
        public IActionResult Edit(int id, string newName, string editedText)
        {
            ChapterDTO chapter = _chapterService.Get(id);
            chapter.Name = newName;
            chapter.Text = editedText;
            _chapterService.Update(chapter);
            return RedirectToAction("Details", "Chapter", new { chapterId = id });
        }

        [HttpGet]
        public IActionResult Delete(int chapterId)
        {
            var chapter = _chapterService.Get(chapterId);
            int fanficId = chapter.Fanfic.Id;
            _chapterService.Delete(chapter);
            return RedirectToAction("Read", "Fanfic", new { id = fanficId });
        }

        [HttpGet]
        public ActionResult AddLike(int chapterId)
        {
            var authorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _likeService.Like(chapterId, authorId);
            return RedirectToAction("Details", "Chapter", new { chapterId = chapterId });

        }
    }
}
