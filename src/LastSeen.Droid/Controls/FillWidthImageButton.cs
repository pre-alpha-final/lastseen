using Android.Content;
using Android.Content.Res;
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
using System.Threading;
using System.Threading.Tasks;
using System;

namespace LastSeen.Droid.Controls
{
	public class FillWidthImageButton : AppCompatButton, View.IOnTouchListener
	{
		private ManualResetEvent _standardDrawableAvailable;

		private BitmapDrawable _standardDrawable;
		public BitmapDrawable StandardDrawable
		{
			get { return _standardDrawable; }
			set
			{
				_standardDrawable = value;
				_standardDrawableAvailable.Set();
			}
		}

		public BitmapDrawable ClickedDrawable { get; set; }

		public FillWidthImageButton(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			SetOnTouchListener(this);

			_standardDrawableAvailable = new ManualResetEvent(false);

			TypedArray typeArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.FillWidthImageButton);
			StandardDrawable = typeArray.GetDrawable(Resource.Styleable.FillWidthImageButton_standard_drawable) as BitmapDrawable;
			ClickedDrawable = typeArray.GetDrawable(Resource.Styleable.FillWidthImageButton_clicked_drawable) as BitmapDrawable;
			typeArray.Recycle();
		}

		protected override async void OnFinishInflate()
		{
			base.OnFinishInflate();

			Gravity = GravityFlags.Center;
			await Task.Run(() => _standardDrawableAvailable.WaitOne(5000));
			UpdateButtonDrawable(false);
		}

		private void UpdateButtonDrawable(bool clicked)
		{
			using (var h = new Handler(Looper.MainLooper))
				h.Post(() => Background = clicked ? ClickedDrawable : StandardDrawable);
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
				if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
					SetOnTouchListener(null);
			}

			base.Dispose(disposing);
		}

		private bool _clicked;
		public bool OnTouch(View v, MotionEvent e)
		{
			Task.Run(async () =>
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
							await Task.Delay(250);
							_clicked = false;
						}
						break;
				}
				UpdateButtonDrawable(_clicked);
			});
			return true;
		}
	}
}