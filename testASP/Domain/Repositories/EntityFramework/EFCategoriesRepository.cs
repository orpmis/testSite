using testASP.Domain.Entities;
using testASP.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace testASP.Domain.Repositories.EntityFramework
{
    public class EFCategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext context;
        public EFCategoriesRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void DeleteCategoty(int id)
        {
            context.Categories.Remove(new Category() { Id = id });
            context.SaveChanges();
        }

        public void DeleteOptionFromCategory(int opInCatId)
        {
            context.OptionsInCats.Remove(new OptionInCat() { Id = opInCatId});
            context.SaveChanges();
        }

        public IQueryable<Category> GetCategories()
        {
            return context.Categories;
        }

        public Category GetCategoryById(int id)
        {
            return context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void SaveCategoty(Category entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void SaveOptionInCategory(OptionInCat opInCat)
        {
            if (opInCat.Id == default)
                context.Entry(opInCat).State = EntityState.Added;
            else context.Entry(opInCat).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
