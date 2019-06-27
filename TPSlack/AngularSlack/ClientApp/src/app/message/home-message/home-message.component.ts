import { Component, OnInit } from "@angular/core";
import { Message } from "../IMessage"
import { ApiService } from "../../services/api.service"
@Component({
  selector: "home-message",
  templateUrl: "home-message.component.html"
})
export class HomeMessageComponent implements OnInit {
  messages: Message[];
  constructor(private api: ApiService) {
    
  }

  ngOnInit()  {
    this.api.get('message').subscribe((res) => {
      if (res.unauthorized != 401) {
        this.messages = <Message[]>res.messages;
      }
      else {
        console.dir("tu n'as pas le droit d'etre ici");
      }
    }, (err) => {
      //console.dir(err);
    })
  }
}
