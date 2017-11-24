using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SysLog
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;

            do
            {
                System.Console.WriteLine("\nMENU\n\n1 - Cadastrar\n2 - Logar\n3 - Deslogar\n9 - Sair\n");
                opcao = Convert.ToInt16(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        System.Console.Write("\nCadastre alguma senha: ");
                        string Cadsenha = Console.ReadLine();
                        string CriptSenha = encriptSenha(Cadsenha);
                        
                        StreamWriter arquivo0 = new StreamWriter("CadUsuario.txt",true);
                        arquivo0.WriteLine(" ;" + CriptSenha);
                        arquivo0.Close();
                        break;

                    case 2:
                        System.Console.Write("\nSenha: ");
                        string senha = Console.ReadLine();
                        string Senha = encriptSenha(senha);
                        Login login = new Login(Senha);

                        StreamReader arquivo = new StreamReader("CadUsuario.txt", Encoding.Default);
                        string linha = "";

                        while ((linha = arquivo.ReadLine()) != null)
                        {
                            string[] dados = linha.Split(';');
                            if (dados[1] == Senha)
                            {
                                System.Console.WriteLine("\nLogado.");
                                login.Log += new Login.Evento(metodo);
                                login.Logar();
                            }
                            else
                                System.Console.WriteLine("\nSenha Errada.");
                        }
                        arquivo.Close();
                        break;

                    case 3:
                        break;

                    case 9:
                        break;

                    default:
                        break;
                }

            } while (opcao != 9);

        }

        static string encriptSenha(string senha)
        {
            byte[] senhaOriginal;
            byte[] senhaModificada;
            SHA512 sha;

            senhaOriginal = Encoding.Default.GetBytes(senha);

            sha = SHA512.Create();

            senhaModificada = sha.ComputeHash(senhaOriginal);
            return Convert.ToBase64String(senhaModificada);
        }

        static void metodo()
        {
            System.Console.WriteLine("Evento...");
        }
    }
}
