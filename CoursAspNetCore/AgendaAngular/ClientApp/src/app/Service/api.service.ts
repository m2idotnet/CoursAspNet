import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class ApiService {
  urlApiAgenda = "http://localhost:58721";

  constructor(private http: HttpClient) {

  }
  monPost = (path,data) => {
    return this.http.post(this.urlApiAgenda + "/" + path,data);
  }

  monGet = (path) => {
    return this.http.get(this.urlApiAgenda + "/" + path);
  }

  monPut = (path, data) => {
    return this.http.put(this.urlApiAgenda + "/" + path, data);
  }

  monDelete = (path) => {
    return this.http.delete(this.urlApiAgenda + "/" + path);
  }
}
