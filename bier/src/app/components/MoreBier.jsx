const React = require('react')
const PropTypes = require('prop-types')

function MoreBier(props) {
  return (
    <div className="morebeer">
      <a href="" onClick={props.nextpage}>
        More bier!
      </a>
    </div>
  )
}

module.exports = MoreBier

MoreBier.propTypes = {
  nextpage: PropTypes.func.isRequired,
}
