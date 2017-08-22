const React = require('react')
const api = require('../../test/apiclient')
const BierList = require('./BierList.jsx')

class Biers extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      biere: [],
    };
    this.updateBiers = this.updateBiers.bind(this)
  }

  componentDidMount() {
    this.updateBiers()
  }

  updateBiers() {
    api.fetchBiers()
      .then((biere) => {
        this.setState(() => {
          return {
            biere: biere.data,
          }
        })
      })
  }

  render() {
    return (
      <div>
        {!this.state.biere
          ? <p>LOADING!</p>
          : <BierList biere={this.state.biere} />}
      </div>
    )
  }
}

module.exports = Biers
