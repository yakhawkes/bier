const axios = require('axios')

module.exports = {
  fetchBiers(page, query, orderby, sort) {
    let encodedURI = window.encodeURI('/api/')
    encodedURI = query
      ? `${encodedURI}search?q=${window.encodeURI(query)}&`
      : `${encodedURI}bier?`
    if (page) {
      encodedURI = `${encodedURI}p=${page}&`
    }
    if (orderby) {
      encodedURI = `${encodedURI}order=${orderby}&`
    }
    if (sort) {
      encodedURI = `${encodedURI}sort=${sort}&`
    }

    return axios.get(encodedURI)
      .then(response => response.data)
  },
}
