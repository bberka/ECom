
class CustomUrl {
  constructor(relativePath, method, paramsString = "") {
    this.relativePath = relativePath;
    this.method = method;
    this.params = paramsString;
    this.url = "https://localhost:7162/api/v0.1.0" + relativePath;
  }
  url;
  relativePath;
  method;
  params;

}




export class UrlService { 
  static UrlGetAdminList = new CustomUrl("/manager/getadmins", "GET"); 
  static UrlGetAdmin = new CustomUrl("/manager/getadmin", "GET", "id"); //query string
  static UrlLogin = new CustomUrl("/auth/login", "POST", "emailAddress,password,isHashed"); //body
  static UrlGetRoles = new CustomUrl("/role/list", "GET");
  static UrlDeleteAdmin = new CustomUrl("/manager/deleteadminaccount", "DELETE", "id"); //query string
  static UrlDisableAdmin = new CustomUrl("/manager/disableadminaccount", "PUT", "id"); //query string
  static UrlEnableAdmin = new CustomUrl("/manager/enableadminaccount", "PUT", "id"); //query string
  static UrlAddAdmin = new CustomUrl("/manager/addadminaccount", "POST", "emailAddress,password,roleId"); //body
}