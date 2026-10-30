using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day02_MVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "name is required")]
        [RegularExpression(@"^[a-zA-Z1-9\s#]+$", ErrorMessage = "Only letters,numbers,spaces and # are allowed")]
        public string Name { get; set; }

        [Range(18, 30, ErrorMessage = "Age between 18 and 30")]
        [Display(Name = "Student Age")]
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

      
        //foreign key
        [ForeignKey("Department")]
        [Range(0,int.MaxValue , ErrorMessage = "Please enter a department")]
        public int DepartmentId { get; set; }

        //navigation properties
        public Department Department { get; set; }
        public List<StuCrsRes> StuCrsReses { get; set; }
    }
}
