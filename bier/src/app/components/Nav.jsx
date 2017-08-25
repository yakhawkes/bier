const React = require('react')
const SearchBox = require('./SearchBox.jsx')
const Orderer = require('./Orderer.jsx')

function Nav(props) {
  return (
    <nav>
      <SearchBox
        onSubmit={props.searhSubmit}
      />
      <Orderer neworder="name" order={props.order} orderby={props.orderby} sort={props.sort} />
      <Orderer neworder="abv" order={props.order} orderby={props.orderby} sort={props.sort} />
      <Orderer neworder="status" order={props.order} orderby={props.orderby} sort={props.sort} />
    </nav>
  )
}

module.exports = Nav;
