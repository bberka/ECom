import * as MessageService from "./MessageService";

function ConvertFetchToResult(status, body) {
  if (!status) {
    //console.log("fail htpp status");
    return {
      status: status,
      message: "An error occurred while processing your request.",
    };
  }
  var hasStatusInBody = body.hasOwnProperty("status");
  if (!hasStatusInBody) {
    //console.log("no status in body");
    return body;
  }
  status = body.status;
  let message = body.message.error;
  return {
    status: body.status,
    message: message,
    data: body.data,
    level: body.level,
  };
}

export async function sendRequest(
  method,
  url,
  data = null,
  isAuthenticate = true
) {
  try {
    let headers = {
      "Content-Type": "application/json",
      Accept: "application/json",
    };
    if (isAuthenticate) {
      headers["Authorization"] = "Bearer " + isAuthenticate.token;
    }
    //console.log("sendRequest", method, url, data, isAuthenticate);
    if (method == "GET" || method == "DELETE") {
      let resp = await fetch(url, {
        method: method,
        headers: headers,
      });
      let body = await resp.json();
      let status = resp.status >= 200 && resp.status < 300;
      return await ConvertFetchToResult(status, body);
    } else {
      let resp = await fetch(url, {
        method: method,
        body: data,
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
