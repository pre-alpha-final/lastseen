using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using LastSeen.Core.POs;
using System;

namespace LastSeen.Droid.Controls
{
	class SeasonEpisodeSelector : LinearLayout
	{
		private EditText _episodeEditText;

		private ItemPO _itemPO;
		public ItemPO ItemPo
		{
			get
			{
				return _itemPO;
			}
			set
			{
				_itemPO = value;
				SetValues();
			}
		}

		private void SetValues()
		{
			_episodeEditText.Text = ItemPo.Episode.ToString();
		}

		public SeasonEpisodeSelector(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			LayoutInflater.From(Context).Inflate(Resource.Layout.season_episode_selector, this);
		}

		protected override void OnFinishInflate()
		{
			_episodeEditText = FindViewById<EditText>(Resource.Id.episode_edittext);
			_episodeEditText.AfterTextChanged += EpisodeEditText_AfterTextChanged;
			SetValues();

			var episodeUp = FindViewById<FillWidthImageButton>(Resource.Id.episode_up);
			episodeUp.Click += EpisodeUp_Click;

			base.OnFinishInflate();
		}

		private void EpisodeEditText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
		{
			ItemPo.Episode = Int32.Parse(_episodeEditText.Text != "" ? _episodeEditText.Text : "1");
		}

		private void EpisodeUp_Click(object sender, System.EventArgs e)
		{
			_episodeEditText.Text = (ItemPo.Episode + 1).ToString();
		}
	}
}