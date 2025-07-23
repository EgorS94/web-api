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
                        Адресс
                    </th>
                </tr>
            </thead>
            <tbody>
                {
                    props.contacts.map(
                        contact =>
                        (<RowTableContact
                            id={contact.id}
                            name={contact.name}
                            email={contact.email}
                            phone={contact.phone}
                            address={contact.address}
                            deleteContacts={props.deleteContacts}
                        />)
                    )
                }
            </tbody>
        </table>
    )
}

export default TableContact;