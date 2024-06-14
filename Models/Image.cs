using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class Image
    {
        public Image()
        {
            Ingredients = new HashSet<Ingredient>();
            Recipes = new HashSet<Recipe>();
            Steps = new HashSet<Step>();
        }

        public int ImageId { get; set; }
        public string? ImageFilename { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
    }
}
