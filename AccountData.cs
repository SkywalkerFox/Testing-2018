namespace Testing_2018
{
    public class AccountData
    {
        private string login;
        private string password;

        public AccountData(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public string GetLogin()
        {
            return this.login;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public void SetLogin(string login)
        {
            this.login = login;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }
    }
}