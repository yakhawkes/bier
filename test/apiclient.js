const Promise = require("bluebird");
const biers = require('./beerspayload.json')

module.exports = {
  fetchBiers() {
    return new Promise((resolve) => {
      resolve(biers)
    },
    )
  },
}
