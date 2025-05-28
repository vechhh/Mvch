using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvch.Models;

public class Books
{
    [Display(Name = "ID")]
    public int Id { get; set; }
    [Display(Name = "Названия")]
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; }

    [Display(Name = "Дата")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Display(Name = "Цена")]
    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }


    [Display(Name = "ачвирв")]
    [RegularExpression(@"^[А-Я]+[а-яА-Я\s]*$")]
    [Required]
    [StringLength(30)]
    public string? Genre { get; set; }

    [Display(Name = "ачвирв")]
    [RegularExpression(@"^[А-Я]+[а-яА-Я\s]*$")]
    [StringLength(5)]
    [Required]
    public string? Rating { get; set; }
}