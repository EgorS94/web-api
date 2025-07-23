function App() {
  return (
    <div>
      <div>
        <div>
          <h1>Список контактов</h1>
        </div>
        <div>
          <table>
            <thead>
              <tr>
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
                {/* <th>

                </th> */}
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Name</td>
                <td>e-mail</td>
                <td>phone number</td>
                <td>address</td>
              </tr>
              <tr>
                <td>Name 2</td>
                <td>e-mail 2</td>
                <td>phone number 2</td>
                <td>address 2</td>
              </tr>
              <tr>
                <td>Name 3</td>
                <td>e-mail 3</td>
                <td>phone number 3</td>
                <td>address 3</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}

export default App