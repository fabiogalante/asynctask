import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
// import 'rxjs/add/operator/map';
// import 'rxjs/add/operator/catch';
// import 'rxjs/add/observable/throw';
import { Twitter } from '../model/Twitter';
import {BASE_URL} from '../app.module';
import {MostMentionsName} from '../Model/MostMentions';


@Injectable({
  providedIn: 'root'
})
export class TwitterservicesService {

  baseUrl = 'http://localhost:5000/';

  constructor(private _http: HttpClient) {

  }

  public obterMostRelevants() {
    return this._http.get<Twitter[]>(this.baseUrl + 'api/Twitter/most_relevants');
  }

  public obterMostMentions() {
    return this._http.get<MostMentionsName[]>(this.baseUrl + 'api/Twitter/most_mentions');
  }

}
