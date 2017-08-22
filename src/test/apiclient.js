const Promise = require("bluebird");
const biere = require('./beerspayload.json')
const biere2 = require('./beerspayload2.json')
const biere3 = require('./beerspayload3.json')

module.exports = {
  fetchBiers(page, query) {
    console.log(page);
    console.log(query);

    let bierResponse = JSON.parse(JSON.stringify(biere))
    if (page === 2) {
      bierResponse = JSON.parse(JSON.stringify(biere2))
    }
    if (page === 3) {
      bierResponse = JSON.parse(JSON.stringify(biere3))
    }
    if (query) {
      bierResponse.data = bierResponse.data.filter(bier =>
        bier.name.includes(query))
      bierResponse.numberOfPages = 1
    }
    return new Promise((resolve) => {
      resolve(bierResponse)
    })
  },
}
