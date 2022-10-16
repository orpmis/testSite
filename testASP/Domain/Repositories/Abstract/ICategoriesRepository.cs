using testASP.Domain.Entities;

namespace testASP.Domain.Repositories.Abstract
{
    public interface ICategoriesRepository
    {
        IQueryable<Category> GetCategories();
        Category GetCategoryById(int id);
        void SaveCategoty(Category entity);
        void DeleteCategoty(int id);
        void SaveOptionInCategory(OptionInCat opInCat);
        void DeleteOptionFromCategory(int opInCatId);
    }
}
