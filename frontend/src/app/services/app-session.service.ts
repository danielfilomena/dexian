import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppSessionService {

  constructor() { }

  temToken() {
    return sessionStorage.getItem("token") != null;
  }

  limparSession() {
    sessionStorage.removeItem("token");
  }

  obterDadosSession() : Observable<string | null> {
    return of(sessionStorage.getItem("token"));
  }

}
