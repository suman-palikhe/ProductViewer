import React, { Component } from 'react';

export class Product extends Component {
    static displayName = 'Product Details';

    constructor(props) {
        super(props);
        this.state = { products: [], loading: true };
    }

    componentDidMount() {
        this.getProductCodeTypes();
    }

    static renderProductCodeTpyesTable(products) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>ProductId</th>
                        <th>ProductName</th>
                        <th>CodeType</th>
                        <th>Code</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(product =>
                        <tr key={product.productId}>
                            <td>{product.productName}</td>
                            <td>{product.retailerProductCodeType}</td>
                            <td>{product.retailerProductCode}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Product.renderProductCodeTpyesTable(this.state.products);

        return (
            <div>
                <h1 id="tabelLabel" >Distinct Product Code Type</h1>
                <p>Reading from Files</p>
                {contents}
            </div>
        );
    }

    async getProductCodeTypes() {
        const response = await fetch('product');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }
}
