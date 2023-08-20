using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollabCookBookInterestingPlacesAroundTheWorld.Models
{
    public class Origin
    {

        [Key]
        public int OriginID { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }

        //many origins can have many recipies
        public ICollection<Recipe> Recipes { get; set; }


    }
}