using System.IO;
using System.Text;

namespace Trabalhando_com_arquivos
{
    partial class Program
    {
        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";
            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaString = "456,7895,4785.40,Gustavo Santos";

                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(contaString);

                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using(var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using(var escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.Write("456,7895,4785.40,Arruda");
            }
        }
    }
}