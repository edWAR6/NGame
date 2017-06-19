import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams  } from '@angular/http';
import 'rxjs/add/operator/map'
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AgentsService {
  private actionUrl: string;
  constructor(private http: Http) {
    this.actionUrl = 'http://localhost:50378/api/agents/';
  }

  public GetByID = (id: string): Observable<any> => {
    return this.http.get(this.actionUrl + id)
    .map((response: Response) => <any>response.json());
  }

  public GetMasterAgents = (id: string, type: string): Observable<any> => {
    let params: URLSearchParams = new URLSearchParams();
    params.set('type', type);
    let options: RequestOptions = new RequestOptions({
      search: params
    });

    return this.http.get(this.actionUrl + id + '/masteragents', options)
    .map((response: Response) => <any>response.json());
  }

}
