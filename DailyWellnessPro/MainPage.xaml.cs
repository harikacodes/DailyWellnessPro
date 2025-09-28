using Microsoft.Maui.Controls;
using System;

namespace DailyWellnessPro
{
    public partial class MainPage : ContentPage
    {
        private string _gender = "";

        public MainPage()
        {
            InitializeComponent();

            SleepSlider.ValueChanged += (s, e) =>
            {
                SleepLabel.Text = $"{Math.Round(e.NewValue, 1)} h";
            };

            StressSlider.ValueChanged += (s, e) =>
            {
                StressLabel.Text = $"{Math.Round(e.NewValue, 1)}";
            };

            ActivitySlider.ValueChanged += (s, e) =>
            {
                ActivityLabel.Text = $"{Math.Round(e.NewValue, 0)} min";
            };

            NextBtn.Clicked += OnNextClicked;
        }

        private void OnMaleSelected(object sender, EventArgs e)
        {
            _gender = "Male";
            HighlightGenderSelection();
        }

        private void OnFemaleSelected(object sender, EventArgs e)
        {
            _gender = "Female";
            HighlightGenderSelection();
        }

        private void HighlightGenderSelection()
        {
            if (_gender == "Male")
            {
                MaleFrame.BorderColor = Colors.Blue;
                MaleImage.Opacity = 1.0;
                MaleImage.Scale = 1.1;

                FemaleFrame.BorderColor = Colors.Transparent;
                FemaleImage.Opacity = 0.5;
                FemaleImage.Scale = 1.0;
            }
            else if (_gender == "Female")
            {
                FemaleFrame.BorderColor = Colors.DeepPink;
                FemaleImage.Opacity = 1.0;
                FemaleImage.Scale = 1.1;

                MaleFrame.BorderColor = Colors.Transparent;
                MaleImage.Opacity = 0.5;
                MaleImage.Scale = 1.0;
            }
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_gender))
            {
                await DisplayAlert("Error", "Please select a gender.", "OK");
                return;
            }

            double sleep = Math.Round(SleepSlider.Value, 1);
            double stress = Math.Round(StressSlider.Value, 1);
            double activity = Math.Round(ActivitySlider.Value, 0);

            await Navigation.PushAsync(new ResultPage(_gender, sleep, stress, activity));
        }
    }
}
