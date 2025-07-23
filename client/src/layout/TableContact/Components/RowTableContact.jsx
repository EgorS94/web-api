import React from "react";

const RowTableContact = (props) => {
    return (
        <tr>
            <td>{props.id}</td>
            <td>{props.name}</td>
            <td>{props.email}</td>
            <td>{props.phone}</td>
            <td>{props.address}</td>
        </tr>
    )
}

export default RowTableContact;