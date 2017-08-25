const React = require('react')
const Nav = require('./Nav.jsx')

class Biers extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      selectedClassName: '',
    };
    this.headShrinker = this.headShrinker.bind(this)
  }

  componentDidMount() {
    this.headShrinker()
  }

  headShrinker() {
    window.addEventListener('scroll', () => {
      const distanceY = window.pageYOffset || document.documentElement.scrollTop
      const shrinkOn = 50
      this.setState({
        selectedClassName: (distanceY > shrinkOn
          ? 'smaller'
          : ''),
      })
    },
    )
  }


  render() {
    return (
      <header className={this.state.selectedClassName}>
        <h1 id="logo">Bier!</h1>
        <Nav
          searhSubmit={this.props.searhSubmit}
          order={this.props.order}
          orderby={this.props.orderby}
          sort={this.props.sort}
          query={this.props.query}
        />
      </header>
    )
  }
}

module.exports = Biers
