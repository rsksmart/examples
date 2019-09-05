# RSK Code Examples
This repository groups code examples, snippets and experimental implementations about common interactions to RSK blockchain.

## MinGasPrice
Sample code to get the `minimumGasPrice` parameter, considering two scenarios:
* `minimumGasPrice` stable
* `minimumGasPrice` being negotiated

For further information, read [RSKIP09](https://github.com/rsksmart/RSKIPs/blob/master/IPs/RSKIP09.md).

### Running the example
```
cd minGasPrice
npm install
node example.js
```

## Nethereum Sample
Sample .NET Project using Nethereum to connect to a local RSK regtest node.

### Requirements
* Visual Studio
* [Run local regtest node](https://github.com/rsksmart/rskj/wiki/Compile-and-run-a-RSK-node-locally)

### Run the sample
* Execute local regtest node instance
* Open Solution with Visual Studio
* Run !
