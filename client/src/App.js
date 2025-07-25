import FormContact from "./layout/FormContact/FormContact";
import TableContact from "./layout/TableContact/TableContact";
import React, { useState } from "react";
import axious from "axios";

const baseApiUrl = process.env.REACT_APP_API_URL;

const App = () => {

  const url = `${baseApiUrl}/contacts`;
  axious.get(url).then(
    res => console.log(res.data)
  );

  const [contacts, setContacts] = useState(
    [
      { id: 1, name: `Full name 1`, email: `ex1@mail.ru`, phone: `011-245-7036`, address: `東京都足立区東和２丁目１番４号ドーミー亀有301` },
      { id: 2, name: `Full name 2`, email: `ex2@mail.ru`, phone: `011-245-7034`, address: `東京都足立区東和２丁目１番４号ドーミー亀有302` },
      { id: 3, name: `Full name 3`, email: `ex3@mail.ru`, phone: `011-245-7039`, address: `東京都足立区東和２丁目１番４号ドーミー亀有303` }
    ]
  );

  const addContact = (contactName, contactEmail, contactPhone, contactAddress) => {

    const newId = contacts.length === 0 ? 1 : Math.max(
      ...contacts.map(e => e.id)) + 1;

    const item = {
      id: newId,
      name: contactName,
      email: contactEmail,
      phone: contactPhone,
      address: contactAddress
    }
    setContacts([...contacts, item]);
  }

  const deleteContacts = (id) => {
    setContacts(contacts.filter(item => item.id !== id));
  }
  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>
        <div className="card-body">
          <TableContact
            contacts={contacts}
            deleteContacts={deleteContacts}
          />
          <FormContact addContact={addContact} />
        </div>
      </div>
    </div>
  );
}

export default App