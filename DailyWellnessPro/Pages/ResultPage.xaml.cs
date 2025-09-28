using System;
using Microsoft.Maui.Controls;

namespace DailyWellnessPro
{
    public partial class ResultPage : ContentPage
    {
        private string _gender;
        private double _sleep;
        private double _stress;
        private double _activity;

        private string _status;

        public ResultPage(string gender, double sleep, double stress, double activity)
        {
            InitializeComponent();

            _gender = gender;
            _sleep = sleep;
            _stress = stress;
            _activity = activity;

            CalculateWellness();

            RecommendationsBtn.Clicked += OnRecommendationsClicked;
            BackBtn.Clicked += OnBackClicked;
        }

        private void CalculateWellness()
        {
            // Simple weighted scoring system
            double score = 0;
            score += (_sleep / 12) * 30;   // sleep weight
            score += ((10 - _stress) / 10) * 30; // stress weight
            score += (_activity / 120) * 40; // activity weight

            int finalScore = (int)Math.Round(score);
            ScoreLabel.Text = $"Wellness Score: {finalScore}";

            if (finalScore >= 80)
                _status = "Excellent";
            else if (finalScore >= 60)
                _status = "Good";
            else if (finalScore >= 40)
                _status = "Fair";
            else
                _status = "Poor";

            StatusLabel.Text = $"Status: {_status}";
        }

        private async void OnRecommendationsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecommendationPage(_status, _gender));
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
