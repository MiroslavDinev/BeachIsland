import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IUserLogin } from '../core/interfaces/IUserLogin';
import { IUserRegister } from '../core/interfaces/IUserRegister';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loginPath = environment.apiBaseUrl + 'identity/login';
  private registerPath = environment.apiBaseUrl + 'identity/register';

  constructor(private http: HttpClient) { }

  login$(data: IUserLogin) :Observable<IUserLogin>{
    return this.http.post<IUserLogin>(this.loginPath, data);
  }

  register$(data: IUserRegister): Observable<IUserRegister>{
    return this.http.post<IUserRegister>(this.registerPath, data);
  }
}
