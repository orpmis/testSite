using System.ComponentModel.DataAnnotations;

namespace testASP.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public virtual string Name { get; set; }
        [Display(Name = "Описание")]
        public virtual string? Description { get; set; }
        [Display(Name = "Краткое описание")]
        public virtual string? ShortDescription { get; set; }
        [Display(Name = "SEO метатэг Title")]
        public string? MetaTitle { get; set; }
        [Display(Name = "SEO метатэг Description")]
        public string? MetaDescription { get; set; }
        [Display(Name = "SEO метатэг Keywords")]
        public string? MetaKeywords { get; set; }

    }
}
