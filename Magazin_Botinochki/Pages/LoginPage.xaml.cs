using Magazin_Botinochki.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Magazin_Botinochki.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private ApiClient.ApiClient _apiClient;
        public LoginPage()
        {
            ApiClient.ApiClient apiClient = new ApiClient.ApiClient("https://official-joke-api.appspot.com");
            _apiClient = apiClient;
            InitializeComponent();
        }

        private async void Btn_vxod_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Txb_Login.Text) || string.IsNullOrEmpty(Psb_pass.Password))
            {
                MessageBox.Show("Введите коректные данные! Поля не могут быть пустыми");
                return;
            }


            var joke = await _apiClient.Get<Jokes>("jokes/random");

            Console.WriteLine($"шутк: {joke.setup} - {joke.punchline}");
        }

        private void Txb_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Psb_pass.Focus();
            }
        }
    }
}
