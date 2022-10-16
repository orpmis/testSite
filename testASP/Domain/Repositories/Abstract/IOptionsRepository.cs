using testASP.Domain.Entities;

namespace testASP.Domain.Repositories.Abstract
{
    public interface IOptionsRepository
    {
        IQueryable<Option> GetOptions();
        Option GetOptionById(int id);
        void SaveOption(Option entity);
        void DeleteOption(int id);
    }
}
