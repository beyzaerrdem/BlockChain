import * as chainService from '../services/blockChain.service.js';

function valid(req,res){
    res.json(chainService.isChainValid(req.body.data))
}

export {valid}