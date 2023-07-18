export function buildQueryString(url, dictionary){
  let queryString = url + "?";
  for(let key in dictionary){
    queryString += key + "=" + dictionary[key] + "&";
  }
  queryString = queryString.substring(0, queryString.length - 1);
  
  return queryString;
}