import React, { useState } from "react";

const FormContact = (props) => {

    const [contactName, setContactName] = useState("");
    const [contactEmail, setContactEmail] = useState("");
    const [contactPhone, setContactPhone] = useState("");
    const [contactAddress, setContactAddress] = useState("");

    const submit = () => {
        if (contactName === `` || contactEmail === `` ||
            contactPhone === `` || contactAddress === ``) return;
        props.addContact(contactName, contactEmail, contactPhone, contactAddress);
        setContactName("");
        setContactEmail("");
        setContactPhone("");
        setContactAddress("");
    }

    return (
        <div>
            <div className="mb-3">
                <form >
                    <div className="mb-3">
                        <label className="form-label">Full name: </label>
                        <input className="form-control" type="text"
                        value={contactName}
                            onChange={(e) => { setContactName(e.target.value) }}
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">E-mail: </label>
                        <input className="form-control" type="text"
                        value={contactEmail}
                            onChange={(e) => { setContactEmail(e.target.value) }}
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">Phone number: </label>
                        <input className="form-control" type="text"
                        value={contactPhone}
                            onChange={(e) => { setContactPhone(e.target.value) }}
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">Address: </label>
                        <textarea className="form-control" rows={2}
                        value={contactAddress}
                            onChange={(e) => { setContactAddress(e.target.value) }}>
                        </textarea>
                    </div>
                </form>
            </div>
            <div>
                <button
                    className="btn btn-primary"
                    onClick={() => { submit() }}
                >
                    Add contact
                </button>
            </div>
        </div>
    );
}

export default FormContact;