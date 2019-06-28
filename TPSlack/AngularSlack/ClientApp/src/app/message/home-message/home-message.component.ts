import { Component, OnInit } from "@angular/core";
import { Message } from "../IMessage"
import { ApiService } from "../../services/api.service"
import { Subject } from "rxjs";
import { WebSocketService } from "../../services/websocket.service";
@Component({
  selector: "home-message",
  templateUrl: "home-message.component.html"
})
export class HomeMessageComponent implements OnInit {
  messages: any;
  constructor(private api: ApiService, private socket: WebSocketService) {
    
  }

  ngOnInit()  {
    this.api.get('message').subscribe((res : any) => {
      if (res.unauthorized != 401) {
        this.messages = <any>res.messages;
    
      }
      else {
        console.dir("tu n'as pas le droit d'etre ici");
      }
    }, (err) => {
      })

    this.api.MessageSubject.subscribe(newMessage => {
      this.messages.unshift(newMessage);
    });

    this.socket.get((newMessage) => {
      this.messages.unshift(newMessage);
    })

  }
}
