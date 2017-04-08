using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using System;

namespace LastSeen.Droid.Controls
{
	class SeasonEpisodeSelector : LinearLayout
	{
		private EditText _counterEditText;

		private int _counter;
		public int Counter
		{
			get	{ return _counter; }
			set
			{
				_counter = value;
				SetValues();
			}
		}

		private void SetValues()
		{
			_counterEditText.Text = Counter.ToString();
		}

		public MvxCommand<int> UpdateValue { get; set; }

		public SeasonEpisodeSelector(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			LayoutInflater.From(Context).Inflate(Resource.Layout.season_episode_selector, this);
		}

		protected override void OnFinishInflate()
		{
			_counterEditText = FindViewById<EditText>(Resource.Id.counter_edittext);
			_counterEditText.AfterTextChanged += CounterEditText_AfterTextChanged;
			SetValues();

			var counterUp = FindViewById<FillWidthImageButton>(Resource.Id.counter_up);
			counterUp.Click += CounterUp_Click;

			var counterDown = FindViewById<FillWidthImageButton>(Resource.Id.counter_down);
			counterDown.Click += CounterDown_Click;

			base.OnFinishInflate();
		}

		private void CounterEditText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
		{
			_counter = Int32.Parse(_counterEditText.Text != "" ? _counterEditText.Text : "1");
		}

		private void CounterUp_Click(object sender, System.EventArgs e)
		{
			_counterEditText.Text = (Counter + 1).ToString();
			UpdateValue?.Execute(Counter);
		}

		private void CounterDown_Click(object sender, EventArgs e)
		{
			_counterEditText.Text = (Counter - 1).ToString();
			UpdateValue?.Execute(Counter);
		}
	}
}