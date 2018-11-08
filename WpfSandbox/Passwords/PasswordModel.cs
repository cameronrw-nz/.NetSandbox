using System.Security;

namespace WpfSandbox
{
    public class PasswordModel
    {
        private string _password;

        public string Text => "This is a password row";

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }
    }
}