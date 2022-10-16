using System.ComponentModel.DataAnnotations;

namespace testASP.Domain.Entities
{
    public class OptionInCat
    {
        [Key]
        public int Id { get; set; }

        public int OptionId { get; set; }
        [Display(Name = "Опция")]
        public Option? Option { get; set; }

        public int CategoryId { get; set; }
        [Display(Name = "Категория")]
        public Category? Category { get; set; }
    }
}
