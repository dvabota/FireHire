namespace FireHire.Server.Data
{
    public class ScoringDataDb
    {
        public ScoringDataDb(int id, int vacancyId, int resumeId, double score)
        {
            Id = id;
            VacancyId = vacancyId;
            ResumeId = resumeId;
            Score = score;
        }

        public int Id { get; set; }
        public int VacancyId { get; set; }
        public int ResumeId { get; set; }
        public Double Score { get; set; }

    }
}
