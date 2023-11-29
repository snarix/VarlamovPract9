namespace VarlamovPract9
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void stepperAvgRate_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Rate.Text = stepperAvgRate.Value.ToString();
            Rate.Text = e.NewValue.ToString();
        }

        private async void LoadPhoto(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                byte[] imageBytes = new byte[stream.Length];
                await stream.ReadAsync(imageBytes, 0, (int)stream.Length);

                loadedImage.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            }
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            Preferences.Set("surname", Surname.Text, "Storage1");
            Preferences.Set("name", Name.Text, "Storage1");
            Preferences.Set("otchestvo", Otchestvo.Text, "Storage1");
            Preferences.Set("age", Age.Text, "Storage1");
            Preferences.Set("gender", Gender.SelectedIndex, "Storage1");
            Preferences.Set("image", loadedImage.ToString(), "Storage1");
            Preferences.Set("общага", obsaga.SelectedIndex, "Storage1");
            Preferences.Set("староста", starosta.SelectedIndex, "Storage1");
            Preferences.Set("средняя оценка", Rate.Text, "Storage1");

        }

        private void LoadClicked(object sender, EventArgs e)
        {
            Surname.Text = Preferences.Get("surname", "", "Storage1");
            Name.Text = Preferences.Get("name", "", "Storage1");
            Otchestvo.Text = Preferences.Get("otchestvo", "", "Storage1");
            Age.Text = Preferences.Get("age", "", "Storage1");
            Gender.SelectedIndex = Preferences.Get("gender", 0, "Storage1");
            //loadedImage.Source = Preferences.Get("image", "", "Storage1");
            obsaga.SelectedIndex = Preferences.Get("общага", 0, "Storage1");
            starosta.SelectedIndex = Preferences.Get("староста", 0, "Storage1");
            Rate.Text = Preferences.Get("средняя оценка", "", "Storage1");
        }
    }
}