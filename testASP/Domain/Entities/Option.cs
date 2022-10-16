using System.ComponentModel.DataAnnotations;

namespace testASP.Domain.Entities
{
    public class Option
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        public List<OptionInCat> OptionInCats { get; set; } = new();
        public List<OptionInGood> OptionInGoods { get; set; } = new();

    }
}
