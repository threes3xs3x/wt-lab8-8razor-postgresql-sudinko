using System.ComponentModel.DataAnnotations;

namespace wt_lab8_8razor_postgresql_sudinko.Models;

public class Flight
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите номер рейса")]
    public string Number { get; set; } = "";

    [Required(ErrorMessage = "Укажите город вылета")]
    public string From { get; set; } = "";

    [Required(ErrorMessage = "Укажите город прилёта")]
    public string To { get; set; } = "";

    [Required(ErrorMessage = "Введите цену")]
    [Range(1, 100000, ErrorMessage = "Цена должна быть от 1 до 100000")]
    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }
    public string Description { get; set; } = "";
}