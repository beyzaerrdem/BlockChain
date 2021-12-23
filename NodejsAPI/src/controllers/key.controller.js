import { createPrivateKeyHash, getPublicKeyHash } from "../services/key.service.js";

const createKey = (_req, _res) => {
  const privateKey =  createPrivateKeyHash(_req.body)

  const publicKey = getPublicKeyHash(privateKey)
  _res.json({ privateKey:privateKey, publicKey:publicKey  });
};

export { createKey };
