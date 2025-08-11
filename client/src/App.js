import FormContact from "./layout/FormContact/FormContact";
import TableContact from "./layout/TableContact/TableContact";
import React, { useState, useEffect } from "react";
import axios from "axios";
import { BrowserRouter, Route, Routes, useLocation } from "react-router-dom";
import ContactDetails from "./layout/ContactDetails/ContactDetails";
import Pagination from "./layout/Pagination/Pagination";

const baseApiUrl = process.env.REACT_APP_API_URL;

const App = () => {

  const [contacts, setContacts] = useState([]);
  const location = useLocation();
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(0);
  const [pageSize] = useState(10);

  const handlePageChange = (pageNumber) => {
    setCurrentPage(pageNumber);
  }

  // /page?pageNumber=2&pageSize=5

  useEffect(() => {
    const url = `${baseApiUrl}/contacts/page?pageNumber=${currentPage}&pageSize=${pageSize}`;
    axios.get(url).then(
      res => {
        setContacts(res.data.contacts);
        setTotalPages(Math.ceil(res.data.totalCount / pageSize))
      }
    );
  }, [currentPage, pageSize, location.pathname])

  const addContact = (contactName, contactEmail, contactPhone, contactAddress) => {

    let url = `${baseApiUrl}/contacts`;
    const item = {
      name: contactName,
      email: contactEmail,
      phone: contactPhone,
      address: contactAddress
    }
    axios.post(url, item);

    url = `${baseApiUrl}/contacts/page?pageNumber=${currentPage}&pageSize=${pageSize}`;
    axios.get(url).then(
      res => {
        setContacts(res.data.contacts);
        setTotalPages(Math.ceil(res.data.totalCount / pageSize))
      }
    );
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
              />
              <Pagination
                currentPage={currentPage}
                totalPages={totalPages}
                onPageChange={handlePageChange}
              />
              <FormContact addContact={addContact} />
            </div>
          </div>
        } />
        <Route path="contacts/:id" element={<ContactDetails />} />
      </Routes>
    </div>
  );
}

export default App