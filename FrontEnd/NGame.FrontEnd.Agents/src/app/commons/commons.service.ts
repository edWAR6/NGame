import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams  } from '@angular/http';
import 'rxjs/add/operator/map'
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CommonsService {
  private actionUrl: string;
  constructor(private http: Http) {
    // this.actionUrl = 'http://vweb01-dev:5591/NGameNAKAMA/api/commons/';
    this.actionUrl = 'http://ngamemiddleware.azurewebsites.net/api/commons/';
  }

  public GetSports = (): Observable<any> => {
    return this.http.get(this.actionUrl + '/sports')
    .map((response: Response) => <any>response.json());
  }
}
