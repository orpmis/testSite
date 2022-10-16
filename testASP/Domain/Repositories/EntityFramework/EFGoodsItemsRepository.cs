using testASP.Domain.Entities;
using testASP.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace testASP.Domain.Repositories.EntityFramework
{
    public class EFGoodsItemsRepository : IGoodsItemsRepository
    {
        private readonly AppDbContext context;
        public EFGoodsItemsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void DeleteGoodsImage(int imgId)
        {
            context.GoodsImages.Remove(new GoodsImages() { Id = imgId});
            context.SaveChanges();
        }

        public void DeleteGoodsItem(int id)
        {
            context.GoodItems.Remove(new GoodsItem() { Id = id });
            context.SaveChanges();
        }

        public void DeleteOptionForGoodsItem(int opInGoodId)
        {
            context.OptionsInGoods.Remove(new OptionInGood() {Id = opInGoodId });
            context.SaveChanges();
        }

        public GoodsItem GetGoodsItemById(int id)
        {
            return context.GoodItems.Include(x => x.GoodsImages).FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<GoodsItem> GetGoodsItems()
        {
            return context.GoodItems;
        }

        public void SaveGoodsImage(GoodsImages img)
        {
            if (img.Id == default)
                context.Entry(img).State = EntityState.Added;
            else context.Entry(img).State = EntityState.Modified;

            context.SaveChanges();
        }

        public int SaveGoodsItem(GoodsItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();

            return entity.Id;
        }

        public void SaveOptionForGoodsItem(OptionInGood opInGood)
        {
            if (opInGood.Id == default)
                context.Entry(opInGood).State = EntityState.Added;
            else context.Entry(opInGood).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
