using System;

namespace LastSeen.Core.Infrastructure.Deserialization
{
	public class LastSeenItem
	{
		public string Id { get; set; }
		
		// Miniature
		public string Image { get; set; }
		public string Name { get; set; }
		public string Tag { get; set; }

		//Details
		public string Title { get; set; }
		public string Description { get; set; }
		public int Season { get; set; }
		public int Episode { get; set; }

		public void InitEmpty()
		{
			Id = new Guid().ToString();
			Image = "";
			Name = "<unknown>";
			Title = "<unknown>";
			Description = "<no description>";
			Season = 0;
			Episode = 0;
		}
	}
}
