using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Constants
{
    public enum AdminOperationType
    {
        Admin_Update,
        Admin_Delete,
        Admin_GetOrList,
        Admin_Add,

        Announcement_Update,
        Announcement_Delete,

        Category_Add,
        Category_Update,
        Category_Delete,

    

        CompanyInfo_AddOrUpdate,

        Image_Upload,

        Option_RefreshCache,
        Option_Get,
        Option_Update,

        CargoOption_Get,
        CargoOption_Update,
        CargoOption_Delete,

        PaymentOption_Get,
        PaymentOption_Update,
        PaymentOption_Delete,

        SmtpOption_Get,
        SmtpOption_Update,
        SmtpOption_Delete,


    }

}
