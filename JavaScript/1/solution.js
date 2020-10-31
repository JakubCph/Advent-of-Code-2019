const fs = require('fs')
const { type } = require('os')
let lines = fs.readFileSync('JavaScript/1/input.txt','utf8').split('\n')

// function calculateFuel(lines){
//     return lines.map(line => line / 3 - 2)
// }
 console.log( lines)
// console.log(calculateFuel(lines))