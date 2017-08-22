import React from 'react'
import Biers from '../app/components/Biers.jsx'
import renderer from 'react-test-renderer';

test('Page of Biers', () => {
  const component = renderer.create(
    <Biers />,
  );
  const tree = component.toJSON();
  expect(tree).toMatchSnapshot();
})
