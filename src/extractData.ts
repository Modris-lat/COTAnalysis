//Read file:
const fs = require('fs');

const dataCurrency = fs.readFileSync('currencyData.txt');
const fileCurrency = dataCurrency.toString().split(/\n/);

const dataCommodity = fs.readFileSync('commodityData.txt');
const fileCommodity = dataCommodity.toString().split(/\n/);

const dataUSD = fs.readFileSync('usdData.txt');
const fileUSD = dataUSD.toString().split(/\n/);

const dataEnergy = fs.readFileSync('energyData.txt');
const fileEnergy = dataEnergy.toString().split(/\n/);

/*const XLSX = require('xlsx');
let sheet = XLSX.readFile('cot.xlsx');*/

//Extract Currency Data:
function cotData(symbol: string) {
    for (let i=0; i<fileCurrency.length; i++) {
        if (fileCurrency[i].startsWith(symbol)) {
            let arr = fileCurrency[i+9]
            .split(' ')
            .filter((i: string) => i.length > 0)
            .map((i: string) => parseInt(i.split(',').join('')))
            .slice(0, 5)
            .filter((i: any, j: number) => j != 2);
            return arr;
        } else console.log('Data not found');
    }
    for (let i=0; i<fileCommodity.length; i++) {
        if (fileCommodity[i].startsWith(symbol)) {
            let arr = fileCommodity[i+9]
            .split(' ')
            .filter((i: string) => i.length > 0)
            .map((i: string) => parseInt(i.split(',').join('')))
            .slice(0, 5)
            .filter((i: any, j: number) => j != 2);
            return arr;
        } else console.log('Data not found');
    }
    for (let i=0; i<fileUSD.length; i++) {
        if (fileUSD[i].startsWith(symbol)) {
            let arr = fileUSD[i+9]
            .split(' ')
            .filter((i: string) => i.length > 0)
            .map((i: string) => parseInt(i.split(',').join('')))
            .slice(0, 5)
            .filter((i: any, j: number) => j != 2);
            return arr;
        } else console.log('Data not found');
    }
    for (let i=0; i<fileEnergy.length; i++) {
        if (fileEnergy[i].startsWith(symbol)) {
            let arr = fileEnergy[i+9]
            .split(' ')
            .filter((i: string) => i.length > 0)
            .map((i: string) => parseInt(i.split(',').join('')))
            .slice(0, 5)
            .filter((i: any, j: number) => j != 2);
            return arr;
        } else console.log('Data not found');
    }
}

//Extract currency:
const rubData = cotData('RUSSIAN');
const cadData = cotData('CANADIAN');
const chfData = cotData('SWISS');
const gbpData = cotData('BRITISH');
const jpyData = cotData('JAPANESE');
const eurData = cotData('EURO');
const nzdData = cotData('NEW ZEALAND');
const audData = cotData('AUSTRALIAN');

//Extract Commodity Data:
const aluminumData = cotData('ALUMINUM');
const silverData = cotData('SILVER');
const copperData = cotData('COPPER');
const goldData = cotData('GOLD');

//Extract USD:
const usdData = cotData('U.S. DOLLAR INDEX');

//Extract Energy:
const natGasData = cotData('NATURAL GAS');
const crudeOilData = cotData('CRUDE OIL');


//Append data to file:
fs.appendFileSync('rubShorts.txt', rubData[1]+' ');
fs.appendFileSync('rubLongs.txt', rubData[0]+' ');
fs.appendFileSync('cadShorts.txt', cadData[1]+' ');
fs.appendFileSync('cadLongs.txt', cadData[0]+' ');
fs.appendFileSync('chfShorts.txt', chfData[1]+' ');
fs.appendFileSync('chfLongs.txt', chfData[0]+' ');
fs.appendFileSync('gbpShorts.txt', gbpData[1]+' ');
fs.appendFileSync('gbpLongs.txt', gbpData[0]+' ');
fs.appendFileSync('jpyShorts.txt', jpyData[1]+' ');
fs.appendFileSync('jpyLongs.txt', jpyData[0]+' ');
fs.appendFileSync('eurShorts.txt', eurData[1]+' ');
fs.appendFileSync('eurLongs.txt', eurData[0]+' ');
fs.appendFileSync('nzdShorts.txt', nzdData[1]+' ');
fs.appendFileSync('nzdLongs.txt', nzdData[0]+' ');
fs.appendFileSync('audShorts.txt', audData[1]+' ');
fs.appendFileSync('audLongs.txt', audData[0]+' ');
fs.appendFileSync('alShorts.txt', aluminumData[1]+' ');
fs.appendFileSync('alLongs.txt', aluminumData[0]+' ');
fs.appendFileSync('silverShorts.txt', silverData[1]+' ');
fs.appendFileSync('silverLongs.txt', silverData[0]+' ');
fs.appendFileSync('goldShorts.txt', goldData[1]+' ');
fs.appendFileSync('goldLongs.txt', goldData[0]+' ');
fs.appendFileSync('copperShorts.txt', copperData[1]+' ');
fs.appendFileSync('copperLongs.txt', copperData[0]+' ');
fs.appendFileSync('usdShorts.txt', usdData[1]+' ');
fs.appendFileSync('usdLongs.txt', usdData[0]+' ');
fs.appendFileSync('gasShorts.txt', natGasData[1]+' ');
fs.appendFileSync('gasLongs.txt', natGasData[0]+' ');
fs.appendFileSync('oilShorts.txt', crudeOilData[1]+' ');
fs.appendFileSync('oilLongs.txt', crudeOilData[0]+' ');


