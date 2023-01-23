function chamarApiPessoa()
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
    $.ajax({
        url: "http://localhost:5438/Pessoa",
        type: "POST",
        data: JSON.stringify(request),  //pega o objeto request e transforma em um json
        contentType: "application/json",
        dataType: "json",
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