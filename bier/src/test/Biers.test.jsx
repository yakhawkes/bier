import React from 'react'
import renderer from 'react-test-renderer';

const Biers = require('../app/components/Biers.jsx')
const api = require('./apiclient')

test('Page of Biers', () => {
  const component = renderer.create(
    <Biers api={api} />,
  );
  const tree = component.toJSON();
  expect(tree).toMatchSnapshot();
})
