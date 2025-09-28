using System;
using Microsoft.Maui.Controls;

namespace DailyWellnessPro
{
    public partial class RecommendationPage : ContentPage
    {
        private string _status;
        private string _gender;

        public RecommendationPage(string status, string gender)
        {
            InitializeComponent();

            _status = status;
            _gender = gender;

            SetRecommendations();

            BackToResultsBtn.Clicked += OnBackToResultsClicked;
            BackToInputsBtn.Clicked += OnBackToInputsClicked;
        }

        private void SetRecommendations()
        {
            string recommendation = "";

            if (_status == "Excellent")
            {
                recommendation = _gender == "Male"
                    ? "Maintain routine; include resistance training 2–3×/week; ensure protein intake across meals."
                    : "Keep strong habits; add yoga/pilates for recovery; prioritize calcium + vitamin D intake.";
            }
            else if (_status == "Good")
            {
                recommendation = _gender == "Male"
                    ? "Earlier bedtime for recovery; add 15 min light cardio/stretching; maintain hydration."
                    : "Balanced breakfast; add 15 min walking; focus on iron-rich foods if feeling low.";
            }
            else if (_status == "Fair")
            {
                recommendation = _gender == "Male"
                    ? "Aim for +1 hour sleep; reduce caffeine after noon; schedule light mobility/easy walk."
                    : "Improve sleep consistency; reduce evening screen time; add calming routines (meditation/journaling).";
            }
            else if (_status == "Poor")
            {
                recommendation = _gender == "Male"
                    ? "Rest today; avoid strenuous workouts; hydrate and take 20–30 min gentle walk."
                    : "Prioritize rest/self-care; short nap if possible; gentle yoga/stretching only.";
            }

            RecommendationLabel.Text = recommendation;
        }

        private async void OnBackToResultsClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnBackToInputsClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
