using System.Collections.Generic;
using Newtonsoft.Json;
using ZawajApp.api.Models;

namespace ZawajApp.api.Data
{
    public class TrialData
    {
        private readonly DataContext _context;
        public TrialData(DataContext context)
        {
            _context = context;

        }
        public void TrialUsers(){
            var userData=System.IO.File.ReadAllText("Data/UserTrialData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData) ;
            foreach (var user in users)
            {
                byte[] PasswordHash,PasswordSalt;
                CreatePasswordHash("password",out PasswordHash,out PasswordSalt);
                user.PasswordHash=PasswordHash;
                user.PasswordSalt=PasswordSalt;
                user.Username=user.Username.ToLower();
                _context.Add(user);
            }
            _context.SaveChanges();


        }
         private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }

        }
    }
}