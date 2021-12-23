import express from "express";
import { addPost } from "../controllers/post.controller.js";


const router = express.Router();

router.route('/addPost').post(addPost)

export default router