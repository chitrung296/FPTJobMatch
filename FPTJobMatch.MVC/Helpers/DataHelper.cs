using FPTJobMatch.MVC.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FPTJobMatch.MVC.Helpers
{
    public static class DataHelper
    {
        public static SelectList GetOccupationSelectList()
        {
            var occupations = from OccupationEnum job in Enum.GetValues(typeof(OccupationEnum))
                              select new
                              {
                                  Id = job,
                                  Name = job.ToString()
                              };
            return new SelectList(occupations, "Id", "Name", 4);
        }
    }
}
