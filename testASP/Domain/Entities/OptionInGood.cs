using System.ComponentModel.DataAnnotations;

namespace testASP.Domain.Entities
{
    public class OptionInGood
    {
        [Key]
        public int Id { get; set; }
        public int OptionId { get; set; }

        [Display(Name = "Опция")]
        public Option? Option { get; set; }
        public int GoodsId { get; set; }

        [Display(Name = "Товар")]
        public GoodsItem? Goods { get; set; }
    }
}
