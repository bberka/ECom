using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface IValidationDbService
    {
        bool AllowTester(bool isTesterAccount);
        bool HasLowerCase(string password);
        bool HasNumber(string password);
        bool NotHasSpace(string password);
        bool NotHasSpecialChar(string password);
        bool HasUpperCase(string password);
        bool NotUsedEmail_Admin(string email);
        bool NotUsedEmail_User(string email);
        bool IsRelease();

    }
}
