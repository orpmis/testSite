using System.ComponentModel.DataAnnotations;

namespace testASP.Domain.Entities
{
    public class GoodsImages
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Путь")]
        public string ImgPath { get; set; }

        public int GoodsId { get; set; }
        [Display(Name = "Товар")]
        public GoodsItem? Goods { get; set; }
       
    }
}
