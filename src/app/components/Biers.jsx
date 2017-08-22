const React = require('react')
const api = require('../../test/apiclient')
const BierList = require('./BierList.jsx')
const MoreBier = require('./MoreBier.jsx')
const NoMoreBier = require('./NoMoreBier.jsx')
const SearchBox = require('./SearchBox.jsx')

class Biers extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      biere: [],
      page: 1,
      totalPages: 0,
    };
    this.updateBiers = this.updateBiers.bind(this)
    this.nextpage = this.nextpage.bind(this)
    this.searh = this.searh.bind(this)
  }

  componentDidMount() {
    this.updateBiers(this.state.page)
  }

  updateBiers(page, query) {
    api.fetchBiers(page, query)
      .then((biere) => {
        this.setState(() => ({
          biere: [...this.state.biere, ...biere.data],
          totalPages: biere.numberOfPages,
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

  searh(query) {
    this.setState(() => ({
      biere: [],
      page: 1,
    }))
    this.updateBiers(1, query)
  }

  render() {
    return (
      <div>
        <SearchBox
          onSubmit={this.searh}
        />
        {this.state.biere.length === 0
          ? <p>LOADING!</p>
          : <BierList
            biere={this.state.biere}
          />}
        {this.state.page < this.state.totalPages
          ? <MoreBier nextpage={this.nextpage} />
          : <NoMoreBier />
        }
      </div>
    )
  }
}

module.exports = Biers
