
using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        readonly UserContext _userContext;
        public UserRL(UserContext context)
        {
            _userContext = context;
        }
        public bool Register(RegisterModel user)
        {
            try
            {
                User userEntity = new User();
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.Email = user.Email;
                var encrypt_pass = Decrypt_Password(user.Password);
                userEntity.Password = encrypt_pass;
                userEntity.CreatedAt = DateTime.Now;
                _userContext.Users.Add(userEntity);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        

        public ResponseModel ForgotPassword(ForgotPasswordModel model)
        {
            try
            {
                User user = _userContext.Users.FirstOrDefault(e => e.Email == model.Email);
                if (user != null)
                {
                    ResponseModel response = new ResponseModel();
                    response.Email = user.Email;
                    response.UserId = user.UserId;
                    response.FirstName = user.FirstName;
                    response.LastName = user.LastName;
                    return response;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

       

        public User Get(long id)
        {
            try
            {
                return _userContext.Users.FirstOrDefault(e => e.UserId == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ResponseModel Login(LoginModel loginModel)
        {
            var decryptpass = Decrypt_Password(loginModel.Password);
            try
            {
                User user = _userContext.Users.FirstOrDefault(e => e.Email == loginModel.Email && e.Password==decryptpass);
                ResponseModel responseModel = new ResponseModel()
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };
                return responseModel;
            }
            catch (Exception ex )
            {

                throw;
            }
          
            
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users.ToList();
        }

        public bool ResetPassword(ResetPasswordModel resetPasswordModel, long userId)
        {
            User user = _userContext.Users.FirstOrDefault(e => e.UserId==userId);

            try
            {
                
                user.Password = resetPasswordModel.newPassword;
                _userContext.Users.Update(user);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        private string Decrypt_Password(string encryptpassword)
        {
            string pswstr = string.Empty;
            System.Text.UTF8Encoding encode_psw = new System.Text.UTF8Encoding();
            System.Text.Decoder Decode = encode_psw.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpassword);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            pswstr = new String(decoded_char);
            return pswstr;
        }
    }
}
