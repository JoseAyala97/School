using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models.Entities
{
    [Table("CourseToStudent")]
    public class CourseToStudent
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("StudentId")]
        public int StudentId { get; set;}
        [Column("TeacherId")]
        public int TeacherId { get; set;}
        [Column("CourseId")]
        public int CourseId { get; set;}
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Course Course { get; set; }
    }
}
