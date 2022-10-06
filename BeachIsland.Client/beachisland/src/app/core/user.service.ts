import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IRegisterPartner } from '../auth/interfaces/IRegisterPartner';
import { IUpdateUserProfile } from '../auth/interfaces/IUpdateUserProfile';
import { IUserProfile } from '../auth/interfaces/IUserProfile';
import { IContactForm } from '../feature/interfaces/IContactForm';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private partnerPath = environment.apiBaseUrl + 'partner/becomepartner';
  private getProfilePath = environment.apiBaseUrl + 'identity/getprofile';
  private updateProfilePath = environment.apiBaseUrl + 'identity/updateprofile';
  private contactPath = environment.apiBaseUrl + 'contact/book';

  constructor(private http: HttpClient) { }

  becomePartner$(data: IRegisterPartner): Observable<any>{
    return this.http.post(this.partnerPath, data);
  }

  getProfile$(): Observable<IUserProfile>{
    return this.http.get<IUserProfile>(this.getProfilePath);
  }

  updateProfile$(data: IUpdateUserProfile) :Observable<string>{
    return this.http.post<string>(this.updateProfilePath, data);
  }

  contact$(data: IContactForm) :Observable<any>{
    return this.http.post(this.contactPath, data);
  }
}
