using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactList.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [MaxLength(12)]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Mobile Phone")]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Birth Date")]
        public string BirthDate { get; set; }
    }
}
