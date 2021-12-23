import * as Hash from "../services/hash.service.js"

function createHash(_req,_res){
     _res.json(Hash.createHash(_req.body.data))
}

export {createHash}