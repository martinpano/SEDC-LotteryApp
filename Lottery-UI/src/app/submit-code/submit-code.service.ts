import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from "rxjs";
import { IUserCode, ICode, IAward } from '../winners-list/winners-list.model';

@Injectable({
  providedIn: 'root'
})


export class SubmitCodeService {

  lotteryUrl: string = "http://localhost:52586/api/lottery/";

  constructor(private _http: HttpClient){

  }

  submitCode(userCode: IUserCode): Observable<IAward>{
    return this._http.post<IAward>(this.lotteryUrl + 'submitCode', userCode);
  }

}
