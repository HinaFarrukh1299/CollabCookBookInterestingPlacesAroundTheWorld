using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollabCookBookInterestingPlacesAroundTheWorld.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public string Instructions { get; set; }
        public string CookTime { get; set; }
        public int ServingSize { get; set; }

        //a recipe can belong to many origins
        //many origins can have the same recipe
        public ICollection<Origin> Origins { get; set; }


    }
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public string Instructions { get; set; }
        public string CookTime { get; set; }
        public int ServingSize { get; set; }
       

    }

}