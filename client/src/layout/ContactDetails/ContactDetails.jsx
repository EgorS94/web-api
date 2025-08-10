import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";

const baseApiUrl = process.env.REACT_APP_API_URL;

const ContactDetails = () => {
    const [contact, setContact] = useState({ name: "", email: "", phone: "", address: "" });
    const contactId = useParams();
    const id = contactId.id;
    const navigate = useNavigate();

    useEffect(() => {
        const url = `${baseApiUrl}/contacts/${id}`;
        axios.get(url).then(
            response => setContact(response.data)
        ).catch(
            err => navigate("/")
        )
    }, [id, navigate]);

    return (
        <div className="container mt-5">
            <h2>Детали контакта</h2>
            <div className="mb-3">
                <label className="form-label">Имя: </label>
                <input className="form-control" type="text"
                    value={contact.name}
                    onChange={(e) => { }}
                />
                <label className="form-label">Email: </label>
                <input className="form-control" type="text"
                    value={contact.email}
                    onChange={(e) => { }}
                />
                <label className="form-label">Номер телефона: </label>
                <input className="form-control" type="text"
                    value={contact.phone}
                    onChange={(e) => { }}
                />
                <label className="form-label">Адрес: </label>
                <input className="form-control" type="text"
                    value={contact.address}
                    onChange={(e) => { }}
                />
            </div>
            <button className="btn btn-primary me-2" onClick={(e) => { }}>
                Обновить
            </button>
            <button className="btn btn-danger" onClick={(e) => { }}>
                Удалить
            </button>
            <button className="btn btn-secondary ms-2" onClick={(e) => { }}>
                Назад
            </button>
        </div>)
}

export default ContactDetails;