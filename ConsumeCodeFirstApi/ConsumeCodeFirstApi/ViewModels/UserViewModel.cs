using ConsumeCodeFirstApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;

namespace ConsumeCodeFirstApi.ViewModels
{
    public class UserViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Users> userModel;
        public event PropertyChangedEventHandler PropertyChanged;

        public UserViewModel()
        {
            GetProductsAsync();
        }

        public ObservableCollection<Users> UserModel
        {
            get
            {
                return userModel;
            }

            set
            {
                userModel = value;
                OnPropertyChanged("UserModel");
            }
        }
        private async void GetProductsAsync()
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("http://10.0.0.117/codefirstapi/api/User");
            var response = await client.GetStringAsync(uri);
            UserModel = JsonConvert.DeserializeObject<ObservableCollection<Users>>(response);
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
