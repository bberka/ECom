import * as Config from './config';

export function formatDateTime(dateTime){
  if(!dateTime) return null;
  return new Date(dateTime).toLocaleString()
}

export function formatDate(dateTime){
  if(!dateTime) return null;

  return new Date(dateTime).toLocaleString()
}

export function formatTime(dateTime){
  if(!dateTime) return null;

  return new Date(dateTime).toLocaleString()
}

export function formatCurrency(value){
  return value.format(Config.DefaultCurrencyFormat);
}

export function formatNumber(value){
  return value.format("0,0");
}

export function formatNumberWithDecimal(value, decimal){
  return value.format("0,0." + "0".repeat(decimal));
}


