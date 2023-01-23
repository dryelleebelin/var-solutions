function incluirRegistro()
{
    let nomeUsuario = document.getElementById('nome').value
    let emailUsuario = document.getElementById('email').value 
    let telefoneUsuario = document.getElementById('telefone').value
    if (nomeUsuario, emailUsuario, telefoneUsuario != "")  //melhorar
    {
        let tabela = document.getElementById('tabelaUsuarios')
        let numeroLinhas = tabela.rows.length
        let linha = tabela.insertRow(numeroLinhas)
        let campo1 = linha.insertCell(0)
        let campo2 = linha.insertCell(1)
        let campo3 = linha.insertCell(2)  
        let campo4 = linha.insertCell(3)
        let campo5 = linha.insertCell(4)
        campo1.innerHTML = nomeUsuario
        campo2.innerHTML = emailUsuario 
        campo3.innerHTML = telefoneUsuario
        campo5.innerHTML = "<button class='btn btn-danger' onclick='removerLinha(this)'>Remover</button>"
        document.getElementById('nome').value = ""
        document.getElementById('email').value = ""
        document.getElementById('telefone').value = ""
    }
    else
    {
        alert('Conteúdo inválido')
    }
}

function removerLinha(linha)
{
    let i = linha.parentNode.parentNode.rowIndex
    document.getElementById('tabelaUsuarios').deleteRow(i)
}