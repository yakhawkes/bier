const React = require('react')

class Nav extends React.Component {
  constructor(props) {
    super(props)
    this.handleClick = this.handleClick.bind(this)
  }

  handleClick(event) {
    event.preventDefault()
    this.props.order(this.props.neworder);
  }
  render() {
    return (
      <a href="" onClick={this.handleClick}>{this.props.neworder}{
        this.props.neworder === this.props.orderby && this.props.sort === 'ASC'
          ? ' ▲'
          : ''
      }{
        this.props.neworder === this.props.orderby && this.props.sort === 'DESC'
          ? ' ▼'
          : ''
      }</a>
    )
  }
}

module.exports = Nav;
