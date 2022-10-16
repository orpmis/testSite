using testASP.Domain.Entities;

namespace testASP.Domain.Repositories.Abstract
{
    public interface IGoodsItemsRepository
    {
        IQueryable<GoodsItem> GetGoodsItems();
        GoodsItem GetGoodsItemById(int id);
        int SaveGoodsItem(GoodsItem entity);
        void DeleteGoodsItem(int id);
        void SaveGoodsImage(GoodsImages img);
        void DeleteGoodsImage(int imgId);
        void SaveOptionForGoodsItem(OptionInGood opInGood);
        void DeleteOptionForGoodsItem(int idOpInGoodId);
    }
}
