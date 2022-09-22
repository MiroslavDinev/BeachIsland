import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IslandService } from 'src/app/services/island.service';
import { IIslandItem } from '../../interfaces/IIslandItem';

@Component({
  selector: 'app-list-islands',
  templateUrl: './list-islands.component.html',
  styleUrls: ['./list-islands.component.css']
})
export class ListIslandsComponent implements OnInit {

  islands: IIslandItem[];
  constructor(private islandService: IslandService, private router: Router) { }

  ngOnInit(): void {
    this.fetchIslands();
  }

  fetchIslands(){
    this.islandService.getIslands$().subscribe(islands =>{
      this.islands = islands;
    })
  }
}
