const React = require('react')
const PropTypes = require('prop-types')
const BierList = require('./BierList.jsx')
const MoreBier = require('./MoreBier.jsx')
const NoMoreBier = require('./NoMoreBier.jsx')
const Header = require('./Header.jsx')

class Biers extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      biere: [],
      page: 1,
      totalPages: 0,
      orderby: 'random',
      sort: 'ASC',
      query: '',
    };
    this.updateBiers = this.updateBiers.bind(this)
    this.nextpage = this.nextpage.bind(this)
    this.searh = this.searh.bind(this)
    this.order = this.order.bind(this)
  }

  componentDidMount() {
    this.updateBiers(this.state.page, '', this.state.orderby, '')
  }

  updateBiers(page, query, orderby, sort) {
    this.props.api.fetchBiers(page, query, orderby, sort)
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
      orderby: 'name',
      sort: 'ASC',
      query,
    }))
    this.updateBiers(1, query)
  }

  order(orderby) {
    console.log();
    const newsort = this.state.sort === 'ASC' ? 'DESC' : 'ASC'
    this.setState(() => ({
      biere: [],
      page: 1,
      orderby,
      sort: newsort,
      query: '',
    }))
    this.updateBiers(1, '', orderby, newsort)
  }

  render() {
    return (
      <div>
        <Header
          searhSubmit={this.searh}
          order={this.order}
          orderby={this.state.orderby}
          sort={this.state.sort}
          query={this.state.query}
        />
        <div>
          {this.state.biere.length === 0 && this.state.query
            ? <p>LOADING!</p>
            : <BierList
              biere={this.state.biere}
            />}
        </div>
        {this.state.page < this.state.totalPages
          ? <MoreBier nextpage={this.nextpage} />
          : <NoMoreBier />
        }
      </div>
    )
  }
}

module.exports = Biers

Biers.propTypes = {
  api: PropTypes.shape({
    fetchBiers: PropTypes.func,
  }).isRequired,
}
