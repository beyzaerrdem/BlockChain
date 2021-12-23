import express from "express";
import * as Hash from "../controllers/hash.controller.js"

const router = express.Router();

router.route("/createHash").get(Hash.createHash);

export default router;
