using FictionDataLayer.Implementations;
using FictionDataLayer.Interfaces;
using FictionLogicLayer.Entities;
using FictionLogicLayer.Mappers;
using FictionLogicLayer.Models;
using FictionLogicLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FictionLogicLayer.Services
{
    public class ChapterService : IChapterService
    {
        private RepositoryAbstractFabric _fabric;

        public ChapterService(RepositoryAbstractFabric fabric)
        {
            _fabric = fabric;
        }

        public void Create(ChapterDTO chapter)
        {
            _fabric.CreateChaptersRepository().Create(chapter.ToEntity());
        }

        public void Create(string name, string text, int fanficId, byte[] image)
        {
            FanficDTO fanfic = _fabric.CreateFanficsRepository().Get(fanficId).ToModel();
            int chapterNumber = fanfic.Chapters.Count + 1;
            _fabric.CreateChaptersRepository().Create(name, text, chapterNumber, fanficId, image);
            fanfic.LastUpdateTimestamp = DateTime.Now;
            _fabric.CreateFanficsRepository().Update(fanfic.ToEntity());
        }

        public void Delete(ChapterDTO chapter)
        {
            int fanficId = chapter.Fanfic.Id;
            _fabric.CreateChaptersRepository().Delete(chapter.ToEntity());
        }

        public void Update(ChapterDTO chapter)
        {
            _fabric.CreateChaptersRepository().Update(chapter.ToEntity());
        }

        public void ChangeChapterNumber(ChapterDTO chapter, int newNumber)
        {
            FanficDTO fanfic = chapter.Fanfic;
            List<ChapterDTO> chapters = fanfic.Chapters;

            ChapterDTO chapterToSwapWith = chapters.FirstOrDefault(c => c.ChapterNumber == newNumber);
            chapterToSwapWith.ChapterNumber = chapter.ChapterNumber;
            chapter.ChapterNumber = newNumber;

            Update(chapter);
            Update(chapterToSwapWith);
        }

        public ChapterDTO Get(int id)
        {
            return _fabric.CreateChaptersRepository().Get(id).ToModel();
        }

       
    }
}
