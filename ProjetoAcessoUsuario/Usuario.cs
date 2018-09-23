using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcessoUsuario
{
    public class Usuario
    {
        private int id;
        private string login;
        private string senha;
        private string tipo;

        public Usuario(int id, string login, string senha, string tipo)
        {
            this.id = id;
            this.login = login;
            this.senha = senha;
            this.tipo = tipo;
        }
        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
