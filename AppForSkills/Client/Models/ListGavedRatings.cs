using System.Collections.Generic;

namespace AppForSkills.Client.Models
{
    public class ListGavedRatings
    {
        public ICollection<UserGavedRatingDto> Ratings { get; set; }
    }
}
