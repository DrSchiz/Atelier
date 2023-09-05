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
using Atelier.Models;

namespace Atelier
{
    /// <summary>
    /// Логика взаимодействия для Articles.xaml
    /// </summary>
    public partial class Articles : Window
    {
        public Articles()
        {
            InitializeComponent();
        }

        private async Task<List<ArticleView>> DgLoaded()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(token.Ftoken);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.value);
                    using (var response = await httpClient.GetAsync("https://192.168.234.12:7045/api/Articles"))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            string apiResp = await response.Content.ReadAsStringAsync();
                            List<ArticleView> articles = JsonConvert.DeserializeObject<List<ArticleView>>(apiResp);
                            return articles;
                        }
                    }
                }
            }
            return null;
        }
        private async Task<List<TypeArticle>> CbLoaded()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(token.Ftoken);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.value);
                    using (var response = await httpClient.GetAsync("https://192.168.234.12:7045/api/TypeArticles/GetAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            string apiResp = await response.Content.ReadAsStringAsync();
                            List<TypeArticle> types = JsonConvert.DeserializeObject<List<TypeArticle>>(apiResp);
                            return types;
                        }
                    }
                }
            }
            return null;
        }

        private async Task<TypeArticle> One(TypeArticle typeArticle)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(token.Ftoken);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.value);
                    StringContent content = new StringContent(JsonConvert.SerializeObject(typeArticle), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://192.168.234.12:7045/api/TypeArticles/GetOne", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TypeArticle type = JsonConvert.DeserializeObject<TypeArticle>(apiResponse);
                            return type;
                        }
                    }
                }
            }
            return null;
        }

        private async void dgMaterials_Loaded(object sender, RoutedEventArgs e)
        {
            dgArticles.ItemsSource = await DgLoaded();
        }

        private async void TypeArticle_Loaded(object sender, RoutedEventArgs e)
        {
            List<TypeArticle> types = await CbLoaded();
            TypeArticles.ItemsSource = types.Select(x => x.Name).ToList();
        }

        private async void Create_Click(object sender, RoutedEventArgs e)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                string name = TypeArticles.SelectedValue.ToString();
                TypeArticle type = new TypeArticle()
                {
                    Name = name
                };
                TypeArticle one = await One(type);
                Article article = new Article()
                {
                    Name = Name.Text,
                    IdType1 = one.IdType,
                    Price = Convert.ToInt32(Price.Text)
                };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(token.Ftoken);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.value);
                    StringContent content = new StringContent(JsonConvert.SerializeObject(article), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://192.168.234.12:7045/api/Articles", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            dgArticles.ItemsSource = null;
                            dgArticles.ItemsSource = await DgLoaded();
                        }
                    }
                }
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            this.Close();
        }
    }
}
