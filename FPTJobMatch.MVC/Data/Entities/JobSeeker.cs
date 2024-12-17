using FPTJobMatch.MVC.Commons;
using System.Collections.ObjectModel;

namespace FPTJobMatch.MVC.Data.Entities
{
    public class JobSeeker : Person
    {
        public JobSeeker()
        {
            CVs = new Collection<CV>();
        }
        public ICollection<CV> CVs { get; set; }
    }
}
