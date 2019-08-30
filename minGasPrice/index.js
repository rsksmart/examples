const Web3 = require("web3");
const BigNumber = require("bignumber.js");

const rskHost = "https://public-node.rsk.co";

const getClient = () => {
    var client = new Web3();
    client.setProvider(new client.providers.HttpProvider(rskHost));
    return client;
};

const getMinimumGasPrice = (block) => {
    const minGasPrice = block.minimumGasPrice;
    return new BigNumber(minGasPrice);
}

exports.getCurrentMinimumGasPrice = async() => {
    const client = getClient();
    const blockNumber = await client.eth.getBlockNumber();
    const bestBlock = await client.eth.getBlock(blockNumber);
    return getMinimumGasPrice(bestBlock);
}

exports.getSafeMinimumGasPrice = async() => {
    // this calculation considers minimumGasPrice changing its value
    // minimumGasPrice can only vary 1% between one block and the next
    // when increasing, to add 10% offers a 10 blocks frame for a transaction to be valid

    const client = getClient();
    const blockNumber = await client.eth.getBlockNumber();
    const currentBlock = await client.eth.getBlock(blockNumber);
    const previousBlock = await client.eth.getBlock(blockNumber - 1);
    const currentMinGasPrice = getMinimumGasPrice(currentBlock);
    const previousMinGasPrice = getMinimumGasPrice(previousBlock);

    if (previousMinGasPrice > currentMinGasPrice) {
        // minimumGasPrice is decreasing (older blocks could be gathered to confirm tendence)
        return currentMinGasPrice;
    }

    return (currentMinGasPrice * 1.1).toFixed(0);
}
