import React from 'react'
import { render } from 'react-dom'
import {
  BrowserRouter as Router,
  Route,
} from 'react-router-dom'

require('./index.css')

const api = require('../../test/apiclient')
const Biers = require('./components/Biers.jsx')
const Header = require('./components/Header.jsx')

if (module.hot) {
  module.hot.accept()
}

const App = () => (
  <Router>
    <div>
      <Header />
      Where is my bier?
      <Route path="/" component={Biers} api={api} />
    </div>
  </Router>
)


render(
  <App />,
  document.getElementById('app'),
)
