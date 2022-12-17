

namespace FireHire.Server.Data
{
    public class VacancyDb
    {
        public VacancyDb(int id, string title, string description, string requirements, string skills, string benefits, string format)
        {
            Id = id;
            Title = title;
            Description = description;
            Requirements = requirements;
            Skills = skills;
            Benefits = benefits;
            Format = format;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Skills { get; set; }
        public string Benefits { get; set; }
        public string Format { get; set; }
    }
}
