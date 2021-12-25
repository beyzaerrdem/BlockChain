import express from "express";
import * as Transaction from "../controllers/transaction.controller.js";

const router = express.Router();

router.route("/isValid").post(Transaction.valid);

export default router;