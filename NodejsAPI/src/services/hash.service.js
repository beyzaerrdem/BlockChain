import crypto from "crypto";

/**
 * @returns {string}
 */
function createHash(obj) {
  return crypto.createHash("sha256").update(JSON.stringify(obj)).digest("hex");
}

export { createHash };
