using ClinicManagement.Data;
using ClinicManagement.Services;
using System.Text;

namespace ClinicManagement.PasswordGenerator
{
    class PasswordGenrator
    {
        private static  ClinicDbContext service = null!;

        public PasswordGenrator(IDbContextService _service)
        {
            service = _service.UseMe();
        }

        public static string GenerateRandomPassword(int length)
        {
            const string ValidScope = "abcdefghijklmnopqstuvwxyzABCDEFGHIJKLMNOPQSTUVWXWZ0123456789!~@#$%^&*()_-";
            var result = string.Empty;
            Random rnd = new Random();

            while (length-- > 0)//87654321
            {
                result += ValidScope[rnd.Next(ValidScope.Length)];
            }

            return result;
        }

        public static string HashingPassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        public static string DecodingPassword(string password)
        {
            var bytes = Convert.FromBase64String(password);
            return Encoding.UTF8.GetString(bytes);
        }

    }
}
