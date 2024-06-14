using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class Step
    {
        public int StepId { get; set; }
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; } = null!;
        public int? ImageId { get; set; }

        public virtual Image? Image { get; set; }
        public virtual Recipe Recipe { get; set; } = null!;
    }
}
