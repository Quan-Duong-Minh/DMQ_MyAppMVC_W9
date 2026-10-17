using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMQ_MyAppMVC.Models
{
    [Table("DMQ_Product")]
    public class DMQ_Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100, ErrorMessage = "Tên tối đa 100 ký tự")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0")]
        [Display(Name = "Giá")]
        public float Price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        public float SalePrice { get; set; } = 0;

        [Range(0, 255)]
        [Display(Name = "Trạng thái")]
        public byte Status { get; set; } = 1;

        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(100)]
        [Display(Name = "Hình ảnh")]
        public string? Image { get; set; }

        [StringLength(350)]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        // Foreign key relation
        [ForeignKey("CategoryId")]
        public virtual DMQ_Category? DMQ_Category { get; set; }
    }
}