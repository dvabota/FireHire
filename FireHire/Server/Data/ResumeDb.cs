

namespace FireHire.Server.Data
{
    public class ResumeDb
    {
		public ResumeDb(int id, string body, string title, string state)
		{
			Id = id;
			Body = body;
			Title = title;
			State = state;
		}

		public int Id { get; set; }
        public string State { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
    }
}
