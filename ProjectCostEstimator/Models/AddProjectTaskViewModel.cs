using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectCostEstimator.Models
{
    public class AddProjectTaskViewModel
    {
        [Required]
        public int ProjectID { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "{0} musi być większy niż {1}.")]
        [DataType(DataType.Text)]
        [Display(Name = "Szacowany czas trwania zadania w godzinach")]
        public int WorkingTime { get; set; }
        [Required]
        [Display(Name = "Definicja zadania")]
        public int ProjectTaskDefinitionID { get; set; }
        public ICollection<ProjectTaskDefinition> Definitions { get; set; }
    }
}