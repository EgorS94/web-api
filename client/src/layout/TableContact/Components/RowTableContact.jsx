import React from "react";
import { Link } from "react-router-dom";

const RowTableContact = (props) => {
    return (
        <tr>
            <td>{props.id}</td>
            <td>{props.name}</td>
            <td>{props.email}</td>
            <td>{props.phone}</td>
            <td>{props.address}</td>
            <td>
                <Link to={`/contacts/${props.id}`} className="btn btn-primary btn-sm">
                    Подробнее
                </Link>
            </td>
        </tr>
    )
}

export default RowTableContact;