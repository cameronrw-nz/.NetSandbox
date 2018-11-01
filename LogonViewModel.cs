using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfSandbox
{
    public class LogonViewModel : ViewModelBase
    {
        public LogonViewModel()
        {
            Passwords = new List<PasswordModel>() { new PasswordModel() };
        }

        public IList<PasswordModel> Passwords { get; set; }
    }
}
