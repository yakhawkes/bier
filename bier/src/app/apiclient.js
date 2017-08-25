const axios = require('axios')

module.exports = {
  fetchBiers(page, query) {
    let encodedURI = window.encodeURI('http://localhost:63135/api/')
    encodedURI = query
      ? `${encodedURI}search?${encodedURI}q=${window.encodeURI(query)}&`
      : `${encodedURI}bier?`
    if (page) {
      encodedURI = `${encodedURI}p=${page}&`
    }

    return axios.get(encodedURI)
      .then(response => response.data)
  },
}
