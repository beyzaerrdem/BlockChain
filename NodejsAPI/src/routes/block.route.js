import express from "express";
import * as Block from '../controllers/block.controller.js'
const router = express.Router();

router.post('/blockIsValid',Block.valid)

export default router;