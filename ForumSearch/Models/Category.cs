using System.Collections.Generic;

namespace ForumSearch.Models
{
    public class Category
    {
        public string CategoryName { get; set; }
        public ICollection<Forum> ForumList { get; set; }
    }
}
