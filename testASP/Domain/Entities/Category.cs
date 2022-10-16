using System.ComponentModel.DataAnnotations;

namespace testASP.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Укажите название категории")]
        [Display(Name = "Название категории")]
        public override string Name { get; set; }
        [Display(Name = "Краткое описание категории")]
        public override string? ShortDescription { get; set; }
        [Display(Name = "Полное описание категории")]
        public override string? Description { get; set; }

        public List<GoodsItem> GoodsItems { get; set; } = new();
    }
}
