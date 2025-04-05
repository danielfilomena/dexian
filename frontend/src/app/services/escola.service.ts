import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { EscolaModel } from '../models/escola';

@Injectable({
  providedIn: 'root'
})
export class EscolaService {

  url = environment.urlApi;

  private isNew = new BehaviorSubject<number>(0);

  setIsNew(data: number) {
    this.isNew.next(data);
  }

  getIsNew() {
    return this.isNew.asObservable();
  }

  constructor(private http: HttpClient) { }

  list(token: string) : Observable<EscolaModel[]> {

    let headers = new HttpHeaders({
      Authorization: `bearer ${token}`
    });

    return this.http.get<EscolaModel[]>( this.url + "escola/list", { headers });

  }

  save(token: string, escola: EscolaModel) : Observable<boolean> {

    let headers = new HttpHeaders({
      Authorization: `bearer ${token}`
    });

    return this.http.post<boolean>(this.url + "escola", escola, { headers });

  }

  get(token: string, id: number) : Observable<EscolaModel> {

    let headers = new HttpHeaders({
      Authorization: `bearer ${token}`
    });

    let params = new HttpParams();
    params = params.set("id", id);

    return this.http.get<EscolaModel>(this.url + "escola", { headers, params });

  }

  delete(token: string, id: number) : Observable<boolean> {

    let headers = new HttpHeaders({
      Authorization: `bearer ${token}`
    });

    let params = new HttpParams();
    params = params.set("id", id);

    return this.http.delete<boolean>(this.url + "escola", { headers, params });

  }

}
