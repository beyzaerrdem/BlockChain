import Block from "./src/models/block.js";
import Transaction from "./src/models/transaction.js";
import {
  addTransaction,
  createGenesisBlock,
  minePendingTransactions,
} from "./src/services/blockChain.service.js";
import {
  createPrivateKeyHash,
  getPrivateKey,
  getPublicKeyHash,
} from "./src/services/key.service.js";
import { signTransaction } from "./src/services/transaction.service.js";

const privateKey = createPrivateKeyHash("salihözkara");
const mykey = getPrivateKey(privateKey);
const publicKey = getPublicKeyHash("2b59c50d6c3b14de33f3a091e05666e790dc2c0da9b49f25baecdaa1dd16311b");
console.log(publicKey)




// /**
//  * @type {Block[]}
//  */
const chain = [createGenesisBlock()];
 var pendingTransactions = [];

// minePendingTransactions(pendingTransactions, chain);
 const tx1 = new Transaction(publicKey, "Hello world");
signTransaction(tx1, mykey);

 addTransaction(tx1, pendingTransactions);

// minePendingTransactions(pendingTransactions, chain);

 const tx2 = new Transaction(publicKey, "Hi");
 signTransaction(tx2, mykey);

 addTransaction(tx2, pendingTransactions);

 minePendingTransactions(pendingTransactions, chain);

 console.log(chain);
