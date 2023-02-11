package com.br.varsolutions;

public class PessoaResponse {  //saída
    public String nome;
    public String sobrenome;
    public int idade;
    public int anoNascimento;
    public String mundialClubes;
    public String endereco;
    public String imc;
    public String classificacaoIMC;
    public String salario;
    public String iR;
    public String aliquota;




    public String getMundialClubes() {
        return mundialClubes;
    }

    public void setMundialClubes(String mundialClubes) {
        this.mundialClubes = mundialClubes;
    }

    public int getAnoNascimento() {
        return anoNascimento;
    }

    public void setAnoNascimento(int anoNascimento) {
        this.anoNascimento = anoNascimento;
    }

    public String getImc() {
        return imc;
    }

    public void setImc(String imc) {
        this.imc = imc;
    }

    public String getClassificacaoIMC() {
        return classificacaoIMC;
    }

    public void setClassificacaoIMC(String classificacaoIMC) {
        this.classificacaoIMC = classificacaoIMC;
    }

    public String getiR() {
        return iR;
    }

    public void setiR(String iR) {
        this.iR = iR;
    }

    public String getAliquota() {
        return aliquota;
    }

    public void setAliquota(String aliquota) {
        this.aliquota = aliquota;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getSobrenome() {
        return sobrenome;
    }

    public void setSobrenome(String sobrenome) {
        this.sobrenome = sobrenome;
    }

    public String getEndereco() {
        return endereco;
    }

    public void setEndereco(String endereco) {
        this.endereco = endereco;
    }

    public int getIdade() {
        return idade;
    }

    public void setIdade(int idade) {
        this.idade = idade;
    }

    public String getSalario() {
        return salario;
    }

    public void setSalario(String salario) {
        this.salario = salario;
    }
}
