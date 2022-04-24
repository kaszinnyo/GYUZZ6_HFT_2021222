using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GYUZZ6_HFT_2021222.Models
{
    [Table("brands")]
    public class Brand
    {
        public Brand()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [StringLength(20)]
        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
