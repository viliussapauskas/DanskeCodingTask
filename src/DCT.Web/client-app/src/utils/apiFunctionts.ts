import axios from 'axios';
import { API_URL } from './constants';

export const getMunicipalities = () =>
  axios.get(`${API_URL}/municipality`);

export const getTaxes = (municipalityId: number, date: string) =>
axios.get(`${API_URL}/taxes/municipalities/${municipalityId}/date/${date}`)