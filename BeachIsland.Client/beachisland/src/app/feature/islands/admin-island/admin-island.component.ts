import { Component, OnInit } from '@angular/core';
import { IslandService } from 'src/app/services/island.service';
import { IIslandAdminItem } from '../../interfaces/IIslandAdminItem';

@Component({
  selector: 'app-admin-island',
  templateUrl: './admin-island.component.html',
  styleUrls: ['./admin-island.component.css']
})
export class AdminIslandComponent implements OnInit {

  adminIslands: IIslandAdminItem[];

  constructor(private islandService: IslandService) { }

  ngOnInit(): void {
    this.fetchAdminIslands();
  }

  fetchAdminIslands(){
    this.islandService.getAdminIslands$().subscribe(adminIslands => {
      this.adminIslands = adminIslands;
    })
  }

}
