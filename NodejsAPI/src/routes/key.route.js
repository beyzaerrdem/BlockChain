import express from "express";
import { createKey } from "../controllers/key.controller.js";


const router = express.Router();

router.route('/createKey').post(createKey)

export default router