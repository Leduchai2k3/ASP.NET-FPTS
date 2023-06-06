using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.DatLenhs
{

    public class DatLenh
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Phải nhập  {0}")]
        [Display(Name = "Ma CK")]
        public string MaCK { get; set; }

        [Required(ErrorMessage = "Phải nhập  {0}")]
        [Display(Name = "KhoiLuong")]
        public string KhoiLuong { get; set; }

        [Required(ErrorMessage = "Phải nhập  {0}")]
        [Display(Name = "Gia")]
        public string Gia { get; set; }
    }

}