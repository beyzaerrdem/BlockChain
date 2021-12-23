import Block from "../models/block.js";
import Transaction from "../models/transaction.js";

import https from "http";

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
      block.mineBlock(2)
      sendBlock(block)
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

  const data = new TextEncoder().encode(
    JSON.stringify(block)
  );

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
      console.log(d)
    });
  });

  req.on("error", (error) => {
    console.error(error);
  });

  req.write(data);
  req.end();
}
export { newBlock };
