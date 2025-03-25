using System;
using System.IO;
using System.Text;
using ByteBankIO;

namespace Trabalhando_com_arquivos
{
    partial class Program
    {
        static void LerArquivo()
        {
            var enderecoDoArquivo = "contas.txt";
            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var leitor = new StreamReader(fluxoDoArquivo);

                // var linha = leitor.ReadLine();
                // Console.WriteLine(linha);

                // var texto = leitor.ReadToEnd();
                // Console.WriteLine(texto);

                // var numero = leitor.Read();
                // Console.WriteLine(numero);

                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    var contaCorrente = ConverterStringParaContaCorrente(linha);

                    var msg = $"Conta número {contaCorrente.Numero}, ag {contaCorrente.Agencia}, Saldo R${contaCorrente.Saldo}, Titular {contaCorrente.Titular.Nome}";
                    Console.WriteLine(msg);
                }
            }
            Console.ReadKey();
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            //375 4644 2483.13 Jonatan
            var campos = linha.Split(",");
            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace(".",","));
            var titular = new Cliente
            {
                Nome = campos[3]
            };

            var resultado = new ContaCorrente(agencia, numero);
            resultado.Depositar(saldo);
            resultado.Titular = titular;

            return resultado;
        }
    }
}
