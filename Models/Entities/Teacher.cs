using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace School.Models.Entities
{
    [Table("Teacher")]
    public class Teacher
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name"), MaxLength(20)]
        public string? Name { get; set; }
        [Column("LastName"), MaxLength(30)]
        public string? LastName { get; set; }
        [Column("Age")]
        public int? Age { get; set; }
        [JsonIgnore]
        public virtual ICollection<Course> Courses { get; set; }

    }
}
