# Truffle

## Deployment
`truffle migrate --network regtest` 
*run it twice to avoid truff issue #2224 *


## Call Smart Contract Methods
1. Start truffle console `truffle console --network regtest`
1. Mint Token by `Coin.deployed().then((instance=>instance.mint("0xCD2a3d9F938E13CD947Ec05AbC7FE734Df8DD826", 100)))`
Example result:
```
{ tx: '0xa306122ca536f79a30a5a725a50be8d16ed85455b2a5805b27265a9b1070a723',
  receipt: 
   { transactionHash: '0xa306122ca536f79a30a5a725a50be8d16ed85455b2a5805b27265a9b1070a723',
     transactionIndex: 0,
     blockHash: '0x8568a9895d3dee5889c62a2d179b2db6fecc7254520ddbc0397e020a7a5fd875',
     blockNumber: 2948,
     cumulativeGasUsed: 30122,
     gasUsed: 30122,
     contractAddress: null,
     logs: [ [Object] ],
     from: '0xcd2a3d9f938e13cd947ec05abc7fe734df8dd826',
     to: '0x1ed614cd3443efd9c70f04b6d777aed947a4b0c4',
     root: '0x01',
     status: true,
     rawLogs: [ [Object] ] },
  logs: 
   [ { logIndex: 0,
       blockNumber: 2948,
       blockHash: '0x8568a9895d3dee5889c62a2d179b2db6fecc7254520ddbc0397e020a7a5fd875',
       transactionHash: '0xa306122ca536f79a30a5a725a50be8d16ed85455b2a5805b27265a9b1070a723',
       transactionIndex: 0,
       address: '0x1eD614cd3443EFd9c70F04b6d777aed947A4b0c4',
       id: 'log_3f3de5d3',
       event: 'Mint',
       args: [Object] } ] }
```
1. Send Token to other address by `Coin.deployed().then((instance=>instance.send('0x7986b3DF570230288501EEa3D890bd66948C9B79',50)))`
Example result:
```
{ tx: '0x36623115c5db4795c43925562cfde562105205b36a2d5263ff2f9e6c65a2649d',
  receipt: 
   { transactionHash: '0x36623115c5db4795c43925562cfde562105205b36a2d5263ff2f9e6c65a2649d',
     transactionIndex: 0,
     blockHash: '0x6a0fa228e924b680aafc4dd67d5fcf02261e4b23e8d26cbd0b6d6ebc7c3a7a2c',
     blockNumber: 3019,
     cumulativeGasUsed: 50795,
     gasUsed: 50795,
     contractAddress: null,
     logs: [ [Object] ],
     from: '0xcd2a3d9f938e13cd947ec05abc7fe734df8dd826',
     to: '0x1ed614cd3443efd9c70f04b6d777aed947a4b0c4',
     root: '0x01',
     status: true,
     rawLogs: [ [Object] ] },
  logs: 
   [ { logIndex: 0,
       blockNumber: 3019,
       blockHash: '0x6a0fa228e924b680aafc4dd67d5fcf02261e4b23e8d26cbd0b6d6ebc7c3a7a2c',
       transactionHash: '0x36623115c5db4795c43925562cfde562105205b36a2d5263ff2f9e6c65a2649d',
       transactionIndex: 0,
       address: '0x1eD614cd3443EFd9c70F04b6d777aed947A4b0c4',
       id: 'log_74068027',
       event: 'Sent',
       args: [Object] } ] }
```

## Network Config
In order to use `--network regtest` in above commands, you need to make sure in truffle-config.js the networks setting include regtest

```js
networks: {
    regtest: {
      provider: new PrivateKeyProvider(privateKey, "http://127.0.0.1:4444"),
      host: "127.0.0.1",
      port: 4444,
      network_id: 33,
    }
},
```