using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace LastSeen.Droid.TemplateSelectors
{
	class SectionTemplateSelector : IMvxTemplateSelector
	{
		public int GetItemViewType(object forItemObject)
		{
			return Resource.Layout.section;
		}

		public int GetItemLayoutId(int fromViewType)
		{
			return fromViewType;
		}
	}
}