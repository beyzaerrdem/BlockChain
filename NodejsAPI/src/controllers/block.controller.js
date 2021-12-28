import * as blockService from '../services/block.service.js';

function valid(req,res){
    res.json(blockService.blockIsValid(req.body.data))
}

export {valid}