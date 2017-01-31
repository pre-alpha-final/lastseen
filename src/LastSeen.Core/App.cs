using AutoMapper;
using LastSeen.Core.Infrastructure.MapperProfiles;
using LastSeen.Core.Sevices;
using LastSeen.Core.Sevices.Implementations;
using LastSeen.Core.Sevices.Stubs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace LastSeen.Core
{
	public class App : MvxApplication
	{
		public App()
		{
		}

		public override void Initialize()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.AddProfile<LastSeenProfile>();
			});

			Mvx.LazyConstructAndRegisterSingleton<ILastSeenService, LastSeenService>();
			Mvx.LazyConstructAndRegisterSingleton<IDataStorage, DataStorage>();

			base.Initialize();
		}
	}
}
