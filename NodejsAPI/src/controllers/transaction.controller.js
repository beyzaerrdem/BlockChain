import * as transaction from "../services/transaction.service.js"

const valid=(req,res)=>{
   // console.log(req.body)
    let result=transaction.isTransactionValid(req.body.data)
    res.json(result)
}

export {valid}