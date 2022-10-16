using testASP.Domain.Entities;
using testASP.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace testASP.Domain.Repositories.EntityFramework
{
    public class EFTextFieldRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;
        public EFTextFieldRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void DeleteTextField(int id)
        {
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }

        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields;
        }

        public void SaveTextField(TextField entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
