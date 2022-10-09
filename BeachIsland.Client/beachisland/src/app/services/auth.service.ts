import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAuthenticatedResponse } from '../core/interfaces/IAuthenticatedResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loginPath = environment.apiBaseUrl + 'identity/login';
  private registerPath = environment.apiBaseUrl + 'identity/register';

  constructor(private http: HttpClient, private router: Router) { }

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

  saveUsername(response :IAuthenticatedResponse){
    localStorage.setItem('username', response.username);
  }

  getUsername() {
    return localStorage.getItem('username');
  }

  savePartnerStatus(response :IAuthenticatedResponse){
    localStorage.setItem('isPartner', JSON.stringify(response.isPartner));
  }

  getPartnerStatus(){
    return JSON.parse(localStorage.getItem('isPartner')!);
  }

  saveAdminStatus(response :IAuthenticatedResponse){
    localStorage.setItem('isAdmin', JSON.stringify(response.isAdmin));
  }

  getAdminStatus(){
    return JSON.parse(localStorage.getItem('isAdmin')!);
  }

  logout() :void{
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    localStorage.removeItem('isPartner');
    this.router.navigate(['home']);
  }

  isAuthenticated() :boolean{
    if(this.getToken()){
      return true;
    }
    return false;
  }
}
