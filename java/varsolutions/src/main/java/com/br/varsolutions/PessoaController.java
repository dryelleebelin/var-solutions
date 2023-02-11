package com.br.varsolutions;
//configurações pré-definidas
import io.swagger.v3.oas.annotations.parameters.RequestBody;
import lombok.extern.slf4j.Slf4j;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.time.LocalDate;
import java.util.Objects;

@RestController
@RequestMapping("/pessoa")
@CrossOrigin(origins = "*")
@Slf4j  //log
public class PessoaController {
    //endpoint
    @GetMapping
    public ResponseEntity<Object> get(){
        PessoaRequest pessoaRequest1 = new PessoaRequest();
        pessoaRequest1.setNome("Dryelle");
        pessoaRequest1.setSobrenome("Ebelin");
        pessoaRequest1.setEndereco("São Paulo, Brasil");
        pessoaRequest1.setIdade(18);
        pessoaRequest1.setPeso(53);
        pessoaRequest1.setAltura(1.66f);

        return ResponseEntity.ok(pessoaRequest1);
    }
    @GetMapping("/resumo")
    public ResponseEntity<Object> getPessoa(@RequestBody PessoaRequest pessoaRequest, @RequestParam(value = "valida_mundial") Boolean desejaValidarMundial){  //+atributo adicional
        InformacoesIMC imc = new InformacoesIMC();
        int anoNascimento = 0;
        String impostoRenda = null;
        String validaMundial = null;

        if(!pessoaRequest.getNome().isEmpty()) {

            log.info("Iniciando o processo de resumo da pessoa: ", pessoaRequest);

            if(Objects.nonNull(pessoaRequest.getPeso()) && Objects.nonNull(pessoaRequest.getAltura())) {
                log.info("Iniciando o calculo do IMC");
                imc = calculaIMC(pessoaRequest.getPeso(), pessoaRequest.getAltura());
            }

            if(Objects.nonNull(pessoaRequest.getIdade())){
                log.info("Iniciando o calculo do ano de nascimento");
                anoNascimento = calculaAnoNascimento(pessoaRequest.getIdade());
            }

            if(Objects.nonNull(pessoaRequest.getSalario())){
                log.info("Iniciando do calculo do imposto de reda");
                impostoRenda = calculaFaixaImpostoRenda(pessoaRequest.getSalario());
            }

            if(Boolean.TRUE.equals(desejaValidarMundial)){  //+atributo adicional
                if(Objects.nonNull(pessoaRequest.getTime())){
                    log.info("Validando se o time de coração tem Mundial");
                    validaMundial = calculaMundial(pessoaRequest.getTime());
                }
            }

            log.info("Montando objeto de retorno para o front-end.");
            PessoaResponse resumo = montarRespostaFrontEnd(pessoaRequest, imc, anoNascimento, impostoRenda, validaMundial);

            return ResponseEntity.ok(resumo);
        }
        return ResponseEntity.noContent().build();
    }

    private PessoaResponse montarRespostaFrontEnd(PessoaRequest pessoa ,InformacoesIMC imc, int anoNascimento, String impostoRenda, String validaMundial) {
        PessoaResponse response = new PessoaResponse();

        response.setNome(pessoa.getNome());
        response.setSobrenome(pessoa.getSobrenome());
        response.setIdade(pessoa.getIdade());
        response.setAnoNascimento(anoNascimento);
        response.setMundialClubes(validaMundial);
        response.setEndereco(pessoa.getEndereco());
        response.setImc(imc.getImc());
        response.setClassificacaoIMC(imc.getClassificacao());
        response.setSalario(impostoRenda);
        return response;
    }

    private String calculaMundial(String time) {
        if(time.equalsIgnoreCase("Corinthians")) {
            return "Parabéns, o seu time possui 2 mundiais de clubes conforme a FIFA";
        } else if (time.equalsIgnoreCase("São Paulo")) {
            return "Parabéns, o seu time possui 3 mundiais de clubes conforme a FIFA";
        } else if (time.equalsIgnoreCase("Santos")) {
            return "Parabéns, o seu time possui 2 mundiais de clubes conforme a FIFA";
        } else if (time.equalsIgnoreCase("Grêmio")) {
            return "Parabéns, o seu time possui 1 mundial de clubes conforme a FIFA";
        } else if (time.equalsIgnoreCase("Flamengo")) {
            return "Parabéns, o seu time possui 1 mundial de clubes conforme a FIFA";
        } else if (time.equalsIgnoreCase("Internacional")) {
            return "Parabéns, o seu time possui 1 mundial de clubes conforme a FIFA";
        } else {
            return "Poxa, que pena. Continue torcendo para seu clube ganhar um mundial";
        }
    }

    //regra: salário bruto * alíquota - dedução
    private String calculaFaixaImpostoRenda(double salario) {
        log.info("Iniciando o calculo do Imposto de renda: " + salario);
        String novoSalarioCalculado;

        if (salario <= 1903.98) {
            return "isento";
        } else if (salario >= 1903.99 && salario <= 2826.65) {
            double calculoIRF = 142.80 - ((salario * 0.075) / 100);
            double novoSalario = salario - calculoIRF;
            novoSalarioCalculado = String.valueOf(novoSalario);
            return novoSalarioCalculado;
        } else if (salario >= 2826.66 && salario <= 3751.05) {
            double calculoIRF = 354.80 - ((salario * 0.15) / 100);
            double novoSalario = salario - calculoIRF;
            novoSalarioCalculado = String.valueOf(novoSalario);
            return novoSalarioCalculado;
        } else if (salario >= 3751.06 && salario <= 4664.68) {
            double calculoIRF = 636.13 - ((salario * 0.225) / 100);
            double novoSalario = salario - calculoIRF;
            novoSalarioCalculado = String.valueOf(novoSalario);
            return novoSalarioCalculado;
        } else {
            double calculoIRF = 869.36 - ((salario * 275) / 100);
            double novoSalario = salario - calculoIRF;
            novoSalarioCalculado = String.valueOf(novoSalario);
            return novoSalarioCalculado;
        }
    }

    private int calculaAnoNascimento(int idade) {
        LocalDate dataLocal = LocalDate.now();
        int anoAtual = dataLocal.getYear();
        return (anoAtual - idade) - 1;
    }

    private InformacoesIMC calculaIMC(double peso, double altura) {  //parâmetros = atributos que o método espera receber para ser executado
        double imc = Math.round(peso / (altura * altura));

        InformacoesIMC imcCalculado = new InformacoesIMC(); //classe filha

        if (imc <= 18.5) {
            imcCalculado.setImc(String.valueOf(imc));
            imcCalculado.setClassificacao("Você está abaixo do peso ideal");
            return imcCalculado;
        } else if (imc >= 18.6 && imc <= 24.9) {
            imcCalculado.setImc(String.valueOf(imc));
            imcCalculado.setClassificacao("Você está com o peso normal, parabéns!");
            return imcCalculado;
        } else if (imc >= 25 && imc <= 29.9) {
            imcCalculado.setImc(String.valueOf(imc));
            imcCalculado.setClassificacao("Você está com pré-obesidade.");
            return imcCalculado;
        } else if (imc >= 30 && imc <= 34.9) {
            imcCalculado.setImc(String.valueOf(imc));
            imcCalculado.setClassificacao("Você está com obesidade grau I");
            return imcCalculado;
        } else if (imc >= 35 && imc <= 39.9) {
            imcCalculado.setImc(String.valueOf(imc));
            imcCalculado.setClassificacao("Você está com obesidade grau II (severa)");
            return imcCalculado;
        } else {
            imcCalculado.setImc(String.valueOf(imc));
            imcCalculado.setClassificacao("Você está com obesidade grau III (mórbida)");
            return imcCalculado;
        }
    }

    //implementação de métodos de exemplo
    @DeleteMapping
    public void retornoDelete() {

    }

    @PutMapping
    public void retornoPut() {

    }

    @PostMapping
    public void  retornoPost() {

    }
}