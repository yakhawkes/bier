const React = require('react')
const PropTypes = require('prop-types')

function MoreBier(props) {
  return (
    <a href="" onClick={props.nextpage}>
      More bier!
    </a>
  )
}

module.exports = MoreBier

MoreBier.propTypes = {
  nextpage: PropTypes.func.isRequired,
}
