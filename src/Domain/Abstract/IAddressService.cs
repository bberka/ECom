using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface IAddressService
    {
        public List<Address> GetUserAddresses(int userId);
        public Result UpdateAddress(int userId, Address address);
        public Result DeleteAddress(int userId, int id);
        public Result AddAddress(int userId, Address address);
        public ResultData<Address> GetAddress(int userId,int addressId);
        public ResultData<Address> GetAddress(int addressId);

    }
}
