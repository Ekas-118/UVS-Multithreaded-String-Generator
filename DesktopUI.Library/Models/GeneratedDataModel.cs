using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopUI.Library.Models
{
    [Table("Data")]
    public class GeneratedDataModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ThreadId { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Time { get; set; }

        [Required]
        public string Data { get; set; }
    }
}
