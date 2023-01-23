function chamarApi()
{
    //comunicação front e back
    $.ajax({  //parâmetros obrigatórios:
        url: "http://localhost:52914/OlaMundo",
        type: "GET",   //type é o método
        dataType: "json",  //tipo de formato da integração
        success: function (resposta) {   //se deu sucesso o que ele faz, o que vai executar
           $("#mensagem").text(resposta.mensagem)   //jquery elementos
        },
        error: function (request, message, error) {  //se deu erro o que ele faz, o que vai executar
            alert(message);
        }  
    })
}