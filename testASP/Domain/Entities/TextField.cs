using System.ComponentModel.DataAnnotations;

namespace testASP.Domain.Entities
{
    public class TextField : BaseEntity
    {
        [Required]
        public string CodeWord { get; set; }
        [Display(Name = "Название страницы")]
        public override string Name { get; set; } = "Заполняется администратором";
        [Display(Name = "Содержание страницы")]
        public override string Description { get; set; } = "Заполняется администратором";

    }
}
