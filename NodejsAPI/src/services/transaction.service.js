import Transaction from "../models/transaction.js";
import { newBlock } from "./block.service.js";
import { createHash } from "./hash.service.js";
import {
  getPrivateKey,
  getPublicKey,
  getPublicKeyHash,
} from "./key.service.js";
var pendingTransactions = [];
/**
 * @param {string} privateKey
 * @param {string} post
 */
function newTransaction(privateKey, post) {
  let transaction = new Transaction(getPublicKeyHash(privateKey), post);
  signTransaction(transaction, privateKey);
  pendingTransactions.push(transaction);
  if (pendingTransactions.length === 3) {
    newBlock(pendingTransactions);
    pendingTransactions = [];
  }
  return transaction;
}

/**
 *
 * @param {Transaction} transaction
 * @param {string} privateKey
 */
function signTransaction(transaction, privateKey) {
  if (getPublicKeyHash(privateKey) !== transaction.postOwnerId) {
    throw new Error("Başkası adına post paylaşamazsınız");
  }

  const hashTx = transaction.calculateHash();
  const sig = getPrivateKey(privateKey).sign(hashTx, "base64");

  transaction.signature = sig.toDER("hex");
}

/**
 *
 * @param {Transaction} transaction
 * @returns {boolean}
 */
function isTransactionValid(transaction) {
  if (transaction.postOwnerId === null) return false;

  if (!transaction.signature || transaction.signature.length === 0) {
    throw new Error("No signature in this transaction");
  }

  const publicKey = getPublicKey(transaction.postOwnerId);
  return publicKey.verify(calculateHash(transaction), transaction.signature);
}
function calculateHash(transaction) {
  return createHash(transaction.postOwnerId + transaction.post + transaction.timestamp);
}
export { newTransaction, isTransactionValid, signTransaction };
