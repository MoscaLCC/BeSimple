var express = require('express');
var router = express.Router();
var formidable = require("formidable")

const SparqlClient = require('sparql-client-2')
const SPARQL = SparqlClient.SPARQL
const endpoint = 'http://localhost:7200/repositories/besimple'
const myupdateEndpoint = 'http://localhost:7200/repositories/besimple/statements'

var client = new SparqlClient( endpoint, {updateEndpoint: myupdateEndpoint, 
    defaultParameters: {format: 'json'}})

    client.register({rdf: 'http://www.w3.org/1999/02/22-rdf-syntax-ns#',
    m: 'http://besimplestore.pt/besimple#',
    owl: 'http://www.w3.org/2002/07/owl#'}) 


router.get('/', function(req, res, next){
    res.render('registarEnc');
})

router.post('/', function(req, res, next) {
    var form= new formidable.IncomingForm();
    
    form.parse(req,function(err,fields,files) {

        var data = new Date()
        var novadata = data.toISOString().split(':').join('-')
        novadata = novadata.split('.').join('-')
        
        var query = "INSERT DATA{\n"+
        "m:"+ novadata +" a m:Encomenda;\n"+
        '   m:referencia "'+ novadata +'";\n'+  
        '   m:marca "'+ fields.marca +'";\n'+  
        '   m:modelo "' + fields.modelo + '";\n'+
        '   m:capa "'+ fields.capa +'";\n'+  
        '   m:cliente "' + fields.cliente + '";\n'+
        '   m:morada "'+ fields.morada +'";\n'+  
        '   m:custos "' + fields.custos + '";\n'+
        '   m:venda "'+ fields.venda +'";\n'+  
        '   m:detalhes "' + fields.detalhes + '";\n'+
        '   m:temEstado m:Pendente.\n'+
        '}'

        client.query(query).execute().then(function(err){
            res.redirect('/') 
        }) 

    })
})
module.exports = router;