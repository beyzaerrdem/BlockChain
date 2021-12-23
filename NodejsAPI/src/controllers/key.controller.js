import { createPrivateKeyHash, getPublicKeyHash } from "../services/key.service.js";

const createKey = (_req, _res) => {
  const privateKey =  createPrivateKeyHash(_req.body.data)

  const publicKey = getPublicKeyHash(privateKey)
  _res.json({ privateKey:privateKey, publicKey:publicKey  });
};
const privateKeyToPublicKey=(_req,_res)=>{
  _res.json(getPublicKeyHash(_req.body.data))
}
export { createKey,privateKeyToPublicKey };
