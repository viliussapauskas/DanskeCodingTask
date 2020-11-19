import axios from "axios";
import React, { useEffect, useState } from "react";
import "./App.css";

const App = () => {
  const [municipalities, setMunicipalities] = useState<any[] | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      const result = await axios("http://localhost:5000/api/municipality");
      setMunicipalities(result.data);
    };

    fetchData();
  }, []);
  return (
    <div className="App">
      {!municipalities && <div>Loading...</div>}
      {municipalities && (
        <div>
          {municipalities.map((x, i) => (
            <div key={i}>{x.name}</div>
          ))}
        </div>
      )}
    </div>
  );
};

export default App;
