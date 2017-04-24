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
		public string Description { get; set; }
		public int Season { get; set; }
		public int Episode { get; set; }
		public int MinutesWatched { get; set; }

		// Default constructor for use with deserialization
		public LastSeenItem()
		{
		}

		public LastSeenItem(bool initEmpty)
		{
			if (initEmpty)
				InitEmpty();
		}

		public void InitEmpty()
		{
			Id = Guid.NewGuid().ToString();
			Image = "ImageUrl";
			Name = "Name";
			Tag = "Tag";
			Description = "Description";
			Season = 1;
			Episode = 1;
			MinutesWatched = 0;
		}
	}
}
