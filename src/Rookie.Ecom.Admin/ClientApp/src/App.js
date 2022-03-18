import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Category from './components/Category';
import AddCategory from './components/AddCategory';
import Product from './components/Product';
import ProductImage from './components/ProductImage';
import User from './components/User';
import Counter from './components/Counter';
import FetchData from './components/FetchData';

import CallbackPage from './components/callback/CallbackPage';
import ProfilePage from './components/profile/ProfilePage';
import AddProduct from './components/AddProduct';
import AddProductImage from './components/AddProductImage';
import UpdateCategory from './components/UpdateCategory';
import UpdateProduct from './components/UpdateProduct';
import UpdateProductImage from './components/UpdateProductImage ';

export default () => (
    <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/counter" component={Counter} />
        <Route path="/category/:page?" component={Category} />
        <Route path="/addcategory" component={AddCategory} />
        <Route path="/updatecategory" component={UpdateCategory} />
        <Route path="/product/:page?" component={Product} />
        <Route path="/addproduct" component={AddProduct} />
        <Route path="/updateproduct" component={UpdateProduct} />
        <Route path="/productimage/:page?" component={ProductImage} />
        <Route path="/addproductimage" component={AddProductImage} />
        <Route path="/updateproductimage" component={UpdateProductImage} />
        <Route path="/user/:page?" component={User} />
        <Route path="/fetch-data/:startDateIndex?" component={FetchData} />

        <Route path="/profile" component={ProfilePage} />
        <Route path="/callback" component={CallbackPage} />
    </Layout>
);
