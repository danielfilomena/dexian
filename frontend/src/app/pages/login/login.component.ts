import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { UsuarioModel } from '../../models/usuario';
import { LoginService } from '../../services/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  standalone: false,
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @ViewChild("form") form?: NgForm;

  loginViewModel: UsuarioModel = new UsuarioModel();

  constructor(private loginService: LoginService, private router: Router) { }

  ngOnInit() {
  }

  onLogin() {

    this.loginService.autenticarUsuario(this.loginViewModel).subscribe(result => {
      sessionStorage.setItem("token", result.token);
      this.router.navigate(["dashboard"]);
    });

  }

}
