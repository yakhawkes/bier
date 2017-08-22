const React = require('react')
const PropTypes = require('prop-types')

function BierList(props) {
  const biere = props.biere
  return (
    <table>
      <tr>
        <th>Name</th>
      </tr>
      {biere.map(bier =>
        (
          <tr key={bier.id}>
            <td>{bier.name}</td>
          </tr>
        ),
      )}
    </table>
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
