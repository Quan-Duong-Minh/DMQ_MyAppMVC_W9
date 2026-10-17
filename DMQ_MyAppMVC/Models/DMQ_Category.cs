using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMQ_MyAppMVC.Models
{
    [Table("DMQ_Category")]
    public class DMQ_Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100, ErrorMessage = "Tên tối đa 100 ký tự")]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; } = string.Empty;

        [Range(0, 255)]
        [Display(Name = "Trạng thái")]
        public byte Status { get; set; } = 1;

        [DataType(DataType.Date)]
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(100)]
        [Display(Name = "Hình ảnh")]
        public string? Image { get; set; }

        [StringLength(350)]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        // Navigation property
        public virtual ICollection<DMQ_Product>? DMQ_Products { get; set; }
    }
}