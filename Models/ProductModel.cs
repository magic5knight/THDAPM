using System.ComponentModel.DataAnnotations;

namespace THDAPM.Models
{
    public class ProductModel
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "Not null")]
        public string Name {get;set;}

        [Required]
        [Range(0, 100)]
        public int Quantity {get;set;}

        [Required]
        [Range(0, 99999.99)]
        public int Price {get;set;}
    }
}