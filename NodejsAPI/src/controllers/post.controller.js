import { newTransaction } from "../services/transaction.service.js"

const addPost=(req,res)=>{
    let tr=newTransaction(req.body.data.postOwner,req.body.data.post)
    res.json(tr)
}

export {addPost}