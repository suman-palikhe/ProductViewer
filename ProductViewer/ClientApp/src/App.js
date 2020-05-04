import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Product } from './components/Product';

import './custom.scss'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Product} />
                <Route path='/product' component={Product} />
            </Layout>
        );
    }
}
