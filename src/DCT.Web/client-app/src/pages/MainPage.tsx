import { CircularProgress } from "@material-ui/core";
import React, { useEffect, useState } from "react";
import Form from "../components/Form";
import { IMunicipality } from "../models/IMunicipality";
import * as api from "../utils/apiFunctionts";

const MainPage = () => {
  const [municipalities, setMunicipalities] = useState<IMunicipality[] | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      const resp = await api.getMunicipalities();
      setMunicipalities(resp.data);
    };
    fetchData();
  }, []);
  return (
    <div>
      {!municipalities && <CircularProgress />}
      {municipalities && <Form municipalities={municipalities} />}
    </div>
  );
};

export default MainPage;
