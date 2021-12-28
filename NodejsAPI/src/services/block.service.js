import Block from "../models/block.js";
import Transaction from "../models/transaction.js";

import https from "http";
import { isTransactionValid } from "./transaction.service.js";
import { createHash } from "./hash.service.js";

/**
 * @param {Transaction[]} pendingTransactions
 */
function newBlock(pendingTransactions) {
  const options = {
    hostname: "localhost",
    port: 44359,
    path: "/api/block/getLastBlockHash",
    method: "GET",
  };
  const req = https.request(options, (res) => {
    console.log(`statusCode: ${res.statusCode}`);
    res.setEncoding("utf8");
    res.on("data", (d) => {
      console.log(d);
      let block = new Block(Date.now(), pendingTransactions, JSON.parse(d));
      mineBlock(block,2);
      sendBlock(block);
    });
  });

  req.on("error", (error) => {
    console.error(error);
  });
  req.end();
}
/**
 * @param {Block} block
 */
function sendBlock(block) {
  const data = new TextEncoder().encode(JSON.stringify(block));

  const options = {
    hostname: "localhost",
    port: 44359,
    path: "/api/block/newBlock",
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      "Content-Length": data.length,
    },
  };

  const req = https.request(options, (res) => {
    console.log(`statusCode: ${res.statusCode}`);
    res.setEncoding("utf8");
    res.on("data", (d) => {
    });
  });

  req.on("error", (error) => {
    console.error(error);
  });

  req.write(data);
  req.end();
}

/**
 *
 * @param {Block} block
 * @param {number} difficulty
 */
function mineBlock(block, difficulty) {
  while (
    block.hash.substring(0, difficulty) !== Array(difficulty + 1).join("0")
  ) {
    block.nonce++;
    block.hash = createHash(block);
  }
  console.log(`Block mined: ${block.hash}`);
}

/**
 *
 * @param {Block} block
 * @returns {boolean}
 */
function hasValidTransactions(block) {
  for (const tx of block.transactions) {
    if (!isTransactionValid(tx)) {
      return false;
    }
  }
  return true;
}
/**
 * 
 * @param {Block} block 
 * @returns {boolean}
 */
function blockIsValid(block){
  if (block.hash === null) return false;

  if(!hasValidTransactions(block)) return false;
  let nonce=block.nonce
  mineBlock(block,2)
  return nonce==block.nonce
}
export { newBlock, mineBlock, hasValidTransactions,blockIsValid };
