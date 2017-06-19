import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams  } from '@angular/http';
import 'rxjs/add/operator/map'
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PlayersService {
  private actionUrl: string;
  constructor(private http: Http) {
    this.actionUrl = 'http://localhost:50378/api/players/';
  }

  // public GetByID = (id: string): Observable<any> => {
  //   return this.http.get(this.actionUrl + id)
  //   .map((response: Response) => <any>response.json());
  // }
}
