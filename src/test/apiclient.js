const Promise = require("bluebird");
const biers = require('./beerspayload.json')
const biers2 = require('./beerspayload2.json')
const biers3 = require('./beerspayload3.json')

module.exports = {
  fetchBiers(page) {
    if (page === 2) {
      return new Promise((resolve) => {
        resolve(biers2)
      })
    }
    if (page === 3) {
      return new Promise((resolve) => {
        resolve(biers3)
      })
    }
    return new Promise((resolve) => {
      resolve(biers)
    })
  },
}
