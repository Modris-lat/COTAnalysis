"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.fs = void 0;
//Read file:
var fs = require('fs');
exports.fs = fs;
var dataCurrency = fs.readFileSync('currencyData.txt');
var fileCurrency = dataCurrency.toString().split(/\n/);
var dataCommodity = fs.readFileSync('commodityData.txt');
var fileCommodity = dataCommodity.toString().split(/\n/);
var dataUSD = fs.readFileSync('usdData.txt');
var fileUSD = dataUSD.toString().split(/\n/);
var dataEnergy = fs.readFileSync('energyData.txt');
var fileEnergy = dataEnergy.toString().split(/\n/);
/*const XLSX = require('xlsx');
let sheet = XLSX.readFile('cot.xlsx');*/
//Extract Currency Data:
function cotData(symbol) {
    for (var i = 0; i < fileCurrency.length; i++) {
        if (fileCurrency[i].startsWith(symbol)) {
            var arr = fileCurrency[i + 9]
                .split(' ')
                .filter(function (i) { return i.length > 0; })
                .map(function (i) { return parseInt(i.split(',').join('')); })
                .slice(0, 5)
                .filter(function (i, j) { return j != 2; });
            return arr;
        }
        else
            console.log('Data not found');
    }
    for (var i = 0; i < fileCommodity.length; i++) {
        if (fileCommodity[i].startsWith(symbol)) {
            var arr = fileCommodity[i + 9]
                .split(' ')
                .filter(function (i) { return i.length > 0; })
                .map(function (i) { return parseInt(i.split(',').join('')); })
                .slice(0, 5)
                .filter(function (i, j) { return j != 2; });
            return arr;
        }
        else
            console.log('Data not found');
    }
    for (var i = 0; i < fileUSD.length; i++) {
        if (fileUSD[i].startsWith(symbol)) {
            var arr = fileUSD[i + 9]
                .split(' ')
                .filter(function (i) { return i.length > 0; })
                .map(function (i) { return parseInt(i.split(',').join('')); })
                .slice(0, 5)
                .filter(function (i, j) { return j != 2; });
            return arr;
        }
        else
            console.log('Data not found');
    }
    for (var i = 0; i < fileEnergy.length; i++) {
        if (fileEnergy[i].startsWith(symbol)) {
            var arr = fileEnergy[i + 9]
                .split(' ')
                .filter(function (i) { return i.length > 0; })
                .map(function (i) { return parseInt(i.split(',').join('')); })
                .slice(0, 5)
                .filter(function (i, j) { return j != 2; });
            return arr;
        }
        else
            console.log('Data not found');
    }
}
//Extract currency:
var rubData = cotData('RUSSIAN');
var cadData = cotData('CANADIAN');
var chfData = cotData('SWISS');
var gbpData = cotData('BRITISH');
var jpyData = cotData('JAPANESE');
var eurData = cotData('EURO');
var nzdData = cotData('NEW ZEALAND');
var audData = cotData('AUSTRALIAN');
//Extract Commodity Data:
var aluminumData = cotData('ALUMINUM');
var silverData = cotData('SILVER');
var copperData = cotData('COPPER');
var goldData = cotData('GOLD');
//Extract USD:
var usdData = cotData('U.S. DOLLAR INDEX');
//Extract Energy:
var natGasData = cotData('NATURAL GAS');
var crudeOilData = cotData('CRUDE OIL');
//Append data to file:
fs.appendFileSync('rubShorts.txt', rubData[1] + ' ');
fs.appendFileSync('rubLongs.txt', rubData[0] + ' ');
fs.appendFileSync('cadShorts.txt', cadData[1] + ' ');
fs.appendFileSync('cadLongs.txt', cadData[0] + ' ');
fs.appendFileSync('chfShorts.txt', chfData[1] + ' ');
fs.appendFileSync('chfLongs.txt', chfData[0] + ' ');
fs.appendFileSync('gbpShorts.txt', gbpData[1] + ' ');
fs.appendFileSync('gbpLongs.txt', gbpData[0] + ' ');
fs.appendFileSync('jpyShorts.txt', jpyData[1] + ' ');
fs.appendFileSync('jpyLongs.txt', jpyData[0] + ' ');
fs.appendFileSync('eurShorts.txt', eurData[1] + ' ');
fs.appendFileSync('eurLongs.txt', eurData[0] + ' ');
fs.appendFileSync('nzdShorts.txt', nzdData[1] + ' ');
fs.appendFileSync('nzdLongs.txt', nzdData[0] + ' ');
fs.appendFileSync('audShorts.txt', audData[1] + ' ');
fs.appendFileSync('audLongs.txt', audData[0] + ' ');
fs.appendFileSync('alShorts.txt', aluminumData[1] + ' ');
fs.appendFileSync('alLongs.txt', aluminumData[0] + ' ');
fs.appendFileSync('silverShorts.txt', silverData[1] + ' ');
fs.appendFileSync('silverLongs.txt', silverData[0] + ' ');
fs.appendFileSync('goldShorts.txt', goldData[1] + ' ');
fs.appendFileSync('goldLongs.txt', goldData[0] + ' ');
fs.appendFileSync('copperShorts.txt', copperData[1] + ' ');
fs.appendFileSync('copperLongs.txt', copperData[0] + ' ');
fs.appendFileSync('usdShorts.txt', usdData[1] + ' ');
fs.appendFileSync('usdLongs.txt', usdData[0] + ' ');
fs.appendFileSync('gasShorts.txt', natGasData[1] + ' ');
fs.appendFileSync('gasLongs.txt', natGasData[0] + ' ');
fs.appendFileSync('oilShorts.txt', crudeOilData[1] + ' ');
fs.appendFileSync('oilLongs.txt', crudeOilData[0] + ' ');
