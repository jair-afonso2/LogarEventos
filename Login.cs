using System.IO;

namespace SysLog
{
    public class Login
    {
        public string senha { get; set; }

        public Login(string Senha)

        {
            this.senha = Senha;
        }

        public void Logar()
        {
            StreamWriter arquivo = new StreamWriter("LogSistema.txt",true);
            arquivo.WriteLine("Logou");
            arquivo.Close();
            this.Log();
        }

        public delegate void Evento();
        public event Evento Log;
    }
}