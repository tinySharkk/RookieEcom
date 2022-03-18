import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerReducer, routerMiddleware } from 'react-router-redux';
import * as Counter from './Counter';
import * as WeatherForecasts from './WeatherForecasts';
import * as Category from './Category';
import * as AddCategory from './AddCategory';
import * as Product from './Product';
import * as ProductImage from './ProductImage';
import * as User from './User';
import createOidcMiddleware from 'redux-oidc';
import { reducer as oidc } from 'redux-oidc';
import userManager from '../utils/userManager';
import * as AddProduct from './AddProduct';
import * as AddProductImage from './AddProductImage';
import * as UpdateCategory from './UpdateCategory';
import * as UpdateProduct from './UpdateProduct';
import * as UpdateProductImage from './UpdateProductImage';

export default function configureStore(history, initialState) {
    const reducers = {
        categories: Category.reducer,
        products: Product.reducer,
        counter: Counter.reducer,
        weatherForecasts: WeatherForecasts.reducer,
        productimages: ProductImage.reducer,
        users: User.reducer,
        addCategory: AddCategory.reducer,
        addProduct: AddProduct.reducer,
        addProductImage: AddProductImage.reducer,
        updateCategory: UpdateCategory.reducer,
        updateProduct: UpdateProduct.reducer,
        updateProductImage: UpdateProductImage.reducer,
        oidc
    };

    const oidcMiddleware = createOidcMiddleware(userManager);
    const middleware = [thunk, routerMiddleware(history), oidcMiddleware];

    // In development, use the browser's Redux dev tools extension if installed
    const enhancers = [];
    const isDevelopment = process.env.NODE_ENV === 'development';
    if (
        isDevelopment &&
        typeof window !== 'undefined' &&
        window.devToolsExtension
    ) {
        enhancers.push(window.devToolsExtension());
    }

    const rootReducer = combineReducers({
        ...reducers,
        routing: routerReducer
    });

    return createStore(
        rootReducer,
        initialState,
        compose(
            applyMiddleware(...middleware),
            ...enhancers
        )
    );
}
