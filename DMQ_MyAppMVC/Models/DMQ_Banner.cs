using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMQ_MyAppMVC.Models
{
    [Table("DMQ_Banner")]
    public class DMQ_Banner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên banner không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tên Banner")]
        public string Name { get; set; } = string.Empty;

        [Range(0, 255)]
        [Display(Name = "Trạng thái")]
        public byte Status { get; set; } = 1;

        [Display(Name = "Mức độ ưu tiên")]
        public int Prioty { get; set; } = 0;

        [StringLength(100)]
        [Display(Name = "Hình ảnh")]
        public string? Image { get; set; }

        [StringLength(350)]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }
    }
}