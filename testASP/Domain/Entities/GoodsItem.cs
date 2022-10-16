using System.ComponentModel.DataAnnotations;

namespace testASP.Domain.Entities
{
    public class GoodsItem : BaseEntity
    {
        [Required(ErrorMessage ="Укажите название товара")]
        [Display(Name = "Название товара")]
        public override string Name { get; set; }
        [Display(Name = "Краткое описание товара")]
        public override string? ShortDescription { get; set; }
        [Display(Name = "Полное описание товара")]
        public override string? Description { get; set; }
        [Display(Name = "Категория товара")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<GoodsImages> GoodsImages { get; set; } = new();
        public List<OptionInGood> OptionInGoods { get; set; } = new();
    }
}
