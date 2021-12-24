import Block from "../models/block.js";
import Transaction from "../models/transaction.js";
import { hasValidTransactions, mineBlock } from "./block.service.js";
import { createHash } from "./hash.service.js";
import { isTransactionValid } from "./transaction.service.js";

/**
 * @returns {Block}
 */
function createGenesisBlock() {
  return new Block(Date.parse("2017-01-01"), [], "0");
}

/**
 *
 * @param {Block[]} chain
 * @returns {Block}
 */
function getLatestBlock(chain) {
  return chain[chain.length - 1];
}

/**
 *
 * @param {Transaction[]} pendingTransactions
 * @param {Block[]} chain
 */
function minePendingTransactions(pendingTransactions, chain) {
  const block = new Block(
    Date.now(),
    //Object.assign([], pendingTransactions),
    pendingTransactions,
    getLatestBlock(chain).hash
  );
  mineBlock(block, 2);
  console.log("Block successfully mined!");
  chain.push(block);

  pendingTransactions = [];
}

/**
 * Returns a list of all transactions that happened
 * to and from the given wallet address.
 *
 * @param {string} publicKey
 * @param {Block[]} chain
 * @return {Transaction[]}
 */
function getAllTransactionsForUser(publicKey, chain) {
  const txs = [];
  for (const block of chain) {
    for (const tx of block.transactions) {
      if (tx.postOwnerId === publicKey) {
        txs.push(tx);
      }
    }
  }
  console.log("get transactions for wallet count: %s", txs.length);
  return txs;
}

/**
 * @param {Transaction} transaction
 * @param {Transaction[]} pendingTransactions
 */
function addTransaction(transaction, pendingTransactions) {
  if (!transaction.postOwnerId) {
    throw new Error("Transaction must include from and to address");
  }

  // Verify the transactiion
  if (!isTransactionValid(transaction)) {
    throw new Error("Cannot add invalid transaction to chain");
  }

  // Making sure that the post sent is not greater than existing balance

  pendingTransactions.push(transaction);
  console.log("transaction added: %s", transaction);
}

/**
 *
 * @param {Block[]} chain
 * @returns {boolean}
 */
function isChainValid(chain) {
  const realGenesis = JSON.stringify(createGenesisBlock());

  if (realGenesis !== JSON.stringify(chain[0])) {
    return false;
  }
  for (let i = 1; i < chain.length; i++) {
    const currentBlock = chain[i];
    const previousBlock = chain[i - 1];

    if (previousBlock.hash !== currentBlock.previousHash) {
      return false;
    }

    if (!hasValidTransactions(currentBlock)) {
      return false;
    }

    if (currentBlock.hash !== createHash(currentBlock)) {
      return false;
    }
  }

  return true;
}

export {
  createGenesisBlock,
  getLatestBlock,
  minePendingTransactions,
  getAllTransactionsForUser,
  addTransaction,
  isChainValid,
};
