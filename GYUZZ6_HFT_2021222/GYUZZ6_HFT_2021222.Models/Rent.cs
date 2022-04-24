using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GYUZZ6_HFT_2021222.Models
{
    [Table("rents")]
    public class Rent
    {
        public Rent()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("carId")]
        public int CarId { get; set; }

        [StringLength(20)]
        [Column("renterName")]
        [Required]
        public string RenterName { get; set; }

        [Column("Date")]
        public DateTime? Date { get; set; }

        [Column("rentTime")]
        public double? RentTime { get; set; }

        [Column("rating")]
        public double? Rating { get; set; }

        [NotMapped]
        public virtual Car Car { get; set; }
    }
}
