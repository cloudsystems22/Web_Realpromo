using AppRealPromo.Models;
//using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppRealPromo.Services
{
    public class RealPromoSignalR
    {

       


        public RealPromoSignalR(ObservableCollection<Promocao> lista)
        {
            //Task.Run(async()=> { await ConfigurarSignalR(lista); });
            ConfigurarSignalR(lista);
        }

        private void ConfigurarSignalR(ObservableCollection<Promocao> lista)
        {
            /*
            var connection = new HubConnectionBuilder().WithUrl("https://promo.cloudtracker.com.br/PromoHub").Build();

            connection.On<Promocao>("ReceberPromocao", (promocao) => {
                lista.Add(promocao);
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
                    lista.Add(promocao);
                });
                
            }); 
            await connection.StartAsync();*/

            var hubConnection = new HubConnection("https://promo.cloudtracker.com.br/");
            IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("promoHub");
            stockTickerHubProxy.On<Promocao>(
            "Send", promocao =>
             //Console.WriteLine("Stock update for {0} new price {1}", promocao.Chamada, promocao.Empresa)
             lista.Add(promocao)
            );

            if(hubConnection.State == ConnectionState.Disconnected)
            {
                TimeSpan retryDuration = TimeSpan.FromSeconds(5);
                hubConnection.Start();
            }

            hubConnection.Start();

        }

       
    }
}
