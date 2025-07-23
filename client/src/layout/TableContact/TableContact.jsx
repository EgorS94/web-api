import React from "react";
import RowTableContact from "./Components/RowTableContact";

const TableContact = () => {
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
                <RowTableContact />
                <RowTableContact />
                <RowTableContact />
            </tbody>
        </table>
    )
}

export default TableContact;