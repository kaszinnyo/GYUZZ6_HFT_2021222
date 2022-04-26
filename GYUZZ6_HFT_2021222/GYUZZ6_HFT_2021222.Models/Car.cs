using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual Brand Brand { get; set; }

        [NotMapped]
        public virtual ICollection<Rent> Rents { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Car car &&
                   Id == car.Id &&
                   Model == car.Model &&
                   BasePrice == car.BasePrice &&
                   BrandId == car.BrandId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Model, BasePrice, BrandId, Brand, Rents);
        }
    }
}
