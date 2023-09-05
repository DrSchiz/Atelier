using AtelierAPI.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Path = System.IO.Path;

namespace Atelier
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (GetRegistryKey("Login") != "" && GetRegistryKey("Password") != "")
            {
                UserGet user = new UserGet()
                {
                    Login = GetRegistryKey("Login"),
                    Password = GetRegistryKey("Password")
                };
                Authorization(user);
            }
            InitializeComponent();
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




        private async void Authorize_Click(object sender, RoutedEventArgs e)
        {
            UserGet user = new UserGet()
            {
                Login = Login.Text,
                Password = Password.Password
            };
            Authorization(user);
        }
        private async void Authorization(UserGet user)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {

                    StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://192.168.234.12:7045/api/Users/Authorization", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            token.Ftoken = apiResponse;
                            SetRegistryKey("Login", user.Login);
                            SetRegistryKey("Password", user.Password);
                            AdminPanel adminPanel = new AdminPanel();
                            adminPanel.Show();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Введены неверные данные!", "Ошибка авторизации", MessageBoxButton.OK);
                        }
                    }
                }
            }

        }
    }
}
