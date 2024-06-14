using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; } = null!;
        public DateTime CommentDate { get; set; }

        public virtual Recipe Recipe { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
