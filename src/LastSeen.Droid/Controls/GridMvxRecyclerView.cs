using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Util;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace LastSeen.Droid.Controls
{
	public class GridMvxRecyclerView : MvxRecyclerView
	{
		public GridMvxRecyclerView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
		}

		protected override void OnFinishInflate()
		{
			base.OnFinishInflate();
			var layoutManager = new GridLayoutManager(Application.Context, 3, LinearLayoutManager.Vertical, false);
			SetLayoutManager(layoutManager);
		}
	}
}