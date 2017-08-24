const React = require('react')
const PropTypes = require('prop-types')

class BierCard extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      selectedClassName: '',
    };
    this.cardClick = this.cardClick.bind(this)
  }

  cardClick(event) {
    event.preventDefault()
    this.setState({
      selectedClassName: (this.state.selectedClassName === ''
        ? 'bierCardFull'
        : ''),
    })
  }

  render() {
    return (
      <a href="#" onClick={this.cardClick} className={`bierCard ${this.state.selectedClassName}`}>
        <h2>{this.props.bier.name}</h2>
        <ul className="bierstats">
          <li>
            ABV: {this.props.bier.abv}%
          </li>
          <li>
            Status: {this.props.bier.statusDisplay}
          </li>
        </ul>
      </a>
    )
  }
}

module.exports = BierCard

BierCard.propTypes = {
  bier: PropTypes.shape({
    _id: PropTypes.string,
    name: PropTypes.string,
    abv: PropTypes.string,
    statusDisplay: PropTypes.string,
  }).isRequired,
}
