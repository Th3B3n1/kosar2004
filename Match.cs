namespace kosar2004
{
	internal class Match
	{
		public Match(string home, string guest, int homePoints, int guestPoints, string location, DateTime date)
		{
			this.Home = home;
			this.Guest = guest;
			this.HomePoints = homePoints;
			this.GuestPoints = guestPoints;
			this.Location = location;
			this.Date = date;
		}
		public string Home { get; }
		public string Guest { get; }
		public int HomePoints { get; }
		public int GuestPoints { get; }
		public string Location { get; }
		public DateTime Date { get; }
	}
}
