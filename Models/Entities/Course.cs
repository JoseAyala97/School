using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models.Entities
{
    [Table("Course")]
    public class Course
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name"), MaxLength(100)]
        public string Name { get; set; }
        [Column("Description"),  MaxLength(200)]
        public string Description { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }
}
