using AtelierAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    /// Логика взаимодействия для GetMaterials.xaml
    /// </summary>
    public partial class GetMaterials : Window
    {
        public GetMaterials()
        {
            InitializeComponent();
        }
        private async Task<List<MaterialView>> DgLoaded()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(token.Ftoken);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.value);
                    using (var response = await httpClient.GetAsync("https://192.168.234.12:7045/api/Materials"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResp = await response.Content.ReadAsStringAsync();
                            List<MaterialView> material = JsonConvert.DeserializeObject<List<MaterialView>>(apiResp);
                            return material;
                        }
                    }
                }
            }
            return null;
        }

        private async void dgMaterials_Loaded(object sender, RoutedEventArgs e)
        {
            dgMaterials.ItemsSource = await DgLoaded();
        }

        private void dgMaterials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Buy.IsEnabled = true;
        }

        private async void Buy_Click(object sender, RoutedEventArgs e)
        {
            MaterialView IDMaterial = dgMaterials.SelectedItem as MaterialView;
            Material material = await GetMaterialView(IDMaterial.НомерМатериала);
            material.Amount = IDMaterial.Количество10мРул + Convert.ToInt32(Amount.Text);
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(token.Ftoken);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.value);
                    StringContent content = new StringContent(JsonConvert.SerializeObject(material), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("https://192.168.234.12:7045/api/Materials/" + IDMaterial.НомерМатериала, content))
                    {
                        dgMaterials.ItemsSource = null;
                        dgMaterials.ItemsSource = await DgLoaded();
                    }
                }
            }
        }

        private async Task<Material> GetMaterialView(int? id)
        {
            Material material = new Material();
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(token.Ftoken);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.value);
                    using (var response = await httpClient.GetAsync("https://192.168.234.12:7045/api/Materials/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        material = JsonConvert.DeserializeObject<Material>(apiResponse);
                    }
                }
            }
            return material;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            this.Close();
        }
    }
}
