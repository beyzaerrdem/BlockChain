import { createHash } from "../services/hash.service.js";

export default class Transaction {
  /**
   * @param {string} postOwnerId
   * @param {string} post
   */
  constructor(postOwnerId, post) {
    this.postOwnerId = postOwnerId;
    this.post = post;
    this.timestamp = Date.now();
  }
  calculateHash() {
    return createHash(this.postOwnerId + this.post + this.timestamp);
  }
}
