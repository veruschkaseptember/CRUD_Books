using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Books.Models
{
    public class Book
    {
        [Key] //set id prop as primary key
        public int Book_Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage ="This field is required")] //form validation
        
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This field is required")]
      
        public string Author { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public decimal Price { get; set; }

        [DisplayName("Quantity Available")]
        [Required(ErrorMessage = "This field is required")]
        public int QuantityAvailable { get; set; }

       
        

    }

}
