using System;


namespace FireHire.Shared.Resumes
{
    public class Resume
    {
		public Resume()
		{
		}

		public Resume(int id, string body, string state, string title)
		{
			Id = id;
			Body = body;
			State = state;
			Title = title;
		}

		public int Id { get; set; }
		public string State { get; set; }
		public string Body { get; set; }
		public string Title { get; set; }
	}
}
