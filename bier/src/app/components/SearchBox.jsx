const React = require('react')
const PropTypes = require('prop-types')

class SearchBox extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      query: '',
    };

    this.handleChange = this.handleChange.bind(this)
    this.handleSubmit = this.handleSubmit.bind(this)
  }
  handleChange(event) {
    const value = event.target.value
    this.setState(() => (
      {
        query: value,
      }
    ));
  }
  handleSubmit(event) {
    event.preventDefault()
    this.props.onSubmit(this.state.query)
  }
  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <label htmlFor="querytext">Search name</label>
        <input
          id="querytext"
          placeholder=""
          type="text"
          value={this.state.query}
          autoComplete="off"
          onChange={this.handleChange}
        />
        <button disabled={!this.state.query} >
          Submit
        </button>
      </form>
    )
  }
}

SearchBox.propTypes = {
  onSubmit: PropTypes.func.isRequired,
}

module.exports = SearchBox;
