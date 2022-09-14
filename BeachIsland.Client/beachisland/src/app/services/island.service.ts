import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IIslandItem } from '../feature/interfaces/IIslandItem';

@Injectable({
  providedIn: 'root'
})
export class IslandService {

  private createIslandPath = environment.apiBaseUrl + 'islands/addisland';
  private getIslandsPath = environment.apiBaseUrl + 'islands/all';

  constructor(private http: HttpClient) { }

  createIsland(formData: FormData) :Observable<any>{
    return this.http.post(this.createIslandPath, formData);
  }

  getIslands() :Observable<IIslandItem[]>{
    return this.http.get<IIslandItem[]>(this.getIslandsPath);
  }
}
