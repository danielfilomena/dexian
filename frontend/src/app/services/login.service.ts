import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { UsuarioModel } from '../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  url = environment.urlApi;

  constructor(private http: HttpClient) { }

  autenticarUsuario(usuario: UsuarioModel) : Observable<any> {

    return this.http.post<any>(this.url + "usuario/login", usuario);

  }

}
