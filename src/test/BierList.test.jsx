import React from 'react'
import renderer from 'react-test-renderer'
import BierList from '../app/components/BierList.jsx'

const biere = require('./beerspayload.json')

test('List of Biers', () => {
  const component = renderer.create(
    <BierList biere={biere.data} />,
  );
  const tree = component.toJSON();
  expect(tree).toMatchSnapshot();
})
