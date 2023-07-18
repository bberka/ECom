import BaseApiService, { sendRequestAsync } from './api-service';

export const OptionService = {
  async getOption(){
    return await sendRequestAsync("GET", "/option/get");
  },
  async getSmtpOptions(){
    return await sendRequestAsync("GET", "/option/getsmtpoptions");
  },
  async getCategories(){
    return await sendRequestAsync("GET", "/option/getcategories");
  },
  async getCompanyInfo(){
    return await sendRequestAsync("GET", "/option/getcompanyinfo");
  },
  async getCurrencies(){
    return await sendRequestAsync("GET", "/option/getcurrencies");
  },
  async getLanguages(){
    return await sendRequestAsync("GET", "/option/getlanguages");
  },
  async getPaymentInfo(){
    return await sendRequestAsync("GET", "/option/getpaymentinfo");
  },
  async updateCargoOptions(data){
    return await sendRequestAsync("POST", "/option/updatecargooptions", data);
  },
  async updateCompanyInfo(data){
    return await sendRequestAsync("POST", "/option/updatecompanyinfo", data);
  },
  async updatePaymentInfo(data){
    return await sendRequestAsync("POST", "/option/updatepaymentinfo", data);
  },
  async updateSmtpOption(data){
    return await sendRequestAsync("POST", "/option/updatesmtpoptions", data);
  }
}


export  const ManagerService = {
  async getAdminList(){
    return await sendRequestAsync("GET", "/manager/getadmins");
  },
  async getAdmin(id){
    return await sendRequestAsync("GET", "/manager/getadmin", null, {id: id});
  },
  async getRoles(){
    return await sendRequestAsync("GET", "/role/list");
  },
  async deleteAdmin(id){
    return await sendRequestAsync("DELETE", "/manager/deleteadminaccount", null,{id : id});
  },
  async updateAdmin(data){
    return await sendRequestAsync("POST", "/manager/updateadminaccount", data);
  },
  async createAdmin(data){
    return await sendRequestAsync("POST", "/manager/createadminaccount", data);
  },
  async recoverAdmin(id){
    return await sendRequestAsync("POST", "/manager/recoveradminaccount", null, {id : id});
  }
}

export  const ImageService = {
  async getImageBase64(id){
    return await sendRequestAsync("GET", "/image/getbase64image", null, {id: id});
  },
  async getImage(id){
    return await sendRequestAsync("GET", "/image/getimage", null, {id: id});
  },
  async uploadImage(data){
    return await sendRequestAsync("POST", "/image/uploadimage", data);
  }
}

export  const AuthService = {
  async login(data){
    return await sendRequestAsync("POST", "/auth/login",data);
  }
}


export const AnnouncementService = {
  async getAnnouncementList(){
    return await sendRequestAsync("GET", "/announcement/list");
  },
  async getAnnouncement(id){
    return await sendRequestAsync("GET", "/announcement/get", null, {id: id});
  },
  async deleteAnnouncement(id){
    return await sendRequestAsync("DELETE", "/announcement/delete", null,{id : id});
  },
  async updateAnnouncement(data){
    return await sendRequestAsync("POST", "/announcement/update", data);
  },
  async createAnnouncement(data){
    return await sendRequestAsync("POST", "/announcement/create", data);
  }
}

export const AccountService = {
  async getAccountData(){
    return await sendRequestAsync("GET", "/account/getaccountdata");
  },
  // async updateAccountData(data){
  //   return await sendRequestAsync("POST", "/account/updateaccountdata", data);
  // }
  async changePassword(data){
    return await sendRequestAsync("POST", "/account/changepassword", data);
  }
}



