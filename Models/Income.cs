namespace personalfinancetracker.Models;
using System.ComponentModel.DataAnnotations;

public class Income
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Source { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public double Amount { get; set; }
    [Required]
    public DateTime Date { get; set; }
}


