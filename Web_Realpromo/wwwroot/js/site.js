// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var connection = new signalR.HubConnectionBuilder().withUrl("/PromoHub").build();
//var connection = new signalR.HubConnectionBuilder().withUrl("/PromoHub").build();

connection.start().then(function () {
    console.info("Conectado!");
}).catch(function (err) {
    console.error(err.toString());
    });

connection.on("CadastradoSucesso", function () {
    var mensagem = document.getElementById("mensagem").innerHTML = "Cadastro de Promoção realizado com sucesso!";
});

connection.on("ReceberPromocao", function (promocao) {
    //
    var container = document.getElementById('divPromo');

    var containerRow = document.createElement("div");
    containerRow.setAttribute("class", "row");

    var containerPromo = document.createElement("div");
    containerPromo.setAttribute("class", "col-md-12 alert alert-primary");

    var h3Promocao = document.createElement("h3");
    h3Promocao.innerHTML = promocao.chamada;
   
    var p1Regras = document.createElement("p");
    p1Regras.innerHTML = promocao.regras;

    var p2Empresa = document.createElement("p");
    p2Empresa.innerHTML = promocao.empresa;

    var linkNav = document.createElement("a");
    linkNav.setAttribute("href", promocao.url);
    linkNav.setAttribute("target", "_blank");
    linkNav.innerHTML = "Pegar promoção >>";

    containerPromo.appendChild(h3Promocao);
    containerPromo.appendChild(p1Regras);
    containerPromo.appendChild(p2Empresa);
    containerPromo.appendChild(linkNav);

    containerRow.appendChild(containerPromo);

    container.appendChild(containerPromo);
    /*
    <div class='row'>
        <div class='col-md-12 alert alert-primary' role='alert'>
            <h3>Promoções 123</h3>
            <p>Empresa</p>
            <p>Descrição da promoção e das vantanges </p>
            <a href="#!"></a>
        </div>
    </div> */
    //console.info(promocao);
});

var btnCadastrar = document.getElementById('btnCadastrar');
if (btnCadastrar !== null) {
    btnCadastrar.addEventListener("click", function () {
        var empresa = document.getElementById('txtEmpresa').value;
        var chamada = document.getElementById('txtChamada').value;
        var regras = document.getElementById('txtRegras').value;
        var url = document.getElementById('txtURL').value;

        var promocao = { Empresa: empresa, Chamada: chamada, Regras: regras, EnderecoURL: url };

        //TODO - SignalR chamar o cadastro de promoções;
        connection.invoke("CadastrarPromocao", promocao).then(function () {
            console.info("Cadastrado com sucesso!");
        }).catch(function (err) {
            console.error(err.toString());
        });

    });
}
