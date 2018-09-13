import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { IUserCodeAward } from "./winners-list.model";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class WinnersListService {

    winnersUrl: string = 'http://localhost:52586/api/lottery/'
    constructor(private _http: HttpClient) {

    }


    getAllWinners(): Observable<Array<IUserCodeAward>> {
        return this._http.get<Array<IUserCodeAward>>(this.winnersUrl + "getAllWinners");
    }
}