import React from 'react'
import { render } from 'react-dom'
import {
  BrowserRouter as Router,
  Route,
} from 'react-router-dom'

require('./index.css')

const Biers = require('./components/Biers.jsx')

if (module.hot) {
  module.hot.accept()
}

const App = () => (
  <Router>
    <div>
      <h1>Bier!</h1>

      <hr />

      Where is my bier?
      <Route path="/" component={Biers} />
    </div>
  </Router>
)


render(
  <App />,
  document.getElementById('app'),
)
