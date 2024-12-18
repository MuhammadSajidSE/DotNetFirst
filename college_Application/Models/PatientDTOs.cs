using college_Application.Validator;
using System.ComponentModel.DataAnnotations;
namespace college_Application.Models
{
    public class PatientDTOs
    {
        [Required(ErrorMessage ="Id is must requried")]
        public int id { get; set; }
        [Required(ErrorMessage = "name is must requried")]
        [StringLength(10)]
        public string name { get; set; }
        //[Required]
        //[Range(1, 40)]
        public int age { get; set; }
        public string address { get; set; }
        [RegularExpression("^[FfMm]$", ErrorMessage = "Sex must be F, M, f, or m only.")]
        public char sex { get; set; }
        [EmailAddress]
        public string emai { get; set; }
        public string password { get; set; }
        [Compare("password")]
        public string confimrpassword { get; set; }
        [DateChecker]
        public DateTime admissiondate { get; set; }
    }
}
