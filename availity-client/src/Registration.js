function RegistrationForm() {
    return (
        <form class="ui form">
            <div>
                <label for="firstname">First Name:</label>
                <input type="text" name="firstname" />
            </div>
            <div>
                <label for="lastname">Last Name:</label>
                <input type="text" name="lastname" />
            </div>
            <div>
                <label for="npinumber">NPI number:</label>
                <input type="text" name="npinumber" />
            </div>
            <div>
                <label for="businessaddress">Business Address</label>
                <input type="text" name="businessaddress" />
            </div>
            <div>
                <label for="telephone">Telephone Number:</label>
                <input type="tel" 
                    name="telephone"
                    pattern="[\+]\d{2}[\(]\d{2}[\)]\d{4}[\-]\d{4}" />
            </div>
            <div>
                <label for="email">Email:</label>
                <input type="email" name="email" />
            </div>
            <input type="submit" />
        </form>
    );
}

export default RegistrationForm;