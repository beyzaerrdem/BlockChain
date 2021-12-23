import express from "express";

const router = express.Router();

import post from "./post.route.js";
import key from "./key.route.js";
import chain from "./chain.route.js";
import hash from './hash.route.js'

router.use("/post", post);
router.use("/key", key);
router.use('/chain',chain);
router.use("/hash",hash)

router.get("/health", (req, res) => {
  const healthcheck = {
    uptime: process.uptime(),
    message: "OK",
    timestamp: Date.now(),
  };
  res.send(JSON.stringify(healthcheck));
});

export default router;
