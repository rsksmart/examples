var func = require("./index.js");

(async () => {
    console.log("------------")
    console.log("Current minimumGasPrice: " + (await func.getCurrentMinimumGasPrice()));
    console.log("Safe minimumGasPrice: " + (await func.getSafeMinimumGasPrice()));
    console.log("------------")
})()
