import React from "react";
import RowTableContact from "./Components/RowTableContact";

const TableContact = (props) => {
    return (
        <table className="table table-hover">
            <thead>
                <tr>
                    <th>
                        №
                    </th>
                    <th>
                        Имя контакта
                    </th>
                    <th>
                        Электронная почта
                    </th>
                    <th>
                        Номер телефона
                    </th>
                    <th>
                        Адрес
                    </th>
                </tr>
            </thead>
            <tbody>
                {
                    props.contacts.map(
                        (contact, index) =>
                        (<RowTableContact
                            key={index}
                            id={contact.id}
                            name={contact.name}
                            email={contact.email}
                            phone={contact.phone}
                            address={contact.address}
                        />)
                    )
                }
            </tbody>
        </table>
    )
}

export default TableContact;