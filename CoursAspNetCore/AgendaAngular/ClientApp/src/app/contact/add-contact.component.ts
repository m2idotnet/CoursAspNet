import { Component } from "@angular/core";
import { FormGroup, FormControl } from "@angular/forms";
import { ApiService } from "../Service/api.service";
import { ActivatedRoute, Router } from "@angular/router";
import { Contact } from "./contact.component";
import { Route } from "@angular/compiler/src/core";

@Component({
  selector: 'add-contact',
  templateUrl: 'add-contact.component.html'
})
export class AddContactComponent {

  addContactForm: FormGroup;
  addFromType: Boolean = true;
  idContact = null;
  contact: Contact

  constructor(private api: ApiService, private maRoute: ActivatedRoute, private router: Router) {
    this.addContactForm = new FormGroup({
      nom: new FormControl(''),
      prenom: new FormControl(''),
      tel: new FormControl(''),
    })
    this.idContact = this.maRoute.snapshot.params.id;
    if (this.idContact != null)  {
      this.api.monGet('/contact/' + this.idContact).subscribe(res => {
        this.contact = <Contact>res;
        console.dir(this.contact);
        this.addContactForm.setValue({
          nom: this.contact.nom,
          prenom: this.contact.prenom,
          tel: this.contact.tel
        })
      })
      this.addFromType = false;
    }
    
  }

  Valider = () => {
    const data = {
      'Nom': this.addContactForm.controls.nom.value,
      'Prenom': this.addContactForm.controls.prenom.value,
      'Tel': this.addContactForm.controls.tel.value,
    };
    if (this.addFromType) {
      this.api.monPost('contact',data).subscribe(res => {
        if (<Boolean>res) {
          alert("contact ajouté");
        }
        else {
          alert("Erreur")
        }
      })
    }
    else {
      this.api.monPut('contact/' + this.idContact, data).subscribe(res => {
        alert("contact modifié");
        this.router.navigate(['/']);
      })
    }
    
  }

}
