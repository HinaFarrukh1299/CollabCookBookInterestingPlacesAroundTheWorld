using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollabCookBookInterestingPlacesAroundTheWorld.Models
{
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public string PlaceDescription { get; set; }

        public DateTime DateOfCreation { get; set; }

        [ForeignKey("Origin")]
        //  a place belongs to one country.
        // a country can have many places
        public int OriginID { get; set; }

        //We can be more explicit by describing a navigation property
        public virtual Origin Origin { get; set; }
        //a place can have many traditions
        //This way we our implicitly describing a bridging table
        public ICollection<Tradition> Traditions { get; set; }


    }
    public class PlaceDto
    {
        [Key]
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public string PlaceDescription { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string Country { get; set; }


    }
}