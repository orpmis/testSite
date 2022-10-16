using testASP.Domain.Repositories.Abstract;

namespace testASP.Domain.Repositories
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public ICategoriesRepository Categories { get; set; }
        public IOptionsRepository Options { get; set; }
        public IGoodsItemsRepository GoodsItems { get; set; }

        public DataManager(ITextFieldsRepository tfr, ICategoriesRepository cr, IOptionsRepository or, IGoodsItemsRepository gir)
        {
            TextFields = tfr;
            Categories = cr;
            Options = or;
            GoodsItems = gir;
        }
    }
}
