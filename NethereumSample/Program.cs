using System;
using System.Numerics;
using System.Threading.Tasks;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace NethereumSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set web3 instance to rsk regtest node
            Web3 web3 = new Web3("http://127.0.0.1:4444");
            // This account is provided by regtest node and have funds
            decimal transferValue = 1000;
            var erc20ByteCode = "0x60606040526040516020806106f5833981016040528080519060200190919050505b80600160005060003373ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060005081905550806000600050819055505b506106868061006f6000396000f360606040523615610074576000357c010000000000000000000000000000000000000000000000000000000090048063095ea7b31461008157806318160ddd146100b657806323b872dd146100d957806370a0823114610117578063a9059cbb14610143578063dd62ed3e1461017857610074565b61007f5b610002565b565b005b6100a060048080359060200190919080359060200190919050506101ad565b6040518082815260200191505060405180910390f35b6100c36004805050610674565b6040518082815260200191505060405180910390f35b6101016004808035906020019091908035906020019091908035906020019091905050610281565b6040518082815260200191505060405180910390f35b61012d600480803590602001909190505061048d565b6040518082815260200191505060405180910390f35b61016260048080359060200190919080359060200190919050506104cb565b6040518082815260200191505060405180910390f35b610197600480803590602001909190803590602001909190505061060b565b6040518082815260200191505060405180910390f35b600081600260005060003373ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060005060008573ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600050819055508273ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff167f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925846040518082815260200191505060405180910390a36001905061027b565b92915050565b600081600160005060008673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600050541015801561031b575081600260005060008673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060005060003373ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000206000505410155b80156103275750600082115b1561047c5781600160005060008573ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000206000828282505401925050819055508273ffffffffffffffffffffffffffffffffffffffff168473ffffffffffffffffffffffffffffffffffffffff167fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef846040518082815260200191505060405180910390a381600160005060008673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008282825054039250508190555081600260005060008673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060005060003373ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000206000828282505403925050819055506001905061048656610485565b60009050610486565b5b9392505050565b6000600160005060008373ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000206000505490506104c6565b919050565b600081600160005060003373ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600050541015801561050c5750600082115b156105fb5781600160005060003373ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008282825054039250508190555081600160005060008573ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000206000828282505401925050819055508273ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff167fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef846040518082815260200191505060405180910390a36001905061060556610604565b60009050610605565b5b92915050565b6000600260005060008473ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060005060008373ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060005054905061066e565b92915050565b60006000600050549050610683565b9056";
            var erc20abi = @"[{""constant"":false,""inputs"":[{""name"":""_spender"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""approve"",""outputs"":[{""name"":""success"",""type"":""bool""}],""type"":""function""},{""constant"":true,""inputs"":[],""name"":""totalSupply"",""outputs"":[{""name"":""supply"",""type"":""uint256""}],""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_from"",""type"":""address""},{""name"":""_to"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""transferFrom"",""outputs"":[{""name"":""success"",""type"":""bool""}],""type"":""function""},{""constant"":true,""inputs"":[{""name"":""_owner"",""type"":""address""}],""name"":""balanceOf"",""outputs"":[{""name"":""balance"",""type"":""uint256""}],""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_to"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""transfer"",""outputs"":[{""name"":""success"",""type"":""bool""}],""type"":""function""},{""constant"":true,""inputs"":[{""name"":""_owner"",""type"":""address""},{""name"":""_spender"",""type"":""address""}],""name"":""allowance"",""outputs"":[{""name"":""remaining"",""type"":""uint256""}],""type"":""function""},{""inputs"":[{""name"":""_initialAmount"",""type"":""uint256""}],""type"":""constructor""},{""anonymous"":false,""inputs"":[{""indexed"":true,""name"":""_from"",""type"":""address""},{""indexed"":true,""name"":""_to"",""type"":""address""},{""indexed"":false,""name"":""_value"",""type"":""uint256""}],""name"":""Transfer"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""name"":""_owner"",""type"":""address""},{""indexed"":true,""name"":""_spender"",""type"":""address""},{""indexed"":false,""name"":""_value"",""type"":""uint256""}],""name"":""Approval"",""type"":""event""}]";
            BigInteger erc20TotalSupply = BigInteger.Parse("1000000000000000000");

            Console.WriteLine($"Checking block number...");
            BigInteger blockNumber = GetBlockNumber(web3).Result;
            Console.WriteLine($"Current Block Number: {blockNumber}");
            Console.ReadLine();

            // Get cow address
            String cowAccountAddress = web3.Eth.Accounts.SendRequestAsync().Result[0];

            // This code generates a new Account, be careful about private key !!
            Console.WriteLine($"Creating new account...");
            var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
            var privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();
            var account = new Nethereum.Web3.Accounts.Account(privateKey);
            Console.WriteLine($"New Account Address: {account.Address}");
            Console.ReadLine();

            // Check balances
            Console.WriteLine($"Checking balances...");

            // Check cow account Balance
            var cowAccountBalance = GetAccountBalance(web3, cowAccountAddress).Result;
            Console.WriteLine($"Cow Account Balance: {cowAccountBalance}");
            Console.ReadLine();

            // Check new account Balance
            var newAccountBalance = GetAccountBalance(web3, account.Address).Result;
            Console.WriteLine($"New Account Balance: {newAccountBalance}");
            Console.ReadLine();

            // Transfer 1 RBTC to new account
            Console.WriteLine($"Transfering {transferValue} wei of RBTC to {account.Address}...");
            String transactionHash = TransferRBTC(web3,cowAccountAddress,account.Address, transferValue).Result;
            Console.WriteLine($"Transaction Hash: {transactionHash}");
            Console.ReadLine();

            blockNumber = GetBlockNumber(web3).Result;
            while (GetBlockNumber(web3).Result == blockNumber)
            {
                Console.WriteLine("Waiting for block confirmation...");
            }

            // Check balances
            Console.WriteLine($"Checking balances...");

            // Check cow account Balance after transfer
            var cowAccountBalanceAfterTransfer = GetAccountBalance(web3, cowAccountAddress).Result;
            Console.WriteLine($"Cow Account Balance: {cowAccountBalanceAfterTransfer}");
            Console.ReadLine();

            // Check new account Balance after transfer
            var newAccountBalanceAfterTransfer = GetAccountBalance(web3, account.Address).Result;
            Console.WriteLine($"New Account Balance: {newAccountBalanceAfterTransfer}");
            Console.ReadLine();

            // Deploy ERC20 contract
            Console.WriteLine($"Deploying ERC20 contract...");
            String contractAddress = DeployERC20Contract(web3,erc20abi,erc20ByteCode,cowAccountAddress,erc20TotalSupply).Result;
            Console.WriteLine($"ERC20 deployed at: {contractAddress}");
            Console.ReadLine();

            // Check token Balances
            Console.WriteLine($"Check Token Balances...");
            Int64 ownerBalance = GetBalanceFromERC20(web3,erc20abi,contractAddress,cowAccountAddress).Result;
            Console.WriteLine($"Contract owner balance: {ownerBalance}");
            Int64 accountBalance = GetBalanceFromERC20(web3, erc20abi, contractAddress,account.Address).Result;
            Console.WriteLine($"New account balance: {accountBalance}");
            Console.ReadLine();

            Console.WriteLine($"Transfer {transferValue} Token to {account.Address}");
            String tokenTransferTransactionHash = TransferERC20Token(web3,erc20abi,contractAddress,cowAccountAddress,account.Address,transferValue).Result;
            Console.WriteLine($"Token Transfer Tx Hash: {tokenTransferTransactionHash}");
            Console.ReadLine();

            // Check token Balances
            Console.WriteLine($"Check Token Balances...");
            ownerBalance = GetBalanceFromERC20(web3, erc20abi, contractAddress, cowAccountAddress).Result;
            Console.WriteLine($"Contract owner balance: {ownerBalance}");
            accountBalance = GetBalanceFromERC20(web3, erc20abi, contractAddress, account.Address).Result;
            Console.WriteLine($"New account balance: {accountBalance}");

        }

        static async Task<BigInteger> GetBlockNumber(Web3 web3)
        {
            var blockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            return blockNumber.Value;
        }

        static async Task<Decimal> GetAccountBalance(Web3 web3, string address)
        {
            var balance = await web3.Eth.GetBalance.SendRequestAsync(address);
            return Web3.Convert.FromWei(balance.Value);
        }

        static async Task<String> TransferRBTC(Web3 web3, String addressFrom, String addressTo, decimal value)
        {
            var transactionInput = new Nethereum.RPC.Eth.DTOs.TransactionInput
            {
                From = addressFrom,
                To = addressTo,
                Value = new HexBigInteger(value.ToString())
            };

            return await web3.Eth.Transactions.SendTransaction.SendRequestAsync(transactionInput);
        }

        static async Task<String> DeployERC20Contract(Web3 web3,String abi, String bytecode, string address, BigInteger totalSupply)
        {
            var receipt = await web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(abi, bytecode, address, new Nethereum.Hex.HexTypes.HexBigInteger(900000), null, totalSupply);

            return receipt.ContractAddress;
        }

        static async Task<Int64> GetBalanceFromERC20(Web3 web3, String abi, String contractAddress, String userAddress)
        {
            var contract = web3.Eth.GetContract(abi, contractAddress);
            var balanceFunction = contract.GetFunction("balanceOf");

            return await balanceFunction.CallAsync<Int64>(userAddress);
        }

        static async Task<String> TransferERC20Token(Web3 web3, String abi, String contractAddress, String fromAddress, String toAddress, decimal amount)
        {
            var contract = web3.Eth.GetContract(abi, contractAddress);
            var transferFunction = contract.GetFunction("transfer");

            // Gas estimated, in wei
            var gas = await transferFunction.EstimateGasAsync(fromAddress, null, null, toAddress, amount);

            // Balance of From account
            var balance = await GetAccountBalance(web3, fromAddress);

            // Check that balance is enough to pay gas
            if (balance > Web3.Convert.FromWei(gas))
            {
                var transferReceipt = await transferFunction.SendTransactionAndWaitForReceiptAsync(fromAddress, gas, null, null, toAddress, amount);

                return transferReceipt.TransactionHash;
            }
            return null;
        }
    }
}
