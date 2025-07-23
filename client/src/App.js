import TableContact from "./layout/TableContact/TableContact";

const contacts = [
  { id: 1, name: `Full name 1`, email: `ex1@mail.ru`, phone: `011-245-7036`, address: `東京都足立区東和２丁目１番４号ドーミー亀有301` },
  { id: 2, name: `Full name 2`, email: `ex2@mail.ru`, phone: `011-245-7034`, address: `東京都足立区東和２丁目１番４号ドーミー亀有302` },
  { id: 3, name: `Full name 3`, email: `ex3@mail.ru`, phone: `011-245-7039`, address: `東京都足立区東和２丁目１番４号ドーミー亀有303` }
];

const App = () => {
  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>
        <div className="card-body">
          <TableContact contacts={contacts} />
        </div>
      </div>
    </div>
  );
}

export default App