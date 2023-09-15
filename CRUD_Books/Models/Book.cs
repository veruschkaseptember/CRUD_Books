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
        [Required(ErrorMessage = "This field is required")] //form validation

        public string Author { get; set; }

        [Required(ErrorMessage = "This field is required")] //form validation
        public decimal Price { get; set; }

        [DisplayName("Quantity Available")]
        [Required(ErrorMessage = "This field is required")] //form validation
        public int QuantityAvailable { get; set; }

       
        

    }

}

//  defines the structure and validation rules for the Book entity
// Book class is defined within the CRUD_Books.Models namespace
// class has several properties that represent the attributes of a book entity,
// such as Book_Id, Title, Author, Price, and QuantityAvailable.
//  [Key] attribute is applied to the Book_Id property, indicating
//  that it is the primary key for the Book entity
// [Required] attribute is applied to the Title, Author, Price, and QuantityAvailable
// properties, indicating that these fields are required and must have a value. If a value is
// not provided, an error message specified in the ErrorMessage property will be displayed
// [DisplayName] attribute is used to specify a custom display name for the QuantityAvailable
// property. This allows for a more user-friendly label to be displayed in forms or views