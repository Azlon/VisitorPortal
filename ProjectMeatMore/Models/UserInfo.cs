using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMeatMore.Models
{
    public class UserInfo
    {

        public int UserInfoId { get; set; }
        //Type of visitor (leverancier, Sollicant, bezoeker)
        [Required]
        public string Type { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public DateTime OnCreated { get; set; }
        public DateTime OnEdited { get; set; }

        [RegularExpression(@"\w+-\w+-\w+")]
        public string LicensePlate { get; set; }

        public  List<SelectListItem> Types =  new List<SelectListItem>
        {
            new SelectListItem { Value = "Leverancier", Text = "Leverancier" },
            new SelectListItem { Value = "Consultant", Text = "Consultant" },
            new SelectListItem { Value = "Interne Medewerker", Text = "Interne Medewerker"  },
        };
    }
}
