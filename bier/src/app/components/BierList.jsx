const React = require('react')
const PropTypes = require('prop-types')
const BierCard = require('./BierCard.jsx')

function BierList(props) {
  const biere = props.biere
  return (
    <div className="bierlist">
      {biere.map(bier =>
        (
          <div key={bier.id}>
            <BierCard bier={bier} />
          </div>
        ),
      )}
    </div>
  )
}
module.exports = BierList

BierList.propTypes = {
  biere: PropTypes.arrayOf(
    PropTypes.shape({
      _id: PropTypes.string,
      name: PropTypes.string,
    }),
  ).isRequired,
}
