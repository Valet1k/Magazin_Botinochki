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
    /// Логика взаимодействия для ViewTovar.xaml
    /// </summary>
    public partial class ViewTovar : Page
    {
        public ViewTovar()
        {
            InitializeComponent();

            List<TOVAR> list = new List<TOVAR>
            {
               new TOVAR { NameTovar = "Название1", DescriptionTovar = "Описание1", ImagePath = "https://downloader.disk.yandex.ru/preview/ba542509bb60079777785e47965d409e5465102cc483645af6d3adf1d4b07305/692d40be/ekESBizRgwQI2m8NlMH-kYuQ-wVaFI1yPNd3XsAbAmL4B6XT9g4b54Na1TH1gQAItsoCKB4ZyuVQ31mah4JtSg%3D%3D?uid=0&filename=1.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=0&tknv=v3&size=2048x2048", Price = 100 },
               new TOVAR { NameTovar = "Название2", DescriptionTovar = "Описание2", ImagePath = "https://s355sas.storage.yandex.net/rdisk/5a6de69d55a11bf3a3e0a06d04b3b5c3fd9d029c1909c82d8c7e1c5c1f326a0f/692d4308/fKqInKw3d7bLFOeFnMGnhOXwrLh--frBCQESX_6bbl5--w4oo6shxKP-aX_TGFJZ2YPfbqmoZkNf2Ls9QJml_IT3TyLmnvy5ORggh5y2DBar8npumZHI4midPdWhecNq?uid=1876332537&filename=2.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1876332537&fsize=79395&hid=086a7ca12a7cb6977a9ca11aa221812d&media_type=image&tknv=v3&etag=cda15fcea47e9681fa30e6ec9275ac94&ts=644dee410d200&s=5deb35c63c725a4765a2481624bc0606a2ca179e5e8f57c58cd42676f3060b5a&pb=U2FsdGVkX1_vokfwGD5XYBIO8L_pzqKnHfMOOY1uHs57i-RhTscY_h1Vxfp13EpkgBt-iFZZD3N6bNCi6th8cjXMrf3gzzhfcz59BRndLRsGphNBqhqqmnwAxgHnMjy6", Price = 200 },
               new TOVAR { NameTovar = "Название3", DescriptionTovar = "Описание3", ImagePath = "https://s473vla.storage.yandex.net/rdisk/537cff345aa47bb81c3084fd2536e74ba9b161d89f8aae40ade0406a7c62e280/692d4348/fKqInKw3d7bLFOeFnMGnhDI0DPKkEUw4jP4TD4603JInSZ9Mc_xX5Ve91uLrVS8qX2YVt7PmUdHv6kE8ZneeVgtqvJgORLVMKQXgkxmqx4ar8npumZHI4midPdWhecNq?uid=1876332537&filename=3.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&owner_uid=1876332537&fsize=93102&hid=37787bf049f0b0c34140abb31a3b77f3&media_type=image&tknv=v3&etag=63a56ca36a709dad67b1a04808bdd6d2&ts=644dee7e16200&s=2edf5b5ad414f5ce709f55d3710de7f68412ac1986f53101d946343d4605f5e2&pb=U2FsdGVkX1_mL7617lEdInvX7buBOC9kzoVHsPbneU4sCd-Wc-jWZlGdNUBkjE0WNx-VBIjCRDppvxkiOYtrR7kS5n7nNlWWGn1xLgmXjFFtPEIdno42fAszUU8ehtTq", Price = 300 },
            };

            ItemsViewTovar.ItemsSource = list;

        }



        public class TOVAR
        {
            public string NameTovar { get; set; }

            public string DescriptionTovar { get; set; }

            public string ImagePath {  get; set; }

            public double Price { get; set; }   

        }

        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
