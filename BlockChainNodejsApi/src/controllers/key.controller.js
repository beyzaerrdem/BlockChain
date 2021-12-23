import EC from "elliptic";
const ec = new EC.ec("secp256k1");
import crypto from "crypto";

const createKey = (_req, _res) => {
  const privateKey = crypto
    .createHash("sha256")
    .update(JSON.stringify(_req.body))
    .digest("hex");

  const publicKey = ec.keyFromPrivate(privateKey).getPublic("hex");
  _res.json({ privateKey: privateKey, publicKey: publicKey });
};

export { createKey };
