import {Component} from "@angular/core";
import {ActivatedRoute} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {Contact} from "./contact.component";

@Component({
  selector : "detailComponent",
  templateUrl : "detail-contact.component.html"
})
export class DetailContactComponent {

  contact : Contact;

  constructor(private route : ActivatedRoute, private http : HttpClient){
      const id = route.snapshot.params.id;
      let urlApiAgenda = "http://localhost:58721";
      http.get(urlApiAgenda + "/contact/"+id).subscribe((res)=> {
        this.contact = <Contact>res;
      })
  }
 
}
