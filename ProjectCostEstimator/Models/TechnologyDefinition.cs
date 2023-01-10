using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ProjectCostEstimator.Models
{
    public class TechnologyDefinition
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "{0} może mieć maksymalnie: {1} znaków.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "{0} może mieć maksymalnie: {1} znaków.")]
        [DataType(DataType.Text)]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Cena za godzinę")]
        public decimal BasePrice { get; set; }
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "{0} musi być większy niż {1}.")]
        [DataType(DataType.Text)]
        [Display(Name = "Mnożnik ceny projektu")]
        public double ProjectPriceMultiplier { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Rodzaj technologii")]
        public TechnologyKind TechnologyKind { get; set; }
    }

    public enum TechnologyKind
    {
        [Display(Name = "Język programowania")]
        PROGRAMMING_LANGUAGE,
        [Display(Name = "System baz danych")]
        DATABASE_SYSTEM, 
        [Display(Name  = "Framework")]
        FRAMEWORK, 
        [Display(Name = "Biblioteka")]
        LIBRARY, 
        [Display(Name = "Inny")]
        OTHER
    }
}