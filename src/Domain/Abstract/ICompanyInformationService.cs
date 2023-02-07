﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface ICompanyInformationService
    {
        ResultData<CompanyInformation> GetCompanyInformation();
        CompanyInformation? GetFromCache();
        Result UpdateOrAddCompanyInformation(CompanyInformation info);

    }
}
