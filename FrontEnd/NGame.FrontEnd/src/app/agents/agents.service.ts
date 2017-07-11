import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams  } from '@angular/http';
import 'rxjs/add/operator/map'
import { Observable } from 'rxjs/Observable';
import { ACTION_URL } from '../providers/ngame.service';

@Injectable()
export class AgentsService {

  constructor(private http: Http) {
    console.log(ACTION_URL);
  }

  public GetByID = (id: string): Observable<any> => {
    return this.http.get(ACTION_URL + 'agents/' + id)
    .map((response: Response) => <any>response.json());
  }

  public GetMasterAgents = (id: string, type: string): Observable<any> => {
    let params: URLSearchParams = new URLSearchParams();
    params.set('type', type);
    let options: RequestOptions = new RequestOptions({
      search: params
    });

    return this.http.get(ACTION_URL + 'agents/' + id + '/masteragents', options)
    .map((response: Response) => <any>response.json());
  }

  public GetSettings = (id: string, type: string): Observable<any> => {
    let params: URLSearchParams = new URLSearchParams();
    params.set('type', type);
    let options: RequestOptions = new RequestOptions({
      search: params
    });

    return this.http.get(ACTION_URL + 'agents/' + id + '/settings', options)
    .map((response: Response) => <any>response.json());
  }

}
