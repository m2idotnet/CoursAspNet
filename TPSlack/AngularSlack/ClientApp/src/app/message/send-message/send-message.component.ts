import { Component } from "@angular/core"
import { ApiService } from "../../services/api.service"
import { WebSocketService } from "src/app/services/websocket.service";
@Component({
  selector: 'send-message',
  templateUrl: 'send-message.component.html'
})
export class SendMessageComponent {
  message: any
  constructor(private api: ApiService, private socket: WebSocketService) {

  }

  send() {
    this.api.post('message', { 'Content': this.message }).subscribe((res:any) => {
      this.api.emit(res.message);
      this.socket.send(res.message);
    })
  }
}
