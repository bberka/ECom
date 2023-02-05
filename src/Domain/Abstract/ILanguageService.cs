using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface ILanguageService
    {
        public List<Language> GetLanguages();
        public Language GetLanguage(int id);
        public Result EnableOrDisable(int id);


    }
}
