using AutoMapper;
using LastSeen.Core.Infrastructure.Deserialization;
using LastSeen.Core.POs;

namespace LastSeen.Core.Infrastructure.MapperProfiles
{
	public class LastSeenProfile : Profile
	{
		public LastSeenProfile()
		{
			CreateMap<LastSeenItem, ItemPO>();
			CreateMap<ItemPO, LastSeenItem>();
		}
	}
}
