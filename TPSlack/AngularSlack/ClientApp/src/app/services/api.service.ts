import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable()
export class ApiService {

  urlApi = "http://localhost:59525/";
 
  constructor(private http: HttpClient) {
    
  
  }
  //action = chemin de l'api; data = donnée à envoyer; options = pour ajouter les entetes
  post = (action, data) => {
    return this.http.post(this.urlApi + action, data, { headers: { 'token': localStorage.getItem("token") } });
  }

  get = (action) => {
    return this.http.get(this.urlApi + action, { headers: { 'token': localStorage.getItem("token") } });
  } 

}
