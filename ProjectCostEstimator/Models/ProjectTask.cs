using System.ComponentModel.DataAnnotations;

namespace ProjectCostEstimator.Models
{
    public class ProjectTask
    {
        public int ID { get; set; }
        [Display(Name = "Definicja zadania")]
        public virtual ProjectTaskDefinition ProjectTaskDefinition { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Cena za godzinę w momencie wykorzystania")]
        public decimal UsedPricePerHour{ get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Obliczony koszt zadania")]
        public decimal CalculatedCost { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Szacowany czas trwania zadania w godzinach")]
        public int WorkingTime { get; set; }
    }
}