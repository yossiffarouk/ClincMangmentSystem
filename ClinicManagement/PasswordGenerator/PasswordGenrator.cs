namespace ClinicManagement.Generator
{
    class PasswordGenrator
    {
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
    }
}
