const React = require('react')
const PropTypes = require('prop-types')

function BierDetails(props) {
  const bier = props.bier
  const labels = bier.labels
  let icon
  if (labels) {
    icon = labels.icon
  }
  return (
    <div className="bierdetails">
      {icon
        ? <div>
          <img src={icon} alt={`${bier.name} label`} />
        </div>
        : ''}
      {bier.description
        ? <div>{bier.description}</div>
        : ''}
      {bier.foodPairings
        ? <div>{bier.foodPairings}</div>
        : ''}
    </div>
  )
}
module.exports = BierDetails

BierDetails.propTypes = {
  bier: PropTypes.shape({
    _id: PropTypes.string,
    name: PropTypes.string,
    abv: PropTypes.string,
    statusDisplay: PropTypes.string,
  }).isRequired,
}
