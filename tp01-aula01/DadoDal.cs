using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace tp01_aula01
{
    internal class DadoDal
    {
        private static String strConexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\tp01-aula01\tp01-aula01\bin\Debug\Database.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataReader result;

        public static void conecta()
        {
            try
            {
                conn.Open();
            }
            catch(Exception)
            {
                Erro.setMsg("Problemas ao se conectar com o Banco de Dados");
            }
        }
        public static void desconecta()
        {
            conn.Close();
        }

        public static void inseriUmDado(Dado dado)
        {
            String aux = "insert into TabDados(codigo,dado1,dado2,dado3,dado4) values (@codigo,@dado1,@dado2,@dado3,@dado4)";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.Add("@codigo", OleDbType.VarChar).Value = dado.getCodigo();
            strSQL.Parameters.Add("@dado1", OleDbType.VarChar).Value = dado.getDado1();
            strSQL.Parameters.Add("@dado2", OleDbType.VarChar).Value = dado.getDado2();
            strSQL.Parameters.Add("@dado3", OleDbType.VarChar).Value = dado.getDado3();
            strSQL.Parameters.Add("@dado4", OleDbType.VarChar).Value = dado.getDado4();
            Erro.setErro(false);
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch(Exception)
            {
                Erro.setMsg("Chave Duplicada!");
            }
        }

        public static void excluiUmDado(Dado dado)
        {
            String aux = "delete from TabDados where codigo = @codigo";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.Add("@codigo", OleDbType.VarChar).Value = dado.getCodigo();
            strSQL.ExecuteNonQuery();
        }
        public static void atualizaUmDado(Dado dado)
        {
            String aux = "update TabDados set dado1=@dado1, dado2=@dado2, dado3=@dado3, dado4=@dado4 where codigo =@codigo";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.Add("@dado1", OleDbType.VarChar).Value = dado.getDado1();
            strSQL.Parameters.Add("@dado2", OleDbType.VarChar).Value = dado.getDado2();
            strSQL.Parameters.Add("@dado3", OleDbType.VarChar).Value = dado.getDado3();
            strSQL.Parameters.Add("@dado4", OleDbType.VarChar).Value = dado.getDado4();
            strSQL.Parameters.Add("@codigo", OleDbType.VarChar).Value = dado.getCodigo();
            strSQL.ExecuteNonQuery();
        }

        public static void consultaUmDado(Dado dado)
        {
            String aux = "select * from TabDados where codigo = @codigo";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.Add("@codigo", OleDbType.VarChar).Value = dado.getCodigo();
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                dado.setDado1(result.GetString(1));
                dado.setDado2(result.GetString(2));
                dado.setDado3(result.GetString(3));
                dado.setDado4(result.GetString(4));
            }
            else
                Erro.setMsg("Dado não cadastrado.");
        }
    }
}
