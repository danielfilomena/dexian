import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { AlunoModel } from '../models/aluno';

@Injectable({
  providedIn: 'root'
})
export class AlunoService {

  url = environment.urlApi;

  private isNew = new BehaviorSubject<number>(0);

  setIsNew(data: number) {
    this.isNew.next(data);
  }

  getIsNew() {
    return this.isNew.asObservable();
  }

  constructor(private http: HttpClient) { }

  list(token: string) : Observable<AlunoModel[]> {

    let headers = new HttpHeaders({
      Authorization: `bearer ${token}`
    });

    return this.http.get<AlunoModel[]>( this.url + "aluno/list", { headers });

  }

  save(token: string, aluno: AlunoModel) : Observable<boolean> {

    let headers = new HttpHeaders({
      Authorization: `bearer ${token}`
    });

    return this.http.post<boolean>(this.url + "aluno", aluno, { headers });

  }

  get(token: string, id: number) : Observable<AlunoModel> {

    let headers = new HttpHeaders({
      Authorization: `bearer ${token}`
    });

    let params = new HttpParams();
    params = params.set("id", id);

    return this.http.get<AlunoModel>(this.url + "aluno", { headers, params });

  }

  delete(token: string, id: number) : Observable<boolean> {

    let headers = new HttpHeaders({
      Authorization: `bearer ${token}`
    });

    let params = new HttpParams();
    params = params.set("id", id);

    return this.http.delete<boolean>(this.url + "aluno", { headers, params });

  }

}
