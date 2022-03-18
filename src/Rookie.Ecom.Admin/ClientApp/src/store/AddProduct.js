import { timers } from "jquery";
import axios from "axios";

const addProductType = 'ADD_PRODUCT';
const finishAddProductType = 'FINISH_ADD_PRODUCT'
const initialState = { isAdding: false };
const apiProduct = 'https://localhost:5011/api/Product';

//https://stackoverflow.com/questions/105034/how-to-create-a-guid-uuid#answer-2117523
function createGUID() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

export const actionCreators = {
    addProduct: (name, desc, price, inStock, categoryId) => async (dispatch, getState) => {
        dispatch({ type: addProductType });
        await axios.post(apiProduct, {
            "id": createGUID(),
            "createdDate": new Date().toISOString,
            "updatedDate": new Date().toISOString,
            "creatorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "pubished": true,
            "name": name,
            "desc": desc,
            "price": price,
            "inStock": inStock,
            "isFeatured": true,
            "categoryId": categoryId
        });
        dispatch({ type: finishAddProductType })
    }
};

export const reducer = (state, action) => {
  state = state || initialState;

    if (action.type === addProductType) {
        return {
            ...state,
            isAdding: true
        };
    }

    if (action.type === finishAddProductType) {
        return {
            ...state,
            isAdding: false
        };
    }

  return state;
};
