using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApi.Domain;

[Table("weathers")]
public class Weather
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("temperature")]
    public int Temperature { get; set; }

    [Required]
    [Column("location")]
    public string Location { get; set; }
}