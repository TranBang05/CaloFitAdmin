using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class Diet
    {
        public Diet()
        {
            Menus = new HashSet<Menu>();
            UserPreferences = new HashSet<UserPreference>();
        }

        public int Id { get; set; }
        public string DietName { get; set; } = null!;

        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<UserPreference> UserPreferences { get; set; }
    }
}
