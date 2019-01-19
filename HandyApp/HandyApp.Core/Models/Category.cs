using System.Collections.Generic;

namespace HandyApp.Core.Models
{
    public class Category
    {
        public string Name { get; set; }
        public string NavigationLink { get; set; }
        public IEnumerable<App> Apps { get; set; }
    }
}