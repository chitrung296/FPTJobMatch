namespace FPTJobMatch.MVC.Data.Entities
{
    public class CV
    {
        public CV()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public Guid JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
    }
}
