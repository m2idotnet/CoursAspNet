import { Component, OnInit } from "@angular/core"
import { HttpClient } from "@angular/common/http";
import { ApiService } from "../Service/api.service";

@Component({
  selector: "contact",
  templateUrl: "contact.component.html"
})
export class ContactComponent implements OnInit {


    ngOnInit(): void {
        
    }
  contacts: Contact[];

  constructor(private api: ApiService) {
    //Les appels vers les api sont à mettre dans la Methode ngOninit ( Implémentation de l'interface OnInit )
    api.monGet("Contact").subscribe((result) => {
      this.contacts = <Contact[]>result;
    })
  }

  Delete = (id) => {
    this.api.monDelete('contact/' + id).subscribe(res => {
      const result = <Boolean>res;
      if (result) {
        alert("contact supprimé");
        this.api.monGet("Contact").subscribe((result) => {
          this.contacts = <Contact[]>result;
        })
      }
      else {
        alert("Erreur");
      }
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

