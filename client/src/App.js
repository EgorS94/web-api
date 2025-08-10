import FormContact from "./layout/FormContact/FormContact";
import TableContact from "./layout/TableContact/TableContact";
import React, { useState, useEffect } from "react";
import axios from "axios";
import {BrowserRouter, Route, Routes} from "react-router-dom";
import ContactDetails from "./layout/ContactDetails/ContactDetails";

const baseApiUrl = process.env.REACT_APP_API_URL;

const App = () => {

  const [contacts, setContacts] = useState(
    [
      // { id: 1, name: `Full name 1`, email: `ex1@mail.ru`, phone: `011-245-7036`, address: `東京都足立区東和２丁目１番４号ドーミー亀有301` },
      // { id: 2, name: `Full name 2`, email: `ex2@mail.ru`, phone: `011-245-7034`, address: `東京都足立区東和２丁目１番４号ドーミー亀有302` },
      // { id: 3, name: `Full name 3`, email: `ex3@mail.ru`, phone: `011-245-7039`, address: `東京都足立区東和２丁目１番４号ドーミー亀有303` }
    ]
  );

  const url = `${baseApiUrl}/contacts`;

  useEffect(() => {
    axios.get(url).then(
      res => setContacts(res.data)
    );
  }, [])

  const addContact = (contactName, contactEmail, contactPhone, contactAddress) => {

    const url = `${baseApiUrl}/contacts`;
    const item = {
      name: contactName,
      email: contactEmail,
      phone: contactPhone,
      address: contactAddress
    }
    axios.post(url, item).then(
      response => setContacts([...contacts, response.data])
    );
  }

  const deleteContacts = (id) => {
    const url = `${baseApiUrl}/contacts/${id}`;
    axios.delete(url);
    setContacts(contacts.filter(item => item.id !== id));
  }
  return (
    <div className="container mt-5">
      <Routes>
        <Route path="/" element={
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
        } />
        <Route path = "contacts/:id" element = {<ContactDetails />} />
      </Routes>
    </div>
  );
}

export default App