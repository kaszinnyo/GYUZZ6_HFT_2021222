using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual Car Car { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Rent rent &&
                   Id == rent.Id &&
                   CarId == rent.CarId &&
                   RenterName == rent.RenterName &&
                   Date == rent.Date &&
                   RentTime == rent.RentTime &&
                   Rating == rent.Rating &&
                   EqualityComparer<Car>.Default.Equals(Car, rent.Car);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CarId, RenterName, Date, RentTime, Rating, Car);
        }
    }
}
