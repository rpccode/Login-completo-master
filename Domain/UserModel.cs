using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesss;
using Common.Cache;

namespace Domain
{
    public class UserModel
    {

        UserData userDao = new UserData();

        private int idUser;
        private string loginName;
        private string Password;
        private string firstName;
        private string lastName;
        private string position;
        private string Email;

        public UserModel(int idUser, string loginName, string password, string firstName, string lastName,string position, string email)
        {
            this.idUser = idUser;
            this.loginName = loginName;
            this.Password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.position = position;
            this.Email = email;
        }

        public UserModel()
        {

        }

        public bool LoginUser(string user, string pass)
        {
            return userDao.login(user,pass);
        }
        public string recoveryPassword(string userRequesting)
        {
            return userDao.recoverPassword(userRequesting);
        }
        public string edictPerfilUser()
        {
            
            try
            {
                userDao.editarPerfil(idUser, loginName, Password, firstName, lastName, Email);
                LoginUser(loginName, Password);

                return "Tu Perfil se a Actualizado Correctamente ";

            }
            catch (Exception ex)
            {
                return "Este Nombre de usuario Ya Existe EN la Base de Datos" + ex;
            }
        }
        public void privilegiosUser()
        {
            if(UserLoginCache.Position == Cargos.Administrador)
            {

            }
            if(UserLoginCache.Position == Cargos.Receptionist || UserLoginCache.Position == Cargos.Accounting)
            {

            }
        }

    }
}
