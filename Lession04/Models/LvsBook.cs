using System.ComponentModel.DataAnnotations;

namespace Lession04.Models
{
    public class LvsBook
    {
        [Key]
        [Display(Name = "Lvs_Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Lvs_TenSach")]
        public string Title { get; set; }

        [Display(Name = "Lvs_TacGia")]
        public string Author { get; set; }

        [Display(Name = "Lvs_TheLoai")]
        public string Category { get; set; }

        [Display(Name = "Lvs_GiaSach")]
        public decimal Price { get; set; }

        [Display(Name = "Lvs_TongSoTrang")]
        public int TotalPages { get; set; }

        [Display(Name = "Lvs_HinhAnh")]
        public string ImagePath { get; set; }

        [Display(Name = "Lvs_GioiThieuNgan")]
        public string Description { get; set; }
    }
}

