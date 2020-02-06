using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppRealPromo.Models;

namespace Web_Realpromo.Hubs
{
    public class PromoHub : Hub
    {
        /*
         * Client - JS/C#/Java
         * RPC
         * Client(JS) --> Hub(C#) (C# - Cliente cadastra promo)
         * Hub(C#) --> Cliente(JS) (JS - Servidor recebe)
         */

        public async Task CadastrarPromocao(Promocao promocao)
        {
            /*
             * Notificar o usuário
             */
            await Clients.Caller.SendAsync("CadastradoSucesso"); //Notificar o Caller --> Cadastro realizado com sucesso!
            await Clients.Others.SendAsync("ReceberPromocao", promocao); //Notificar a promoção!

        }

    }
}
