namespace Mvch.Models;
    using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class author
    {
         [Display(Name = "ID")]
         public int Id { get; set; }

          [Display(Name = "Имя и фамилия")]
         [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Display(Name = "дата рождения")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }


    [Display(Name = "Жанр")]
    [RegularExpression(@"^[А-Я]+[а-яА-Я\s]*$")] 
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; }

    [Display(Name = "Рейтинг")]
    [RegularExpression(@"^[А-Я]+[а-яА-Я\s]*$")]
         [StringLength(5)]
        [Required]
        public string? Rating { get; set; }
    }

