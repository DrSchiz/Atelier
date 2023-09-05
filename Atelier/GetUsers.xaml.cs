using AtelierAPI.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Atelier
{
    /// <summary>
    /// Логика взаимодействия для GetUsers.xaml
    /// </summary>
    public partial class GetUsers : Window
    {
        public GetUsers()
        {
            InitializeComponent();
        }

        private async Task<List<User>> DgLoaded(string status)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(token.Ftoken);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.value);
                    using (var response = await httpClient.GetAsync($"https://192.168.234.12:7045/api/Users/{status}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResp = await response.Content.ReadAsStringAsync();
                            List<User> users = JsonConvert.DeserializeObject<List<User>>(apiResp);
                            return users;
                        }
                    }
                }
            }
            return null;
        }

        private async void dgUsersActive_Loaded(object sender, RoutedEventArgs e)
        {
            dgUsersActive.ItemsSource = await DgLoaded("Active");
        }
        private async void dgUsersDeleted_Loaded(object sender, RoutedEventArgs e)
        {
            dgUsersDeleted.ItemsSource = await DgLoaded("Deleted");
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            this.Close();
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            User IDuser = dgUsersActive.SelectedItem as User;
            User user = await GetUser(IDuser.IdUser);
            user.IdStatus = 1;
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(token.Ftoken);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.value);
                    StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("https://192.168.234.12:7045/api/Users/" + user.IdUser, content))
                    {
                        dgUsersActive.ItemsSource = null;
                        dgUsersActive.ItemsSource = await DgLoaded("Active");
                        dgUsersDeleted.ItemsSource = null;
                        dgUsersDeleted.ItemsSource = await DgLoaded("Deleted");
                    }
                }
            }
        }

        private async Task<User> GetUser(int? id)
        {
            User user = new User();
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(token.Ftoken);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.value);
                    using (var response = await httpClient.GetAsync("https://192.168.234.12:7045/api/Users/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<User>(apiResponse);
                    }
                }
            }
            return user;
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Delete.IsEnabled = true;
        }

    }
}
