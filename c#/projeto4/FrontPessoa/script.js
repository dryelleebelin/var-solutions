function processar() //token
{
    var requestAutenticacao = {  //requisição
        "Username": $("#txt_usuario").val(),
        "Password": $("#txt_senha").val()
    }
    $.ajax({  //chamada ajax
        url: "http://localhost:5438/Autenticacao",
        type: "POST",
        data: JSON.stringify(requestAutenticacao), 
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            processarDadosPessoa(response.token)
            console.log(response.token)
        },
        error: function (request, message, error) {
            alert("Erro ao se autenticar!")
        }
    })
}

function processarDadosPessoa(token) 
{
    var request = {  //json
        "Nome": $("#txt_nome").val(),
        "DataNascimento": $("#txt_data").val(),
        "Altura": parseFloat($("#txt_altura").val()),  //conversão
        "Peso": parseFloat($("#txt_peso").val()),
        "Salario": parseFloat($("#txt_salario").val()),
        "Saldo": parseFloat($("#txt_saldo").val())
    }
    //chamada backend
    console.log(token)
    $.ajax({
        url: "http://localhost:5438/Pessoa",
        type: "POST",
        data: JSON.stringify(request), 
        contentType: "application/json",
        dataType: "JSON",
        headers: {"Authorization": "Bearer " + token},
        success: function (resposta) {
            $("#resultado_nome").text("Nome: " + resposta.nome)
            $("#resultado_idade").text("Idade: " + resposta.idade)
            $("#resultado_imc").text("IMC: " + resposta.imc)
            $("#resultado_classificacao").text("Classificação do IMC: " + resposta.classificacao)
            $("#resultado_inss").text("INSS: " + resposta.inss)
            $("#resultado_aliquota").text("Aliquota: " + resposta.aliquota)
            $("#resultado_salarioLiquido").text("Salário Liquido: " + resposta.salarioLiquido)
            $("#resultado_saldoDolar").text("Saldo em dólar: " + resposta.saldoDolar)
        },
        error: function (request, message, error) {
            alert("Não conseguimos nos comunicar com o back!")
        }
    })
}