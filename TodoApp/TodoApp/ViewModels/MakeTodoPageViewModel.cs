using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
    public class MakeTodoPageViewModel : BaseViewModel
    {

        public ICommand DeleteCommand { get; set; }
        
        public ICommand CancelCommand { get; set; }
        
        public ICommand PhoneSpecs { get; set; }
        
        public ICommand SaveCommand { get; set; }
        public TodoItem Item { get; set; }
        public MakeTodoPageViewModel()
        {
            Item = new TodoItem();
            
            SaveCommand = new Command(execute: async () =>
            {
                await App.Database.SaveItemAsync(Item);
                OnPropertyChanged();
                await Application.Current.MainPage.Navigation.PopAsync();
            });
            
            DeleteCommand = new Command(execute: async () =>
            {
                await App.Database.DeleteItemAsync(Item);
                OnPropertyChanged();
                await Application.Current.MainPage.Navigation.PopAsync();
            });
            
            CancelCommand = new Command(execute: async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
            
            
            PhoneSpecs = new Command(execute: async () =>
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                    {
                        var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
                        const string device = "You are using an Android Device";
                        await Application.Current.MainPage.DisplayAlert(title:"Hi there",message: device, cancel: "Ok, thanks");
                        break;
                    }
                    case Device.iOS:
                    {
                        // iOS specific code
                        var device = DeviceInfo.Platform.ToString();
                        var deviceInfo = device + " device";
                        var deviceBattery = Battery.ChargeLevel.ToString();
                        var secText = "Battery level: " + deviceBattery;
                        await Application.Current.MainPage.DisplayAlert(deviceInfo, secText, "Ok, thanks");
                        break;
                    }
                }
            });
            
        }
    }
}