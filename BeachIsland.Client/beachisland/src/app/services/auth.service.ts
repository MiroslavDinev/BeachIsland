import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAuthenticatedResponse } from '../core/interfaces/IAuthenticatedResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loginPath = environment.apiBaseUrl + 'identity/login';
  private registerPath = environment.apiBaseUrl + 'identity/register';

  constructor(private http: HttpClient) { }

  login$(data: IAuthenticatedResponse) :Observable<IAuthenticatedResponse>{
    return this.http.post<IAuthenticatedResponse>(this.loginPath, data);
  }

  register$(data: any): Observable<any>{
    return this.http.post(this.registerPath, data);
  }

  saveToken(response: IAuthenticatedResponse){
    localStorage.setItem('token', response.token);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  logout() :void{
    localStorage.removeItem('token');
  }

  isAuthenticated() :boolean{
    if(this.getToken()){
      return true;
    }

    return false;
  }
}
