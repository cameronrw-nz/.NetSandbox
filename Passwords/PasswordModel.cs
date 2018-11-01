using System.Security;

namespace WpfSandbox
{
    public class PasswordModel
    {
        private SecureString _password;

        public string Text => "This is a password row";

        public SecureString Password
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