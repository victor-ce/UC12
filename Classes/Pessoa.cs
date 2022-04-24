using System.IO;
using CadastroPessoaFS1.Interfaces;

namespace CadastroPessoaFS1.Classes
{
    public abstract class Pessoa : IPessoa
    {
        public string nome { get; set; }

        public Endereco endereco { get; set; }

        public float rendimento { get; set; }

        public abstract float PagarImposto(float rendimento); // como é um metodo abstrato ele ñ tem corpo, seus comandos estão declarados na classe filha.

        public void VerificarPastaArquivo(string caminho){
            string pasta = caminho.Split("/")[0];
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(caminho))
            {
                using (File.Create(caminho)){ }

            }
        }
    }
}