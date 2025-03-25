using System;
using System.IO;
using System.Text;
using ByteBankIO;

namespace Trabalhando_com_arquivos
{
    partial class Program
    {
        static void LidandoComFileStream()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var numeroDeBytesLidos = -1;

                var buffer = new byte[1024]; //1KB

                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, numeroDeBytesLidos);
                }

                fluxoDoArquivo.Close();
            }
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = new UTF8Encoding();

            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.WriteLine(texto);
        }
    }
}
