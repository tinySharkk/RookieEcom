import React, { Component } from 'react';
import axios from 'axios';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/UpdateCategory';

class UpdateCategory extends Component {
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
                <h1>Update Category</h1>
                {renderUpdateCategoryFormat(this.props)}
            </div>
        );
    }
}

function renderUpdateCategoryFormat(props) {
    return <div className="mb-3">
        <p>Category Id</p>
        <input type="text" id="id" />

        <p>Name</p>
        <input type="text" id="name"  />

        <p className="mt-3">Description</p>
        <textarea id="desc" name="comment" cols="30" rows="5" className="form-control"></textarea>

        <p className="mt-3">ImageUlr</p>
        <input type="text" id="imageUrl" />
        <br />
        <button className="btn btn-dark mt-3"
            onClick={() => props.updateCategory(
                document.getElementById("id").value,
                document.getElementById("name").value,
                document.getElementById("desc").value,
                document.getElementById("imageUrl").value)}
        >Update Category</button>
    </div>
}


export default connect(
    state => state.updateCategory,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(UpdateCategory);