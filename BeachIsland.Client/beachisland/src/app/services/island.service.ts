import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class IslandService {

  private createIslandPath = environment.apiBaseUrl + 'islands/addisland';

  constructor(private http: HttpClient) { }

  createIsland(formData: FormData) :Observable<any>{
    return this.http.post(this.createIslandPath, formData);
  }
}
