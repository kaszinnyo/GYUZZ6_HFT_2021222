using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GYUZZ6_HFT_2021222.Models
{
    [Table("cars")]
    public class Car
    {
        public Car()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [StringLength(20)]
        [Column("model")]
        [Required]
        public string Model { get; set; }

        [Column("price")]
        public int? BasePrice { get; set; }

        [ForeignKey(nameof(Brand))]
        [Column("brand_id")]
        public int BrandId { get; set; }

        [NotMapped]
        public virtual Brand Brand { get; set; }

        [NotMapped]
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
