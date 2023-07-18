import ApiService from './ApiService';
import { UrlService } from './UrlService';
import { buildQueryString } from './Utils';
import { sendRequest } from './ApiService';

export  const ManagerService = {
  async getAdminList(){
    let path = UrlService.UrlGetAdminList;
    let url = buildQueryString(path.url, {});
    let method = path.method;
    let authRequired = true;
    return await sendRequest(method, url, null, authRequired);
  },
  async getAdmin(id){
    var path = UrlService.UrlGetAdmin;
    var url = buildQueryString(path.url, {id: id});
    var method = path.method;
    var authRequired = true;
    return await sendRequest(method, url, null, authRequired);
  },
  async getRoles(){
    var path = UrlService.UrlGetRoles;
    var url = buildQueryString(path.url, {});
    var method = path.method;
    var authRequired = true;
    return await sendRequest(method, url, null, authRequired);
  },
  async deleteAdmin(id){
    var path = UrlService.UrlDeleteAdmin;
    var url = buildQueryString(path.url, {id : id});
    var method = path.method;
    var authRequired = true;
    return await sendRequest(method, url, null, authRequired);
  }

}

