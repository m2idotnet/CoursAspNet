import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Subject } from "rxjs";
import { Message } from "../message/IMessage";

@Injectable()
export class ApiService {

  urlApi = "http://localhost:59525/";

  MessageSubject = new Subject<any>();
 
  constructor(private http: HttpClient) {
    
  
  }

  emit(message) {
    this.MessageSubject.next(message);
  }
  //action = chemin de l'api; data = donnée à envoyer; options = pour ajouter les entetes
  post = (action, data) => {
    return this.http.post(this.urlApi + action, data, { headers: { 'token': localStorage.getItem("token") } });
  }

  get = (action) => {
    return this.http.get(this.urlApi + action, { headers: { 'token': localStorage.getItem("token") } });
  } 

}
