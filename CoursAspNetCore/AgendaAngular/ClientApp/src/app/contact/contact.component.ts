import { Component } from "@angular/core"
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "contact",
  templateUrl: "contact.component.html"
})
export class ContactComponent {
  contacts: contact[];

  constructor(private monHttp: HttpClient) {
    let urlApiAgenda = "http://localhost:60499";
    monHttp.get(urlApiAgenda + "/Contact").subscribe((result) => {
      this.contacts = <contact[]>result;
    })
  }
}
interface contact {
  nom: any;
  prenom: any;
  tel: any;
  avatar: any;
  emails : any[]
}
