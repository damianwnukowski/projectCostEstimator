using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectCostEstimator.Models
{
    public class ProjectTaskDefinition
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "{0} może mieć maksymalnie: {1} znaków.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "{0} może mieć maksymalnie: {1} znaków.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Cena za godzinę")]
        public decimal CostPerHour { get; set; }
        
    }
}