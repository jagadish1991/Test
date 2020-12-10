using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.BLL
{
    public class UserBLL
    {
        private readonly string _connectionString;

        public UserBLL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        /// <summary>
        /// DB Context
        /// </summary>
        APIUserProfilesContext db = new APIUserProfilesContext();
        /// <summary>
        /// Insert Registration
        /// </summary>
        /// <returns></returns>
        /// 
        public async Task<Apiuserdetail> InsRegistration(Apiuserdetail Values)
        {

            Values.Password = EncryptString(Values.Password);
            Values.Status = 1;
            Values.Ideleted = 0;
            Values.CreatedDate = DateTime.Now;
            await db.Apiuserdetails.AddAsync(Values);
            await db.SaveChangesAsync();

            return Values;
        }
        public async Task<int> CheckByUserName(string UserName)
        {
            var userdetails = await db.Apiuserdetails.FirstOrDefaultAsync(x => x.UserName == UserName && x.Status == 1 && x.Ideleted == 0);
            if (userdetails != null)
            {
                return 1;
            }

            return 0;
        }

        public string EncryptString(string input)
        {
            try
            {
                string key = "SG20200624ESGDNC";// TODO: should be private  
                byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public string DecryptString(string input)
        {
            string key = "SG20200624ESGDNC";// TODO: should be private  
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
