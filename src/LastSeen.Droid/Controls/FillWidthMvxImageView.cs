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
		public FillWidthMvxImageView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
		}

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			var width = MeasureSpec.GetSize(widthMeasureSpec);
			double height = MeasureSpec.GetSize(widthMeasureSpec);

			var drawable = Drawable as BitmapDrawable;
			if (drawable?.Bitmap != null)
			{
				var ratio = (double)drawable.Bitmap.Width / width;
				height = drawable.Bitmap.Height / ratio;
			}

			base.OnMeasure(MeasureSpec.MakeMeasureSpec(width, MeasureSpecMode.Exactly),
				MeasureSpec.MakeMeasureSpec((int)height, MeasureSpecMode.Exactly));
		}
	}
}