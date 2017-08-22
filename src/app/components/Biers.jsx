const React = require('react')
const api = require('../../test/apiclient')
const BierList = require('./BierList.jsx')

class Biers extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      biere: [],
      page: 1,
    };
    this.updateBiers = this.updateBiers.bind(this)
    this.nextpage = this.nextpage.bind(this)
  }

  componentDidMount() {
    this.updateBiers(this.state.page)
  }

  updateBiers(page) {
    api.fetchBiers(page)
      .then((biere) => {
        this.setState(() => ({
          biere: [...this.state.biere, ...biere.data],
        }))
      })
  }

  nextpage(event) {
    event.preventDefault()
    const newpage = this.state.page + 1
    this.setState(() => ({
      page: newpage,
    }))
    this.updateBiers(newpage)
  }

  render() {
    return (
      <div>
        {this.state.biere.length === 0
          ? <p>LOADING!</p>
          : <BierList
            biere={this.state.biere}
          />}
        <a href="" onClick={this.nextpage}>
          More bier!
        </a>
      </div>
    )
  }
}

module.exports = Biers
