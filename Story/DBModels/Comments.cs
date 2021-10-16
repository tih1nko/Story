using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Story.DBModels
{
    public partial class Comments
    {
        public int Id { get; set; }
        public string IdentityUser { get; set; }
        public string CommnetText { get; set; }

        public virtual AspNetUsers IdentityUserNavigation { get; set; }
    }
}
