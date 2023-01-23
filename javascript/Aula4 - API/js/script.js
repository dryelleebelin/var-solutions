const loadingElement = document.querySelector("#loading")
const postsContainer = document.querySelector("#posts-container")
const botao = document.querySelector("#botaoBuscar")

const url = "http://jsonplaceholder.typicode.com/posts"

//pegar a url
const urlParametros = new URLSearchParams(window.location.search,)  //!!!!  //acessar o que tem na url
const idPost = urlParametros.get("id")
const comentariosContainer = document.querySelector("#comentarios-container")

const comentarioForm = document.querySelector("#comentario-form")
const emailinput = document.querySelector("#email")
const comentarioinput = document.querySelector("#tcomentario")

if (!idPost) {
    BuscarTodosPosts()
} else {
    BuscaPostEspecifico(idPost)  //tratar aqui o método de gravar comentários e visualizar detalhe do post

    comentarioForm.addEventListener("submit", (e) => {
        e.preventDefault()

        let comentarioInserido = {
            email: emailinput.value,
            body: comentarioinput.value,
        }
        comentarioInserido = JSON.stringify(comentarioInserido)
        
        postComentario(comentarioInserido)
    })
}

async function BuscarTodosPosts() {      //sempre vem acompanhado do await  //p que as coisas aconteçam em segundo plano
    const resposta = await fetch(url)    //constante + nome  //recebe  //await  //chamada fetch
    const data = await resposta.json()

    loadingElement.classList.add("hide")   //elemento invisível

    data.map((postagem) => {        //mapear os dados
        const div = document.createElement("div")   //elementos
        const title = document.createElement("h2")
        const body = document.createElement("p")
        const link = document.createElement("a")

        title.innerText = postagem.title
        body.innerText = postagem.body
        
        link.innerText = "Ler"
        link.setAttribute("href", './post.html?id=' + postagem.id)

        div.appendChild(title)
        div.appendChild(body)
        div.appendChild(link)
        postsContainer.appendChild(div)
    })
}

async function BuscaPostEspecifico(id) {
    //const respostaPost = await fetch(url + "/" + id)  //ou fetch(`${url}/${id}`)
    //const respostaComentario = await fetch(`${url}/${id}/comments`)

    const [respostaPost, respostaComentario] = await Promise.all([
        fetch(url + "/" + id), 
        fetch(`${url}/${id}/comments`),
    ])

    const dataPostagem = await respostaPost.json()
    const dataComentario = await respostaComentario.json()

    loadingElement.classList.add("hide")

    const title = document.createElement("h1")
    const body = document.createElement("p")

    title.innerText = dataPostagem.title
    body.innerText = dataPostagem.body

    postsContainer.appendChild(title)
    postsContainer.appendChild(body)

    dataComentario.map((comentario) => {
        criarComentario(comentario)
    })
}

function criarComentario(comentario) {
    const divComentario = document.createElement("div")
    const email = document.createElement("h3")
    const paragrafocomentario = document.createElement("p")

    email.innerText = comentario.email
    paragrafocomentario.innerText = comentario.body

    divComentario.appendChild(email)
    divComentario.appendChild(paragrafocomentario)
    comentariosContainer.appendChild(divComentario)
}

async function postComentario (comentario)
{
    const resposta = await fetch(url, {
        method: "POST",
        body: comentario,
        headers: {
            "Content-type": "application/json",
        }
    })
    const dataResposta = await resposta.json()

    criarComentario(dataResposta)
}