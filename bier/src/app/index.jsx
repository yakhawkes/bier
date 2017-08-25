import React from 'react'
import { render } from 'react-dom'

require('./index.css')

const api = module.hot ? require('./../test/apiclient') : require('./apiclient')
const Biers = require('./components/Biers.jsx')

if (module.hot) {
  module.hot.accept()
}

const App = () => (
  <div>
    Where is my bier?
    <Biers api={api} />
  </div>
)


render(
  <App />,
  document.getElementById('app'),
)
