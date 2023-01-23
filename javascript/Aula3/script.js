function incluirRegistro()
{
    let nomeUsuario = document.getElementById('nome').value
    if (nomeUsuario != "")
    {
        let tabela = document.getElementById('tabelaUsuarios')
        let numeroLinhas = tabela.rows.length
        let linha = tabela.insertRow(numeroLinhas)
        let campo1 = linha.insertCell(0)
        let campo2 = linha.insertCell(1)
        campo1.innerHTML = nomeUsuario
        campo2.innerHTML = "<button class='btn btn-warning' onclick='removerLinha(this)'>Remover</button>"
        document.getElementById('nome').value = ""
    }
    else
    {
        alert('Nome inválido')
    }
}

function removerLinha(linha)
{
    let i = linha.parentNode.parentNode.rowIndex
    document.getElementById('tabelaUsuarios').deleteRow(i)
}