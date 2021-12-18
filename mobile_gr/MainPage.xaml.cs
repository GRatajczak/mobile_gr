using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mobile_gr
{

    public partial class MainPage : ContentPage
    {

        string translatedNumber = default(string);
        public MainPage()
        {
            InitializeComponent();
          
        }
        void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = phoneNumber.Text;
            translatedNumber = mobile_gr.PhoneTranslator.ToNumber(enteredNumber);
            if (!string.IsNullOrEmpty(translatedNumber))
            {
                call.IsEnabled = true;
                call.Text = "Zadźwoń do " + translatedNumber;
            }
            else
            {
                call.IsEnabled = true;
                call.Text = "Zadźwoń do " + translatedNumber;
            }
        }

        async void OnCall(object sender, System.EventArgs e)
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