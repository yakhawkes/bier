import React from 'react'
import { render } from 'react-dom'

require('./index.css')

console.log(module.hot);
const api = module.hot ? require('./../test/apiclient') : require('./apiclient')
const Biers = require('./components/Biers.jsx')
const Header = require('./components/Header.jsx')

if (module.hot) {
  module.hot.accept()
}

const App = () => (
  <div>
    <Header />
    Where is my bier?
    <Biers api={api} />
  </div>
)


render(
  <App />,
  document.getElementById('app'),
)
