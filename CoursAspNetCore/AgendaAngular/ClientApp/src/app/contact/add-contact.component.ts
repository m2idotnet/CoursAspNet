import { Component } from "@angular/core";
import { FormGroup, FormControl } from "@angular/forms";
import { ApiService } from "../Service/api.service";

@Component({
  selector: 'add-contact',
  templateUrl: 'add-contact.component.html'
})
export class AddContactComponent {

  addContactForm : FormGroup;

  constructor(private api : ApiService) {

    this.addContactForm = new FormGroup({
      nom: new FormControl(''),
      prenom: new FormControl(''),
      tel: new FormControl(''),
    })
  }

  Valider = () => {
    this.api.monPost('contact', {
      'Nom': this.addContactForm.controls.nom.value,
      'Prenom': this.addContactForm.controls.prenom.value,
      'Tel': this.addContactForm.controls.tel.value,
    }).subscribe(res => {
      if (<Boolean>res) {
        alert("contact ajouté");
      }
      else {
        alert("Erreur")
      }
    })
  }

}
