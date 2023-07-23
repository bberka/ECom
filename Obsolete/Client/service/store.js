import React from 'react';
import Cookies from 'js-cookie';



export function getCookie(key){
  return Cookies.get(key);
}

// export function setCookie(key, value, options){
//   cookies.set(key, value, options);
// }

export function removeCookie(key){
  Cookies.remove(key);
}

export function getCookieOptions(){
  return Cookies.options;
}

export function setCookie(key,value){
  Cookies.set(key,value);
}
