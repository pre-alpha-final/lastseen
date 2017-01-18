using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat.Widget;

namespace LastSeen.Droid.Controls
{
	/*
	 * Fills available width and then sets hight, keeping aspect ratio
	 */
	public class FillWidthMvxImageView : MvxAppCompatImageView
	{
		private bool _measured;

		public FillWidthMvxImageView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
		}

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			var width = MeasureSpec.GetSize(widthMeasureSpec);
			double height = MeasureSpec.GetSize(widthMeasureSpec);

			if (_measured)
			{
				base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
				return;
			}

			var drawable = Drawable as BitmapDrawable;
			if (drawable?.Bitmap != null)
			{
				var ratio = (double)drawable.Bitmap.Width / width;
				height = drawable.Bitmap.Height / ratio;
				_measured = true;
			}
			else // Recycler resize fix
			{
				width = 1;
				height = 1;
			}

			base.OnMeasure(MeasureSpec.MakeMeasureSpec(width, MeasureSpecMode.Exactly),
				MeasureSpec.MakeMeasureSpec((int)height, MeasureSpecMode.Exactly));
		}
	}
}