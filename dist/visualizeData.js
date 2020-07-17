"use strict";
var fs = require('fs');
var rubLongs = fs.readFileSynce('rubLongs.txt');
var RUB = rubLongs.toString().split(' ');
console.log(RUB);
