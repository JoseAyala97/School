using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual ICollection<CourseToStudent> Courses { get; set; }
    }
}
