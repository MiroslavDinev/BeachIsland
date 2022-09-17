import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IIslandDetails } from '../feature/interfaces/IIslandDetails';
import { IIslandItem } from '../feature/interfaces/IIslandItem';
import { IIslandRegions } from '../feature/interfaces/IIslandRegions';
import { IIslandSizes } from '../feature/interfaces/IIslandSizes';

@Injectable({
  providedIn: 'root'
})
export class IslandService {

  private islandsDetailsPath = environment.apiBaseUrl + 'islands/details';
  private createIslandPath = environment.apiBaseUrl + 'islands/addisland';
  private getIslandsPath = environment.apiBaseUrl + 'islands/all';
  private editIslandPath = environment.apiBaseUrl + 'islands/update';
  private getIslandSizesPath = environment.apiBaseUrl + 'islands/islandsizes';
  private getIslandRegionsPath = environment.apiBaseUrl + 'islands/islandregions';

  constructor(private http: HttpClient) { }

  createIsland$(formData: FormData) :Observable<any>{
    return this.http.post(this.createIslandPath, formData);
  }

  getIslands$() :Observable<IIslandItem[]>{
    return this.http.get<IIslandItem[]>(this.getIslandsPath);
  }

  getIslandDetails$(id: any) :Observable<IIslandDetails>{
    return this.http.get<IIslandDetails>(this.islandsDetailsPath + '/' + id);
  }

  editIsland$(formData: FormData) :Observable<any>{
    return this.http.put(this.editIslandPath, formData);
  }

  getSizes$() :Observable<IIslandSizes[]>{
    return this.http.get<IIslandSizes[]>(this.getIslandSizesPath);
  }

  getRegions$() :Observable<IIslandRegions[]>{
    return this.http.get<IIslandRegions[]>(this.getIslandRegionsPath);
  }
}
