using System;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace LastSeen.Droid.Controls
{
	public class GridMvxRecyclerView : MvxRecyclerView, View.IOnClickListener
	{
		public MvxCommand<string> GridTapCommand { get; set; }

		public GridMvxRecyclerView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
		}

		protected override void OnFinishInflate()
		{
			base.OnFinishInflate();
			var layoutManager = new GridLayoutManager(Application.Context, 3, LinearLayoutManager.Vertical, false);
			SetLayoutManager(layoutManager);
		}

		public override void OnViewAdded(View child)
		{
			child.SetOnClickListener(this);
			var seasonEpisodeTextView = child.FindViewById<TextView>(Resource.Id.item_season_episode);
			seasonEpisodeTextView.SetTextColor(Android.Graphics.Color.Gray);

			base.OnViewAdded(child);
		}

		public override void OnViewRemoved(View child)
		{
			child.SetOnClickListener(null);
			base.OnViewRemoved(child);
		}

		public void OnClick(View v)
		{
			var textView = v.FindViewById<TextView>(Resource.Id.item_id);
			GridTapCommand.Execute(textView?.Text);
		}
	}
}