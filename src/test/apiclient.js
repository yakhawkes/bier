const Promise = require("bluebird");
const biere = require('./beerspayload.json')
const biere2 = require('./beerspayload2.json')
const biere3 = require('./beerspayload3.json')

module.exports = {
  fetchBiers(page) {
    console.log(page);
    if (page === 2) {
      return new Promise((resolve) => {
        resolve(biere2)
      })
    }
    if (page === 3) {
      return new Promise((resolve) => {
        resolve(biere3)
      })
    }
    return new Promise((resolve) => {
      resolve(biere)
    })
  },
}
