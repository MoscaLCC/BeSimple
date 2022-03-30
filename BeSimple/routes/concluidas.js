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

router.get('/', function(req, res, next) {

  var query = "select ?ref ?modelo ?marca ?capa ?estado where{\n"+
              "?enc a m:Encomenda.\n"+
              "?enc m:temEstado m:Concluido.\n"+
              "?enc m:referencia ?ref.\n"+
              "?enc m:marca ?marca.\n"+
              "?enc m:modelo ?modelo.\n"+
              "?enc m:capa ?capa.\n"+
              "}"

  client.query(query).execute().then(function(qres){
      res.render("concluidas",{encomendas:qres.results.bindings})
  })

});

module.exports = router;
