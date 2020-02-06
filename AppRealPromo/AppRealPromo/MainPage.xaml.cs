using AppRealPromo.Models;
using AppRealPromo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppRealPromo
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Promocao> lista = new ObservableCollection<Promocao>();
        public MainPage()
        {
            InitializeComponent();

            new RealPromoSignalR(lista);

            ListviewPromo.ItemsSource = lista;

            /*
            Device.StartTimer(TimeSpan.FromSeconds(10), ()=> {
                lista.Add(new Promocao { Empresa = "Sartorato", Chamada = "UVAS BENETAKA", Regras = "13 CAIXAS POR 13,45" + DateTime.Now, EnderecoURL = "http://www.cloudtracker.com.br" });
                return true;
            }); */
        }

        /*
        private void GetPromocoes()
        {
            
            lista.Add(new Promocao { Empresa = "Sartorato", Chamada = "UVAS BENETAKA", Regras = "13 CAIXAS POR 13,45", EnderecoURL = "http://www.cloudtracker.com.br" });
            lista.Add(new Promocao { Empresa = "Carbofrut", Chamada = "UVAS RUBI", Regras = "16 CAIXAS POR 14,25", EnderecoURL = "http://www.cloudtracker.com.br" });
           
        } */
    }
}
