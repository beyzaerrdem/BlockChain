import EC from "elliptic";
const ec = new EC.ec("secp256k1");
import { createHash } from "./hash.service.js";

/**
 *
 * @param {string} privateKey
 */
function getPublicKeyHash(privateKey) {
  return ec.keyFromPrivate(privateKey).getPublic("hex");
}
/**
 *
 * @param {string} publicKey
 * @returns {EC.ec.KeyPair}
 */
function getPublicKey(publicKey) {
  return ec.keyFromPublic(publicKey, "hex");
}
/**
 * @returns {string}
 */
function createPrivateKeyHash(obj) {
  return createHash(obj);
}

/**
 *
 * @param {string} privateKeyHash
 * @returns {EC.ec.KeyPair}
 */
function getPrivateKey(privateKeyHash) {
  return ec.keyFromPrivate(privateKeyHash);
}

export { createPrivateKeyHash, getPublicKeyHash, getPrivateKey, getPublicKey };
