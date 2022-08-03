using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace form
{
    internal class DadosBLL
    {
        public static void validaDados(Dados dados, char op)
        {
            //VALIDAÇÃO DE DADOS OBRIGATÓRIOS
            Erro.setErro(false);
            if (dados.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }
            if (dados.getDado1().Equals(""))
            {
                Erro.setMsg("O Dado1 é de preenchimento obrigatório!");
                return;
            }
            if (dados.getDado2().Equals(""))
            {
                Erro.setMsg("O Dado2 é de preenchimento obrigatório!");
                return;
            }
            if (dados.getDado3().Equals(""))
            {
                Erro.setMsg("A Dado3 é de preenchimento obrigatório!");
                return;
            }
            if (dados.getDado4().Equals(""))
            {
                Erro.setMsg("O Dado4 é de preenchimento obrigatório!");
                return;
            }

            //VALIDAÇÃO DE DADOS NUMÉRICOS E POSITIVOS (MAIOR QUE ZERO)
            try
            {
                int.Parse(dados.getDado3());
            }
            catch (Exception)
            {
                Erro.setMsg("O valor do Dado3 deve ser numérico!");
                return;
            }

            if (int.Parse(dados.getDado3()) <= 0)
            {
                Erro.setMsg("O valor do Dado3 deve ser numérico e positivo!");
                return;
            }

            //VALIDAÇÃO DE DADOS NUMÉRICOS E POSITIVOS (MAIOR QUE ZERO)
            try
            {
                int.Parse(dados.getDado4());
            }
            catch (Exception)
            {
                Erro.setMsg("O valor do Dado4 deve ser numérico!");
                return;
            }
            if (float.Parse(dados.getDado4()) <= 0)
            {
                Erro.setMsg("O valor do Dado4 deve ser numérico e positivo!");
                return;
            }
        }
    }
}
