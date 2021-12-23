import Transaction from "../models/transaction.js";
import { newBlock } from "./block.service.js";
import EC from "elliptic";
const ec = new EC.ec("secp256k1");
var pendingTransactions = [];
/**
 * @param {string} privateKey
 * @param {string} post
 */
function newTransaction(privateKey, post) {
  let transaction = new Transaction(
    ec.keyFromPrivate(privateKey).getPublic("hex"),
    post
  );
  transaction.signTransaction(ec.keyFromPrivate(privateKey));
  pendingTransactions.push(transaction);
  if (pendingTransactions.length === 3) {
    newBlock(pendingTransactions);
    pendingTransactions = [];
  }
  return transaction;
}

export { newTransaction };
