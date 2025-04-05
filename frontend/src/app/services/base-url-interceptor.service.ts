import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class BaseUrlInterceptor implements HttpInterceptor {

constructor(private router: Router) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const baseUrl = environment.urlApi;

    const apiReq = request.clone({ url: `${baseUrl}/${request.url}` });

    return next.handle(apiReq).pipe(
      tap({
        next: () => { },
        error: (err: any) => {
          if (err instanceof HttpErrorResponse) {
            if (err.status === 401) {
              this.router.navigate(['login']);
            }
          }
        }
      })
    );

  }

}
