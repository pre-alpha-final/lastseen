using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace LastSeen.Droid.Controls
{
	public class SectionMvxRecyclerView : MvxRecyclerView
	{
		public MvxCommand<string> GridTapCommand { get; set; }

		public SectionMvxRecyclerView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
		}

		public override void OnViewAdded(View child)
		{
			UpdateChild(child);
			base.OnViewAdded(child);
		}

		private void UpdateChild(View child)
		{
			var view = child as LinearLayout;
			if (view == null)
				return;

			var recycler = child.FindViewById<GridMvxRecyclerView>(Resource.Id.item_recycler);
			if (recycler != null)
				recycler.GridTapCommand = GridTapCommand;
		}
	}
}