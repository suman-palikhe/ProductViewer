import React, { Component } from 'react';

export class Product extends Component {
    static displayName = 'Product Details';

    constructor(props) {
        super(props);
        this.state = { products: [], loading: true, productFilePath: "", retailerProductFilePath: "" };
    }

    componentDidMount() {
        this.getProductCodeTypes();
    }

    static renderProductCodeTypesTable(products) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Product Id</th>
                        <th>Product Name</th>
                        <th>Code Type</th>
                        <th>Code</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(product =>
                        <tr key={product.productId}>
                            <td>{product.productId}</td>
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
            : Product.renderProductCodeTypesTable(this.state.products);

        return (
            <div>
                <h1 id="tabelLabel" >Distinct Product Code Type</h1>
                <p>Reading from Files</p>
                <p>Product File Path : {this.state.productFilePath}</p>
                <p>Retailer Product File Path : {this.state.retailerProductFilePath}</p>
                {contents}
            </div>
        );
    }

    async getProductCodeTypes() {
        const response = await fetch('product');
        const data = await response.json();
        debugger;
        this.setState({ products: data.productCodes, loading: false, productFilePath: data.productFilePath, retailerProductFilePath: data.retailerProductFilePath });
    }
}
