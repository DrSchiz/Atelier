using AtelierAPI.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.IO;
using Path = System.IO.Path;

namespace Atelier
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            
            InitializeComponent();
        }
        private async Task<List<OrderView>> DgLoaded()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(token.Ftoken);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.value);
                    using (var response = await httpClient.GetAsync("https://192.168.234.12:7045/api/Orders"))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            string apiResp = await response.Content.ReadAsStringAsync();
                            List<OrderView> order = JsonConvert.DeserializeObject<List<OrderView>>(apiResp);
                            return order;
                        }
                    }
                }
            }
            return null;
        }

        private async void dgOrders_Loaded(object sender, RoutedEventArgs e)
        {
            dgOrders.ItemsSource = await DgLoaded();
        }

        private async void Accept_Click(object sender, RoutedEventArgs e)
        {
            OrderView orderView = dgOrders.SelectedItem as OrderView;
            Order order = await GetOrder(orderView.НомерЗаказа);
            order.IdStatus = 2;
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(token.Ftoken);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.value);
                    StringContent content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("https://192.168.234.12:7045/api/Orders/" + order.IdOrder, content))
                    {
                        dgOrders.ItemsSource = null;
                        dgOrders.ItemsSource = await DgLoaded();
                    }
                }
            }
        }

        private async Task<Order> GetOrder(int? id)
        {
            Order order = new Order();
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(token.Ftoken);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.value);
                    using (var response = await httpClient.GetAsync("https://192.168.234.12:7045/api/Orders/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        order = JsonConvert.DeserializeObject<Order>(apiResponse);
                    }
                }
            }
            return order;
        }

        private void dgOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Accept.IsEnabled = true;
        }

        private void btnGetUsers_Click(object sender, RoutedEventArgs e)
        {
            GetUsers getUsers = new GetUsers();
            getUsers.Show();
            this.Close();
        }

        private void btnGetMaterials_Click(object sender, RoutedEventArgs e)
        {
            GetMaterials getMaterials = new GetMaterials();
            getMaterials.Show();
            this.Close();
        }

        private void btnArticles_Click(object sender, RoutedEventArgs e)
        {
            Articles articles = new Articles();
            articles.Show();
            this.Close();
        }
        private static readonly string registryPath = Path.Combine(Registry.CurrentUser.Name, "Software", "MyLoginSaver");

        private static string GetRegistryKey(string key)
        {
            return (string)Registry.GetValue(registryPath, key, string.Empty);
        }

        private static void SetRegistryKey(string key, string value)
        {
            Registry.SetValue(registryPath, key, value, RegistryValueKind.String);
        }
        private void Escape_Click(object sender, RoutedEventArgs e)
        {
            SetRegistryKey("Login", "");
            SetRegistryKey("Password", "");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
