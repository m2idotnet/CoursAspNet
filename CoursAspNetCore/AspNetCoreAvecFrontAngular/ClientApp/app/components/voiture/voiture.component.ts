import { Component, Inject } from "@angular/core";
import { Http } from "@angular/http"
@Component({
    selector: "voiture",
    templateUrl : "voiture.component.html"
})
export class VoitureComponent {
    voitures: any;

    constructor(monHttp: Http, @Inject('BASE_URL') baseUrl: string) {
        monHttp.get(baseUrl + "/voiture").subscribe(res => {
            let result = res.json();
            this.voitures = result;
        })
    }
}