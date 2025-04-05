import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppSessionService } from '../../services/app-session.service';

@Component({
  selector: 'app-navBar',
  templateUrl: './navBar.component.html',
  standalone: false,
  styleUrls: ['./navBar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(private router: Router, private appSession: AppSessionService) { }

  ngOnInit() {
  }

  onLogoff() {

    this.appSession.limparSession();
    this.router.navigate(["login"]);

  }

}
