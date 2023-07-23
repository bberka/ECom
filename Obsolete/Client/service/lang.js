import languagePack from './language.json';

export function read(key){
  let selectedLanguage = localStorage.getItem("language");
  if(!selectedLanguage) selectedLanguage = "en";
  let value = languagePack[selectedLanguage][key];
  if(!value) return key;
  return value;
}

export function list(languagePack = "en"){
  return languagePack[languagePack];
}