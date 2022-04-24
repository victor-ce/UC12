using System;
using CadastroPessoaFS1.Interfaces;

namespace CadastroPessoaFS1.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        //DECLARAÇÃO DOS ATRIBUTOS PRESENTES NA CLASSE
        public string cpf { get; set; }
        public string dataNascimento { get; set; }
        

        //DECLARAÇÃO DOS METODOS PRESENTES NA CLASSE 
        public bool ValidarDataNascimento(string dataNasc) // metodo para verificar se a pessoa tem mais que 18 anos
        {
            DateTime dataConvertida;
            if (DateTime.TryParse(dataNasc, out dataConvertida))
            {
                Console.WriteLine($"{dataConvertida}");
                DateTime dataAtual = DateTime.Today;
                double anos = (dataAtual - dataConvertida).TotalDays/365;
                Console.WriteLine($"{anos}");
                return anos > 18;
            }
            return false;
        }

        public bool ValidarDataNascimento(DateTime dataNasc) // metodo para verificar se a pessoa tem mais que 18 anos
        {
            DateTime dataAtual = DateTime.Today;
            double anos = (dataAtual - dataNasc).TotalDays/365;
            Console.WriteLine($"{anos}");
            return anos > 18;
        }

        public override float PagarImposto(float rendimento)
        {
            if(rendimento <= 1500){
                return 0;
            }
            else if (rendimento > 1500.00 && rendimento <= 3500)
            {
                return rendimento*0.02f;
            }
            else if(rendimento > 3500 && rendimento < 6000)
            {
                return rendimento*0.035f ;
            }
            else{
                return rendimento*0.05f;
            }

        }
    }
}

//override: diz que o metodo esta sendo sobreescrito, ou seja, ele possui diferentes estruturas em cada classe que é usado. é necessário colocar algum conteúdo dentro
// da sua estrutura ( throw new NotImplementedException(); ) para que o programa entenda que esse valor esta sendo retornado.