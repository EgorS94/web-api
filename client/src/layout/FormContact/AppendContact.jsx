import FormContact from "./FormContact";
import axios from "axios";
import { useNavigate } from "react-router-dom";

const AppendContact = () => {
    
    const navigate = useNavigate();
    const baseApiUrl = window.config.apiUrl;

    const addContact = (contactName, contactEmail, contactPhone, contactAddress) => {

        let url = `${baseApiUrl}/contacts`;
        const item = {
            name: contactName,
            email: contactEmail,
            phone: contactPhone,
            address: contactAddress
        }
        axios.post(url, item)
            .then(
                () => { navigate("/"); }
            );
    }

    return (
        <div className="card">
            <div className="card-header">
                <h1>Добавить контакт</h1>
            </div>
            <div className="card-body">
                <FormContact addContact={addContact} />
            </div>
        </div>
    );
}

export default AppendContact;