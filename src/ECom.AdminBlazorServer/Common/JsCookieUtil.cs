﻿using Microsoft.JSInterop;

namespace ECom.AdminBlazorServer.Common;

public interface IJsCookieUtil
{
  public Task SetValue(string key, string value, int? days = null);
  public Task<string> GetValue(string key, string defaultValue = "");
}

public class JsCookieUtil : IJsCookieUtil
{
  private readonly IJSRuntime JSRuntime;
  private string expires = "";

  public JsCookieUtil(IJSRuntime jsRuntime) {
    JSRuntime = jsRuntime;
    ExpireDays = 300;
  }

  public int ExpireDays {
    set => expires = DateToUTC(value);
  }

  public async Task SetValue(string key, string value, int? days = null) {
    var curExp = days != null ? days > 0 ? DateToUTC(days.Value) : "" : expires;
    await SetCookie($"{key}={value}; expires={curExp}; path=/");
  }

  public async Task<string> GetValue(string key, string defaultValue = "") {
    var cValue = await GetCookie();
    if (string.IsNullOrEmpty(cValue)) return defaultValue;

    var vals = cValue.Split(';');
    foreach (var val in vals)
      if (!string.IsNullOrEmpty(val) && val.IndexOf('=') > 0)
        if (val.Substring(0, val.IndexOf('=')).Trim().Equals(key, StringComparison.OrdinalIgnoreCase))
          return val.Substring(val.IndexOf('=') + 1);
    return defaultValue;
  }

  private async Task SetCookie(string value) {
    await JSRuntime.InvokeVoidAsync("eval", $"document.cookie = \"{value}\"");
  }

  private async Task<string> GetCookie() {
    return await JSRuntime.InvokeAsync<string>("eval", "document.cookie");
  }

  private static string DateToUTC(int days) {
    return DateTime.Now.AddDays(days).ToUniversalTime().ToString("R");
  }
}