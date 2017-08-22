const React = require('react')
const PropTypes = require('prop-types')

function BierList(props) {
  const biere = props.biere
  return (
    <ul>
      {biere.map(bier =>
        (
          <li key={bier.id}>
            <div>
              <h2>{bier.name}</h2>
              <ul>
                <li>
                  ABV: {bier.abv}%
                </li>
                <li>
                  Status: {bier.statusDisplay}
                </li>
              </ul>
            </div>
          </li>
        ),
      )}
    </ul>
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
