import * as Store from "./store";

const TOKEN_KEY = "JWT_TOKEN";
const EXPIRE_UNIX = "EXPIRE_UNIX";
const ADMIN_CACHE = "ADMIN_CACHE";

export function isTokenExists() {
  let token = Store.getCookie(TOKEN_KEY);
  if (token == null || token == undefined || token == "") {
    return false;
  }
  return true;
}

export function clearAuth(){
  Store.deleteCookie(TOKEN_KEY);
  Store.deleteCookie(EXPIRE_UNIX);
  Store.deleteCookie(ADMIN_CACHE);
}

export function setToken(token){
  Store.setCookie(TOKEN_KEY, token.token);
  Store.setCookie(EXPIRE_UNIX, token.expireUnix);
}

export function getToken(){
  return Store.getCookie(TOKEN_KEY);
}


export function getExpireUnix(){
  return Store.getCookie(EXPIRE_UNIX);
}

export function getAdminCache(){
  return Store.getCookie(ADMIN_CACHE);
}

export function setAdminCache(admin){
  Store.setCookie(ADMIN_CACHE, admin);
}

export function setAuthInfo(response){
  setToken(response.token);
  setAdminCache(response.admin);
}