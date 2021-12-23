import express from "express";
import * as Key from "../controllers/key.controller.js";

const router = express.Router();

router.route("/createKey").post(Key.createKey);

export default router;
