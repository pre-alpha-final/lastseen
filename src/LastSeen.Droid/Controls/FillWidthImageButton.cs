using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Java.Lang;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Platform;

namespace LastSeen.Droid.Controls
{
	public class FillWidthImageButton : AppCompatButton
	{
		private TouchListener _listener;
		private IMvxImageHelper<Bitmap> _imageHelper;

		public FillWidthImageButton(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			_listener = new TouchListener(this);
		}

		public string ImageUrl
		{
			get { return ImageHelper?.ImageUrl; }
			set
			{
				if (ImageHelper == null)
					return;
				ImageHelper.ImageUrl = value;
			}
		}

		protected IMvxImageHelper<Bitmap> ImageHelper
		{
			get
			{
				if (_imageHelper == null)
					if (!Mvx.TryResolve(out _imageHelper))
						MvxTrace.Error(
							"No IMvxImageHelper registered - you must provide an image helper before you can use a MvxImageView");
					else
						_imageHelper.ImageChanged += ImageHelperOnImageChanged;
				return _imageHelper;
			}
		}

		protected override void OnFinishInflate()
		{
			base.OnFinishInflate();

			Gravity = GravityFlags.Center;

			//ImageUrl = "https://lh3.googleusercontent.com/YGqr3CRLm45jMF8eM8eQxc1VSERDTyzkv1CIng0qjcenJZxqV5DBgH5xlRTawnqNPcOp=w300";

			using (var h = new Handler(Looper.MainLooper))
				h.Post(() => Background = new BitmapDrawable(BitmapFactory.DecodeResource(Resources, Resource.Drawable.off)));

			//var sidesPadding = Resources.DpToPx(15);
			//var topPadding = Resources.DpToPx(7);
			//SetPadding(sidesPadding, topPadding, sidesPadding, topPadding);

			//SetAllCaps(false);

			//if ((int)FontSize != -1)
			//	SetTextAppearance();

			//if (Checked)
			//	SetOnStyle();
			//else
			//	SetOffStyle();
		}

		private void ImageHelperOnImageChanged(object sender, MvxValueEventArgs<Bitmap> mvxValueEventArgs)
		{
			using (var h = new Handler(Looper.MainLooper))
				h.Post(() => Background = new BitmapDrawable(Resources, mvxValueEventArgs.Value));
		}

		public override void SetMaxHeight(int maxHeight)
		{
			if (ImageHelper != null)
				ImageHelper.MaxHeight = maxHeight;

			base.SetMaxHeight(maxHeight);
		}

		public override void SetMaxWidth(int maxWidth)
		{
			if (ImageHelper != null)
				ImageHelper.MaxWidth = maxWidth;

			base.SetMaxWidth(maxWidth);
		}

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			var width = MeasureSpec.GetSize(widthMeasureSpec);
			double height = MeasureSpec.GetSize(widthMeasureSpec);

			var drawable = Background as BitmapDrawable;
			if (drawable?.Bitmap != null)
			{
				var ratio = (double)drawable.Bitmap.Width / width;
				height = drawable.Bitmap.Height / ratio;
			}
			else // Recycler resize fix
			{
				width = 1;
				height = 1;
			}

			base.OnMeasure(MeasureSpec.MakeMeasureSpec(width, MeasureSpecMode.Exactly),
				MeasureSpec.MakeMeasureSpec((int)height, MeasureSpecMode.Exactly));
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_imageHelper != null)
				{
					_imageHelper.ImageChanged -= ImageHelperOnImageChanged;
					_imageHelper.Dispose();
					if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
						SetOnTouchListener(null);
				}
			}

			base.Dispose(disposing);
		}

		private class TouchListener : Object, IOnTouchListener
		{
			private readonly FillWidthImageButton _button;
			private bool _clicked;

			public TouchListener(FillWidthImageButton styledButton)
			{
				_button = styledButton;
			}

			public bool OnTouch(View v, MotionEvent e)
			{
				switch (e.Action)
				{
					case MotionEventActions.Down:
						_clicked = true;
						break;
					case MotionEventActions.Cancel:
						_clicked = false;
						break;
					case MotionEventActions.Up:
						if (_clicked)
						{
							_clicked = false;

							// change image 

							// delegate changing image back
						}
						break;
				}
				return false;
			}
		}
	}
}