using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using CadastroPessoaFS1.Classes;
using System.IO;

// mensagem de boas vindas;
Console.WriteLine(@$"
=========================================================================
|                   Bem vindo ao sistema de cadastro de                 |
|                       pessoas físicas e Juridícas                     |
=========================================================================
");
BarraCarregamento("Carregando", 300);

// criação da lista de pessoas físicas;
List<PessoaFisica> listaPf = new List<PessoaFisica>();

//criação da lista de pessoas jurídicas;
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

PessoaJuridica metodoPj = new PessoaJuridica();


string opcao;

do
{

    Console.Clear();
    Console.WriteLine(@$"
=========================================================================
|                      Escolha uma das opções abaixo                    |
|-----------------------------------------------------------------------|
|                           1 - Pessoa Física                           |
|                           2 - Pessoa Juridíca                         |
|                                                                       |
|                           0 - Sair                                    |
=========================================================================
");
    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            //criamos o objeto para validar as informações
            PessoaFisica metodoPF = new PessoaFisica();

            string opcaoPf;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=========================================================================
|                      Escolha uma das opções abaixo                    |
|-----------------------------------------------------------------------|
|                           1 - Cadastrar Pessoa Física                 |
|                           2 - Mostrar Pessas Físicas                  |
|                                                                       |
|                           0 - Voltar Menu Anterior                    |
=========================================================================
");
                opcaoPf = Console.ReadLine();
                
                switch (opcaoPf)
                {
                    case "1":
                        //criamos uma pessoa (objeto)
                        PessoaFisica novaPf = new PessoaFisica();
                        //criamos um endereço (objeto)
                        Endereco novoEnd = new Endereco();

                        //passamos as informações da pessoa aos respectivos atributos;
                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar");
                        novaPf.nome = Console.ReadLine();//"Victor";

                        bool dataValida;
                        do
                        {
                        Console.WriteLine($"Digite a data de nascimento da pessoa física que deseja cadastrar");
                        string dataNasc = Console.ReadLine();
                        dataValida = metodoPF.ValidarDataNascimento(dataNasc);
                        if( dataValida)
                        {
                            novaPf.dataNascimento = dataNasc;// "01/01/2000";
                        } else 
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"data digitada inválida, por favor digite uma data válida");
                            Console.ResetColor();
                        }
                        } while (dataValida == false);
                        

                        Console.WriteLine($"Digite o CPF da pessoa física que deseja cadastrar");
                        novaPf.cpf = Console.ReadLine();// "33979783863";

                        Console.WriteLine($"Digite o Rendimento mensal da pessoa física que deseja cadastrar");
                        novaPf.rendimento = float.Parse(Console.ReadLine());// 15000.5f;

                        //passamos as informações do endereço aos respectivos atributos;
                        Console.WriteLine($"Digite o logradouro da pessoa física que deseja cadastrar");
                        novoEnd.logradouro = Console.ReadLine();//"Alameda Barão de Limeira";

                        Console.WriteLine($"Digite o numero do end da pessoa física que deseja cadastrar");
                        novoEnd.numero = int.Parse(Console.ReadLine());//539;

                        Console.WriteLine($"Digite o complemento do end da pessoa física que deseja cadastrar");
                        novoEnd.complemento = Console.ReadLine();//"SENAI Informática";

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToLower();
                        if(endCom == "S"){
                            novoEnd.endComercial = true;
                        } else
                        {
                            novoEnd.endComercial = false;
                        }

                        //Associamos o endereço a pessoa, ou seja, dizemos a quem pertence esse endereço;
                        novaPf.endereco = novoEnd;

                        // //Cria um arquivo txt;
                        // StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt");
                        // //escreve no arquivo;
                        // sw.Write(novaPf.nome);
                        // // fecha o arquivo;
                        // sw.Close();

                        using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))
                        {
                            sw.WriteLine($"{novaPf.nome}");
                            sw.WriteLine($"{novaPf.cpf}");
                            sw.WriteLine($"{novaPf.dataNascimento}");
                            sw.WriteLine($"{novaPf.endereco.logradouro}, +{novaPf.endereco.numero} ");
                            //sw.WriteLine($"{novaPf.endereco.numero}");
                        }

                        //Adicionamos a pessoa cadastrada a lista de pessoas cadastradas
                        //listaPf.Add(novaPf);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro realizado com sucesso");
                        Console.ResetColor();

                        break;

                    case "2":
                        Console.Clear();

                        //             if(listaPf.Count > 0)
                        //             {
                        //                 foreach (PessoaFisica cadaPessoa in listaPf)
                        //                 {
                        //                     Console.Clear();
                        //                     Console.WriteLine(@$"
                        //     Nome: {cadaPessoa.nome}
                        //     Endereço: {cadaPessoa.endereco.logradouro}, {cadaPessoa.endereco.numero}
                        //     Data de Nascimento: {cadaPessoa.dataNascimento}
                        //     Taxa de imposto a ser pago: {metodoPF.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                        // ");

                        //                     Console.WriteLine($"Aperte 'Enter' para continuar");
                        //                     Console.ReadLine();
                        //                 }
                        //             }
                        //             else
                        //             {
                        //                 Console.WriteLine($"A lista esta vazia ");
                        //                 Thread.Sleep(3000);
                        //                 Console.WriteLine($"Aperte 'Enter' para continuar");
                        //                 Console.ReadLine();

                        //             }

                        using ( StreamReader sr = new StreamReader ("Victor.txt") )
                            {
                                string linha;
                                while ((linha = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine($"{linha}");
                            }
                        }
                        Console.WriteLine($"Aperte 'Enter' para continuar");
                        Console.ReadLine();
                        break;

                    case "0":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida, por favor digite outra opção");
                        Console.WriteLine($"Aperte 'Enter' para continuar");
                        Console.ReadLine();
                        break;
                }
                
                
            } while (opcaoPf != "0");

            break;

        case "2":

            string opcaoPj;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=========================================================================
|                      Escolha uma das opções abaixo                    |
|-----------------------------------------------------------------------|
|                           1 - Cadastrar Pessoa Juridica               |
|                           2 - Mostrar Pessoas Juridicas               |
|                                                                       |
|                           0 - Voltar Menu Anterior                    |
=========================================================================
");
                opcaoPj = Console.ReadLine();

                switch (opcaoPj)
                {
                    case "1":
                        //criamos uma pessoa juridica;
                        PessoaJuridica novaPj = new PessoaJuridica();
                        //criamos um endereço (objeto)
                        Endereco novoEndPj = new Endereco();

                        //PessoaJuridica metodoPj = new PessoaJuridica();

                        //passamos as informações da pessoa aos respectivos atributos;
                        Console.WriteLine($"Digite o nome da pessoa juridica que deseja cadastrar");
                        novaPj.nome = Console.ReadLine();

                        bool cnpjValido;
                        do
                        {
                        Console.WriteLine($"Digite o CNPJ da pessoa Juridica que deseja cadastrar");
                        string cnpjPj = Console.ReadLine();
                        cnpjValido = novaPj.ValidarCNPJ(cnpjPj);
                        if( cnpjValido)
                        {
                            novaPj.cnpj = cnpjPj;// "01/01/2000";
                        } else 
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"CNPJ digitado inválido, por favor digite um CNPJ válido");
                            Console.ResetColor();
                        }
                        } while (cnpjValido == false);


                        //Console.WriteLine($"Digite o CNPJ da pessoa Juridica que deseja cadastrar");
                        //novaPj.cnpj = "00.000.000/0001-00";
                        
                        Console.WriteLine($"Digite a razão social da pessoa Juridica que deseja cadastrar");
                        novaPj.razaoSocial = Console.ReadLine(); //"Razão Social Pj";
                        
                        Console.WriteLine($"Digite o rendimento da pessoa Juridica que deseja cadastrar");
                        novaPj.rendimento = float.Parse(Console.ReadLine()); // 8000.5f;

                        Console.WriteLine($"Digite o endereço da pessoa Juridica");
                        novoEndPj.logradouro = Console.ReadLine();//"alamenda Barão de Limeira";
                        
                        Console.WriteLine($"Digite o numero do endereço da pessoa juridica");
                        novoEndPj.numero = int.Parse(Console.ReadLine());//539;
                        
                        Console.WriteLine($"Digite o complemento do endereço");
                        novoEndPj.complemento = Console.ReadLine();//"SENAI Informática";
                        
                        Console.WriteLine($"Esse endereço é comercial? S/N");
                        string endComPj = Console.ReadLine();
                        if (endComPj == "S")
                        {
                            novoEndPj.endComercial = true;
                        } else
                        {
                            novoEndPj.endComercial = false;
                        }

                        
                        novaPj.endereco = novoEndPj;

                        novaPj.Inserir(novaPj);
                        //listaPj.Add(novaPj);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro realizado com sucesso");
                        Console.ResetColor();

                        break;
                    case "2":
                        
                        Console.Clear();

                        //List<PessoaJuridica> listaPj = metodoPj.Ler();
                        listaPj = metodoPj.Ler();
                        if (listaPj.Count > 0)
                        {
                            foreach (PessoaJuridica cadaPJ in listaPj)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
                            Nome: {cadaPJ.nome}
                            Razão Social: {cadaPJ.razaoSocial}
                            CNPJ: {cadaPJ.cnpj}
                            CNPJ Válido: {(cadaPJ.ValidarCNPJ(cadaPJ.cnpj) ? "SIM" : "NÃO")}
                            Taxa de imposto a ser pago: {cadaPJ.PagarImposto(cadaPJ.rendimento).ToString("C")}
                            ");
                                Console.WriteLine($"Aperte 'Enter' para continuar");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"A lista esta vazia ");
                            Thread.Sleep(3000);
                        }

                        break;

                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida, por favor digite outra opção");
                        Console.WriteLine($"Aperte 'Enter' para continuar");
                        Console.ReadLine();
                        break;
                }
                
            } while (opcaoPj != "0");

            break;

        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar nosso sistema");
            BarraCarregamento("Finalizando", 300);
            break;

        default:
            Console.Clear();
            Console.WriteLine($"Opção inválida, por favor digite outra opção");
            Console.WriteLine($"Aperte 'Enter' para continuar");
            Console.ReadLine();
            break;
    }

} while (opcao != "0");

static void BarraCarregamento(string texto, int tempo)
{
    Console.BackgroundColor = ConsoleColor.DarkGreen;
    Console.ForegroundColor = ConsoleColor.Red;

    Console.Write($"{texto} ");

    for (var contador = 0; contador < 10; contador++)
    {
        Console.Write(". ");
        Thread.Sleep(tempo);
    }

    Console.ResetColor();

}


//criamos uma pessoa e um endereço separadamente (pois são classes distintas), passamos as informações
// de cada atributo para cada objeto e depois associamos o objeto enreco ao pessoa



//PessoaJuridica metodoPJ = new PessoaJuridica();


//Console.WriteLine($"{metodoPJ.ValidarCNPJ("00000000000100")}");