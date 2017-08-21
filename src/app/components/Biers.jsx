const React = require('react')
const api = require('../../../test/apiclient')
const BierList = require('./BierList.jsx')

class Biers extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      biers: [],
    };
    this.updateBiers = this.updateBiers.bind(this)
  }

  componentDidMount() {
    this.updateBiers()
  }

  updateBiers() {
    api.fetchBiers()
      .then((biers) => {
        this.setState(() => {
          return {
            biers: biers.data,
          }
        })
      })
  }

  render() {
    return (
      <div>
        {!this.state.biers
          ? <p>LOADING!</p>
          : <BierList biers={this.state.biers} />}
      </div>
    )
  }
}

module.exports = Biers
