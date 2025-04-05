import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, GuardResult, MaybeAsync, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

import { AppSessionService } from './app-session.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

constructor(private appSession: AppSessionService, private router: Router) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {

    if(this.appSession.temToken()) {
      return true;
    }

    this.router.navigate(["/login"]);
    return false;

  }

}
