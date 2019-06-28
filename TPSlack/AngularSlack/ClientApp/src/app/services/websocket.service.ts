import { Injectable } from "@angular/core";
import { Socket } from "ngx-socket-io";

@Injectable()
export class WebSocketService {
  
  constructor(private socket : Socket) {
   
  }

  send(message) {
    this.socket.emit('newMessage', message);
  }

  get(fonction) {
    this.socket.on('newMessage', fonction)
  }
}
