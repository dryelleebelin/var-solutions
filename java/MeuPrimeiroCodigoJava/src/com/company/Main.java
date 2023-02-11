package com.company; //caminho do arquivo

import java.sql.SQLOutput;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
public class Main {  //classe
    public static void main(String[] args)  //método(ação)
    {
        System.out.println("Olá Mundo!! ");   //comando do sistema //saída do sistema //imprimir saída do sistema
        System.out.println("ESTE É O MEU PRIMEIRO CÓDIGO EM JAVA!!!");

        /*

        String olaMundo = "Olá mundo, esta mensagem está dentro da variável.";
        System.out.println(olaMundo);

        String nome = "Dryelle";
        String sobrenome = "Ebelin";
        System.out.println(nome);
        System.out.println(sobrenome);

        System.out.println(nome + " " + sobrenome);
        System.out.println(18);
        System.out.println(2022 - 2004);
        System.out.println(3 * 5);

        int x = 5;
        int y = 7;
        System.out.println(x + y);

        int a = 5, b = 6, c = 50;
        System.out.println(a + b + c);

        int f, e, d;
        f = e = d = 50;
        System.out.println(f + e + d);




        String retornoMetodo = inserirNome();
        System.out.println(retornoMetodo);
        int idade = calcularIdadePorAno();
        double imc = calcularIMC();

         */

        List<String> retornoResumo = resumoPessoa();
        System.out.println(retornoResumo);
    }

    public static String inserirNome()  //tipo de acesso: (public ou private) (tipo de retorno) (nome do método) (parâmetros)
    {
        Scanner ler = new Scanner(System.in);  //variável de leitura = interação com o usuário

        System.out.printf("Digite seu nome: ");
        String nome = ler.next();
        System.out.printf("Digite seu sobrenome: ");
        String sobrenome = ler.next();

        String nomeCompleto = nome + " " + sobrenome;
        return nomeCompleto;
    }

    public static int calcularIdadePorAno()
    {
        Scanner ler = new Scanner(System.in);

        System.out.printf("Digite seu ano de nascimento: ");
        int dataNascimento = ler.nextInt();
        int calculoNascimento = 2023 - dataNascimento;

        String classificacao = " ";
        if(calculoNascimento < 18)
        {
            classificacao = "menor de idade.";
        }
        else
        {
            classificacao = "maior de idade.";
        }

        System.out.println("Você tem " + calculoNascimento + " anos e é " + classificacao);

        return calculoNascimento;
    }

    public static double calcularIMC()
    {
        Scanner ler = new Scanner(System.in);

        System.out.printf("Digite sua altura: ");
        double altura = ler.nextDouble();
        System.out.printf("Digite seu peso: ");
        double peso = ler.nextDouble();

        double calculoIMC = peso / (altura * altura);
        System.out.println("Seu imc é " + calculoIMC);

        if(calculoIMC < 18.5) {
            System.out.println("Você está abaixo do peso ideal!");
        }
        else if(calculoIMC >= 18.6 && calculoIMC <= 24.9)
        {
            System.out.println("Peso normal");
        }
        else if(calculoIMC >= 25 && calculoIMC <= 29.9)
        {
            System.out.println("Pré-obesidade");
        }
        else if(calculoIMC >= 30 && calculoIMC <= 34.9)
        {
            System.out.println("Obesidade grau I");
        }
        else if(calculoIMC >= 35 && calculoIMC <= 39.9)
        {
            System.out.println("Obesidade grau II");
        }
        else
        {
            System.out.println("Obesidade grau III");
        }

        return calculoIMC;
    }

    public static List<String> resumoPessoa(){
        Scanner ler = new Scanner(System.in);

        List<String> nomesResumo = new ArrayList<>();

        for(int i = 1; i < 4; i ++){
            System.out.printf("Digite seu nome: ");
            String nome = ler.next();
            System.out.printf("Digite seu sobrenome: ");
            String sobrenome = ler.next();
            String nomeCompleto = nome + " " + sobrenome;

            System.out.printf("Digite sua idade: ");
            int idade = ler.nextInt();
            String tipoDePessoa = "";
            if(idade <= 17){
                tipoDePessoa = "menor de idade";
            } else{
                tipoDePessoa = "maior de idade";
            }

            String resumo = "O nome completo é " + nomeCompleto + ", você tem " + idade + " anos e é " + tipoDePessoa + ".";
            nomesResumo.add(resumo);
        }
        return nomesResumo;
    }
}
