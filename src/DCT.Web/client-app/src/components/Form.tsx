import {
    CssBaseline,
    Fade,
    FormControl,
    InputLabel,
    MenuItem,
    Paper,
    Select,
    Slide,
    Typography
} from "@material-ui/core";
import Button from "@material-ui/core/Button";
import Container from "@material-ui/core/Container";
import { makeStyles } from "@material-ui/core/styles";
import TextField from "@material-ui/core/TextField";
import React, { FC, useState } from "react";
import { IMunicipality } from "../models/IMunicipality";
import * as api from "../utils/apiFunctionts";

interface IProps {
  municipalities: IMunicipality[];
}

const useStyles = makeStyles((theme) => ({
  paper: {
    marginTop: theme.spacing(8),
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    padding: "2em",
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
  formControl: {
    margin: theme.spacing(1),
    minWidth: "100%",
  },
}));

const Form: FC<IProps> = (props) => {
    const [selectedMunicipalityId, setSelectedMunicipalityId] = useState<number | null>(null);
    const [selectedDate, setSelectedDate] = useState<string | null>(null);
    
    const [result, setResult] = useState<string | null>(null);
    
    const classes = useStyles();

    const handleSubmit = async () => {
        if (selectedMunicipalityId && selectedDate) {
        const resp = await api.getTaxes(selectedMunicipalityId, selectedDate);
        setResult(resp.data);
        }
    };

  return (
    <div>
      <Slide direction="down" in={true} mountOnEnter unmountOnExit>
        <Container component="main" maxWidth="xs">
          <CssBaseline />
          <Paper elevation={3} className={classes.paper}>
            <Typography component="h1" variant="h5">
              Taxes calculator
            </Typography>
            <FormControl className={classes.formControl}>
              <InputLabel>Municipality</InputLabel>
              <Select
                onChange={(event) => setSelectedMunicipalityId(event.target.value as number)}
                value={selectedMunicipalityId}
              >
                {props.municipalities.map((x) => (
                  <MenuItem key={x.id} value={x.id}>
                    {x.name}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
            <TextField
              variant="standard"
              margin="normal"
              required
              fullWidth
              type="date"
              id="date"
              value={selectedDate ?? ""}
              onChange={(e) => setSelectedDate(e.target.value)}
            />
            <Button
              fullWidth
              variant="contained"
              color="primary"
              className={classes.submit}
              onClick={() => handleSubmit()}
              disabled={!selectedMunicipalityId || !selectedDate}
            >
              Calculate
            </Button>

            {result && (
              <Fade in={true}>
                <div>
                    <Typography variant="h5">
                        Calculated Taxes 
                    </Typography>
                    <Typography variant="h4">
                        {result}
                    </Typography>
                </div>
              </Fade>
            )}
          </Paper>
        </Container>
      </Slide>
    </div>
  );
};

export default Form;
