using testASP.Domain.Entities;
using testASP.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace testASP.Domain.Repositories.EntityFramework
{
    public class EFOptionsRepository : IOptionsRepository
    {
        private readonly AppDbContext context;
        public EFOptionsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void DeleteOption(int id)
        {
            context.Options.Remove(new Option() { Id = id });
            context.SaveChanges();
        }

        public Option GetOptionById(int id)
        {
            return context.Options.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Option> GetOptions()
        {
            return context.Options;
        }

        public void SaveOption(Option entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
