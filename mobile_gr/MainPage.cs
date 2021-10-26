using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mobile_gr
{
    public class MainPage : ContentPage
    {
        Entry phoneNumberText;
        Button translateButton;
        Button callButton;

        string translatedNumber;

        public MainPage()
        {

 

            this.Padding = new Thickness(20, 20, 20, 20);
            StackLayout panel = new StackLayout
            {
                Spacing = 15
            };
            panel.Children.Add(new Label
            {
                Text = "Wpisz:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });
            panel.Children.Add(phoneNumberText = new Entry
            {
                Text = "1-111-111-111",
            });
            panel.Children.Add(translateButton = new Button
            {
                Text = "Zamień"
            });
            panel.Children.Add(callButton = new Button
            {
                Text = "Zadzwoń",
                IsEnabled = false,
            });
            this.Content = panel;

            translateButton.Clicked += OnTranslate;
            this.Content = panel;

            translateButton.Clicked += OnTranslate;
            callButton.Clicked += OnCallAsync;
            this.Content = panel;
        }


        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = phoneNumberText.Text;
            translatedNumber = mobile_gr.PhoneTranslator.ToNumber(enteredNumber);
            if (!string.IsNullOrEmpty(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Zadźwoń do " + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = true;
                callButton.Text = "Zadźwoń do " + translatedNumber;
            }
        }
        async void OnCallAsync(object sender, System.EventArgs e)
        {
                 if (await this.DisplayAlert(
                     "Wybierz numer",
                     "Zadzwonić do  " + translatedNumber + "?",
                     "Tak",
                     "Nie"))
                 {
                try
                {
                    PhoneDialer.Open(translatedNumber);
                }
                catch (ArgumentNullException)
                {
                    await DisplayAlert("Nie można zadzwonić", "Numer telefonu jest zły", "OK");
                }
                catch (FeatureNotSupportedException)
                {
                    await DisplayAlert("Nie można zadzwonić", "Zamiana numeru jest nie wspierana", "OK");
                }
                catch (Exception)
                {
                    await DisplayAlert("Nie można zadzwonić", "Wystąpił błąd zamiany.", "OK");
                }
            }
        }

    }

}



