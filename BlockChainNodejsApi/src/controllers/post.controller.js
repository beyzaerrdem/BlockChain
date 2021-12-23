import { newTransaction } from "../services/transaction.service.js"

const addPost=(req,res)=>{
    let tr=newTransaction(req.body.postOwner,req.body.post)
    res.json(tr)
}

export {addPost}