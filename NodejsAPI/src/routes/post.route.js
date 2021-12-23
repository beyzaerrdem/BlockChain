import express from "express";
import * as Post from "../controllers/post.controller.js";

const router = express.Router();

router.route("/addPost").post(Post.addPost);

export default router;
