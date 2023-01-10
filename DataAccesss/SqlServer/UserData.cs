using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common.Cache;

namespace DataAccesss
{
    public class UserData:ConnectionSQL
    {

        public void editarPerfil(int id, string UserName, string Password, string name,string lastName,string Email)
        {
            using (var connexion = GetConnection())
            {
                connexion.Open();
                using(var comman = new SqlCommand())
                {
                    comman.Connection = connexion;
                    comman.CommandText = "update Users set loginName=@UserName, " +
                        "Password=@pass, FirstName=@name, LastName=@lastName, " +
                        "Email=@email where UserId=@id";
                    comman.Parameters.AddWithValue("@UserName",UserName);
                    comman.Parameters.AddWithValue("@pass",Password);
                    comman.Parameters.AddWithValue("@name",name);
                    comman.Parameters.AddWithValue("@lastName",lastName);
                    comman.Parameters.AddWithValue("@email",Email);
                    comman.Parameters.AddWithValue("@id",id);
                    comman.CommandType = CommandType.Text;
                    comman.ExecuteNonQuery();
                }
            }
        }



        public bool login(string user, string pass)
        {
            using(var connection = GetConnection())
            {
                connection.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Users where LoginName=@user and Password=@pass ";
                    command.Parameters.AddWithValue("@user",user);
                    command.Parameters.AddWithValue("@pass", pass);
                    //command.Parameters.AddWithValue("@id",UserLoginCache.IdUsuario);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            UserLoginCache.IdUsuario = reader.GetInt32(0);
                            UserLoginCache.LoginName = reader.GetString(1);
                            UserLoginCache.Password = reader.GetString(2);
                            UserLoginCache.FirsName = reader.GetString(3);
                            UserLoginCache.LastName = reader.GetString(4);
                            UserLoginCache.Position = reader.GetString(5);
                            UserLoginCache.Email = reader.GetString(6);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public string recoverPassword(string UserRequesting)
        {
            using(var connection = GetConnection())
            {
                connection.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select  * from Users where LoginName=@user or Email=@email ";
                    command.Parameters.AddWithValue("@user", UserRequesting);
                    command.Parameters.AddWithValue("@email", UserRequesting);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        String UserName = reader.GetString(3)+", "+ reader.GetString(4);
                        string email = reader.GetString(6);
                        string password = reader.GetString(2);

                        var mailService = new MailService.SystemSupportMail();
                        mailService.sendMail(
                            subject:"SYSTEM: solicitud de Recuperracion de contrasena",
                            body:"HOLA, "+UserName+"\nYou reques to recovery your password.\n"+
                            "your current password is:"+password+"\nPorfavor  de cambiar su claven al ingresar al sistema.",
                            recipientMail:new List<string> { email});

                        return
                           "HOLA, " + UserName + "\nYou reques to recovery your password.\n" +
                             "Porfavor rebice su correo:" + email + "\nPorfavor  de cambiar su claven al ingresar al sistema.";

                    }
                    else
                    {
                        return "Sorry, you do not have an account with that mail or username";
                    }
                }
            }
        }
    }
}
