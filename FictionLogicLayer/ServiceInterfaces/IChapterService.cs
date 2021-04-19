using FictionLogicLayer.Entities;

namespace FictionLogicLayer.ServiceInterfaces
{
    public interface IChapterService
    {
        public ChapterDTO Get(int id);
        public void Create(ChapterDTO chapter);
        void Create(string name, string text, int fanficId, byte[] image);
        public void Update(ChapterDTO chapter);
        public void Delete(ChapterDTO chapter);
        public void ChangeChapterNumber(ChapterDTO chapter, int newNumber);
    }
}
