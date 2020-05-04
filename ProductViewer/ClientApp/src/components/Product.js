import React, { Component } from 'react';

export class Product extends React.Component {
    static displayName = 'Product Details';

    constructor(props) {
        super(props);
        this.state = {
            products: [],
            loading: true,
            productFilePath: "",
            retailerProductFilePath: "",
            errorMessage: ""
        };
    }

    componentDidMount() {
        this.getProductCodeTypes();
    }

    renderProductCodeTypesTable(products) {
        return (
            <div>
                
                <p>Change the contents in the above files and press reload to see new results</p>
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
                            <tr key={`${product.productId}-${product.retailerProductCodeType}`}>
                                <td>{product.productId}</td>
                                <td>{product.productName}</td>
                                <td>{product.retailerProductCodeType}</td>
                                <td>{product.retailerProductCode}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    renderError(errorMessage) {
        return (
            <div style={{ color: 'red' }}>
                <h2>Error Occured</h2>
                Error Message : {errorMessage}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.state.errorMessage && this.state.errorMessage !== '' ?
                this.renderError(this.state.errorMessage)
                : this.renderProductCodeTypesTable(this.state.products);

        return (
            <div>
                <h1 id="tabelLabel" >Distinct Product Code Type</h1>
                <p>Reading from Files</p>
                <p>Product File Path : {this.state.productFilePath}</p>
                <p>Retailer Product File Path : {this.state.retailerProductFilePath}</p>
                <br />
                <button onClick={() => { this.getProductCodeTypes(); }}> Reload </button>
                <br />
                <br />
                {contents}
            </div>
        );
    }

    async getProductCodeTypes() {
        this.setState({ loading: true, errorMessage: '' });
        const response = await fetch('product');
        const data = await response.json();
        if (data.errorMessage && data.errorMessage !== '') {
            this.setState({ loading: false, errorMessage: data.errorMessage, productFilePath: data.productFilePath, retailerProductFilePath: data.retailerProductFilePath });
        }
        else {
            this.setState({ products: data.productCodes, loading: false, productFilePath: data.productFilePath, retailerProductFilePath: data.retailerProductFilePath });
        }

    }
}
