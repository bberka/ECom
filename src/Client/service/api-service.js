import * as Config from "./config";
import * as Lang from "./lang";
import * as Auth from "./auth";


function ConvertFetchToResult(status, body) {
  var hasStatusInBody = body.hasOwnProperty("status");
   if (!hasStatusInBody) 
    //  console.log("no status in body");
     return body;

  //  console.log(body);

  status = body.status;
  let message = Lang.read(body.errorCode);
  if (body.translatedMessage != null && body.translatedMessage != undefined) {
    message = body.translatedMessage;
  }
  return {
    status: body.status,
    message: message,
    data: body.data,
    severity: levelToSeverityText(body.level),
    severityText : severityFullText(body.level)
  };
}

function levelToSeverityText(level) {
  switch (level) {
    case 0:
      return "success";
    case 1:
      return "info";
    case 2:
      return "warn";
    case 3:
      return "error";
    default:
      return "info";
  }
}

function severityFullText(severity) {
  switch (severity) {
    case 0:
      return "Success";
    case 1:
      return "Info";
    case 2:
      return "Warning";
    case 3:
      return "Error";
    default:
      return "Info";
  }
}

export async function sendRequestAsync(
  method,
  url,
  data = null,
  queryDictionary = null,
  isAuthenticate = true
) {
  url = Config.BaseApiUrl + url;
  let headers = {
    "Content-Type": "application/json",
    Accept: "application/json",
  };
  if (isAuthenticate) {
    headers["Authorization"] = "Bearer " + Auth.getToken();
  }
  if (queryDictionary) {
    url = buildQueryString(url, queryDictionary);
  }
  try {
    if (method == "GET" || method == "DELETE") {
      let resp = await fetch(url, {
        method: method,
        headers: headers,
      });
      let body = await resp.json();
      let status = resp.status >= 200 && resp.status < 300;
      return ConvertFetchToResult(status, body);
    } else {
      let resp = await fetch(url, {
        method: method,
        body: JSON.stringify(data),
        headers: headers,
      });
      let body = await resp.json();
      let status = resp.status >= 200 && resp.status < 300;
      return ConvertFetchToResult(status, body);
    }
  } catch (e) {
    console.log(e);
    return {
      status: false,
      body: null,
    };
  }
}

function buildQueryString(url, dictionary) {
  let queryString = url + "?";
  for (let key in dictionary) {
    queryString += key + "=" + dictionary[key] + "&";
  }
  queryString = queryString.substring(0, queryString.length - 1);

  return queryString;
}
