import React, { Component } from 'react';
import axios from 'axios';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/AddCategory';

class AddCategory extends Component {
    componentDidMount() {
        // This method is called when the component is first added to the document
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        // This method is called when the route parameters change
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        /*console.log(this.props.match.params.page);
        const page = parseInt(this.props.match.params.page, 5) || 0;
        console.log(page);
        this.props.requestAddCategories(page);*/
    }

    render() {
        return (
            <div>
                <h1>Add Category</h1>
                {renderAddCategoryFormat(this.props)}
            </div>
        );
    }
}

function renderAddCategoryFormat(props) {
    return <div className="mb-3">
        <p>Name</p>
        <input type="text" id="name"  />

        <p className="mt-3">Description</p>
        <textarea id="desc" name="comment" cols="30" rows="5" className="form-control"></textarea>

        <p className="mt-3">ImageUlr</p>
        <input type="text" id="imageUrl" />
        <br />
        <button className="btn btn-dark mt-3"
            onClick={() => props.addCategory(document.getElementById("name").value, document.getElementById("desc").value, document.getElementById("imageUrl").value)}
        >Add Category</button>
    </div>
}


export default connect(
    state => state.addCategory,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(AddCategory);