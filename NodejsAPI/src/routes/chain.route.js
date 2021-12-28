import express from "express";
import * as Chain from '../controllers/chain.controller.js'
const router = express.Router();

router.post('/chainIsValid',Chain.valid)

export default router;