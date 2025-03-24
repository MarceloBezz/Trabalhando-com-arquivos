using System;
using System.IO;
using System.Text;
using ByteBankIO;

namespace Trabalhando_com_arquivos
{
    partial class Program
    {
        static void Main(string[] args)
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
                    Console.WriteLine(linha);
                }
            }
            Console.ReadKey();
        }
    }
}
