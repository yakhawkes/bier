const React = require('react')

function BierList(props) {
  return (
    <table>
      <tr>
        <th>Name</th>
      </tr>
      {props.biere.map(bier =>
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
