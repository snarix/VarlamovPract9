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
                // Получаем поток изображения
                var stream = await result.OpenReadAsync();
                // Читаем изображение из потока
                byte[] imageBytes = new byte[stream.Length];
                await stream.ReadAsync(imageBytes, 0, (int)stream.Length);

                // Создаем изображение из байтов и устанавливаем его в элемент Image
                loadedImage.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            }
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            Preferences.Default.Set("surname", Surname.Text);
            Preferences.Default.Set("name", Name.Text);
            Preferences.Default.Set("otchestvo", Otchestvo.Text);
            Preferences.Default.Set("age", Age.Text);
            Preferences.Default.Set("gender", Gender);
            Preferences.Default.Set("image", loadedImage);
            Preferences.Default.Set("общага", NeedsDormitorySwitch);
            Preferences.Default.Set("староста", IsMonitorSwitch);
            Preferences.Default.Set("средняя оценка", stepperAvgRate);

        }
    }
}