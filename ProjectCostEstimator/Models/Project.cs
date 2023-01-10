using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace ProjectCostEstimator.Models
{
    public class Project
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

        [DataType(DataType.Currency)]
        [Display(Name = "Koszt całkowity")]
        [NotMapped]
        public decimal TotalCost
        {
            get
            {
                decimal result = 0;
                foreach (var task in Tasks)
                {
                    result += task.CalculatedCost;
                }
                foreach (var tech in Technologies)
                {
                    result += tech.UsedBasePrice;
                }
                var multiplier = 1.0d;
                foreach (var tech in Technologies)
                {
                    multiplier *= tech.UsedPriceMultiplier;
                }
                return result * (decimal) multiplier;
            }
        }
        
        [NotMapped]
        public int TotalTimeEstimated {
            get
            {
                int result = 0;
                foreach (var task in Tasks)
                {
                    result += task.WorkingTime;
                }
                return result;
            } 
        }
        public virtual ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
        public virtual ICollection<Technology> Technologies { get; set; } = new List<Technology>();
    }
}