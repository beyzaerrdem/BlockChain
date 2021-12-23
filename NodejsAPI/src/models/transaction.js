import crypto from "crypto"
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
    toString() {
      return JSON.stringify(this);
    }
    /**
     * @returns {string}
     */
    calculateHash() {
      return crypto
        .createHash("sha256")
        .update(this.postOwnerId + this.post + this.timestamp)
        .digest("hex");
    }
  
    signTransaction(signingKey) {
      if (signingKey.getPublic("hex") !== this.postOwnerId) {
        throw new Error("Başkası adına post paylaşamazsınız");
      }
  
      const hashTx = this.calculateHash();
      const sig = signingKey.sign(hashTx, "base64");
  
      this.signature = sig.toDER("hex");
    }
  
    /**
     * @returns {boolean}
     */
    isValid() {
      if (this.postOwnerId === null) return true;
  
      if (!this.signature || this.signature.length === 0) {
        throw new Error("No signature in this transaction");
      }
      const publicKey = ec.keyFromPublic(this.postOwnerId, "hex");
      return publicKey.verify(this.calculateHash(), this.signature);
    }
  }