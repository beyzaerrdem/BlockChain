import express from "express";
import { createServer } from "http";
import { createServer as _createServer } from "https";
import router from "./src/routes/index.route.js";
import bodyParser from "body-parser";

const app = express();
app.use(bodyParser.urlencoded({ extended: false }));

// parse application/json
app.use(bodyParser.json());
app.use('/api',router);
app.get("/block/getLastBlockHash", (req, res) => {
  res.end("0as0ad2a2dada5da5da");
});
app.post("/block/newBlock", (req, res) => {
  console.log(req.body);
  res.end();
});
const httpServer = createServer(app);
let port = 8081;
httpServer.listen(port);
console.log(`http server listening at port ${port}`);

export default { app };
