package com.br.varsolutions;

public class PessoaRequest {  //entrada
    public String nome;
    public String sobrenome;
    public int idade;
    public String time;
    public String endereco;
    public double peso;
    public double altura;
    public double salario;



    public String getNome(){return nome;}
    public void setNome(String nome){this.nome = nome;}

    public String getSobrenome(){return sobrenome;}
    public void setSobrenome(String sobrenome){this.sobrenome = sobrenome;}

    public String getEndereco(){return endereco; }
    public void setEndereco(String endereco){this.endereco = endereco;}

    public int getIdade(){return idade;}
    public void setIdade(int idade){this.idade = idade;}

    public double getPeso(){return peso;}
    public void setPeso(double peso){this.peso = peso;}

    public double getAltura(){return altura;}
    public void setAltura(double altura){this.altura = altura;}

    public double getSalario(){return salario;}

    public void setSalario(double salario){this.salario = salario;}

    public String getTime(){return time;}

    public void setTime(String time){this.time = time;}
}
