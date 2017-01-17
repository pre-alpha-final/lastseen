using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace LastSeen.Droid.TemplateSelectors
{
	class ItemThumbnailTemplateSelector : IMvxTemplateSelector
	{
		public int GetItemViewType(object forItemObject)
		{
			return Resource.Layout.item_thumbnail;
		}

		public int GetItemLayoutId(int fromViewType)
		{
			return fromViewType;
		}
	}
}