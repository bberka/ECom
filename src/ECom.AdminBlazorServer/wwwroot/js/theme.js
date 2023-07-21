
const themeDictionary =
{
  "standard-base.css": "_content/Radzen.Blazor/css/standard-base.css",
  "material-base.css": "_content/Radzen.Blazor/css/material-base.css",
  "default-base.css": "_content/Radzen.Blazor/css/default-base.css",
  "humanistic-base.css": "_content/Radzen.Blazor/css/humanistic-base.css",
  "software-base.css": "_content/Radzen.Blazor/css/software-base.css",
  "dark-base.css": "_content/Radzen.Blazor/css/dark-base.css",
}


function getCookie(name) {
  var value = "; " + document.cookie;
  var parts = value.split("; " + name + "=");
  if (parts.length == 2) return parts.pop().split(";").shift();
  return null;
}
function getThemeId() {
  var selectedThemeFromCookie = getCookie("selected-theme");
  if (selectedThemeFromCookie) {
    return selectedThemeFromCookie;
  }
  return "dark-base.css";
}


function applyTheme() {
  var id = getThemeId();
  var link = document.getElementById("theme-css");
  link.href = themeDictionary[id];
}

applyTheme();