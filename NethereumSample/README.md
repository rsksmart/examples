## Nethereum Sample
Sample .NET Project using Nethereum to connect to a local RSK regtest node.

### Requirements
* Visual Studio
* Run local regtest node (read above)

### Run local regtest node
First, what is a regtest ? There are 3 kinds of rsk nodes: 
* Mainnet: is the real thing, the "production" environment. If you make a transfer in Mainnet, you will need Mainnet accounts and real RBTC. 
* Testnet: is a simulation of the Mainnet, a "testing" environment. If you make a transfer in Testnet, you will need Testnet accounts and fake RBTC. You can get this fake RBTC from [RSK Testnet Faucet](https://faucet.testnet.rsk.co/).  
* Regtest: is a stand-alone node, the "development" environment. You use regtest accounts, and fake regtest RBTC.  

#### Why regtest ? 
You don't need to synchronize. You just use it. Best option to start developing.

#### Run a regtest node
* [Download](https://www.java.com/es/download/) and install Java 1.8 
* [Download](https://github.com/rsksmart/rskj/releases) last rsk release .jar file
* Move .jar file to the folder where you are going to work
* Open a terminal in that folder
* Run this command: 
`java -cp <.jar file> co.rsk.Start --regtest`
* Regtest node is running !

### Run the sample
* Execute local regtest node instance (read below)
* Open Solution with Visual Studio
* Run !

### Questions ?
If you have any questions you can reach us in [gitter](https://gitter.im/rsksmart).
