import { Component } from "@angular/core"
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "contact",
  templateUrl: "contact.component.html"
})
export class ContactComponent {
  contacts: Contact[];

  constructor(private monHttp: HttpClient) {
    let urlApiAgenda = "http://localhost:58721";
    const test = "bonjour";
    monHttp.get(urlApiAgenda + "/Contact").subscribe((result) => {
      this.contacts = <Contact[]>result;
    })
  }
}
export interface Contact {
  nom: any;
  prenom: any;
  tel: any;
  avatar: any;
  emails : any[]
}

