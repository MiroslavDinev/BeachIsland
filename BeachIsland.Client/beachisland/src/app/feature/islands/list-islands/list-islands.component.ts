import { Component, OnInit } from '@angular/core';
import { IslandService } from 'src/app/services/island.service';
import { IIslandItem } from '../../interfaces/IIslandItem';

@Component({
  selector: 'app-list-islands',
  templateUrl: './list-islands.component.html',
  styleUrls: ['./list-islands.component.css']
})
export class ListIslandsComponent implements OnInit {

  islands: IIslandItem[];
  constructor(private islandService: IslandService) { }

  ngOnInit(): void {
    this.islandService.getIslands$().subscribe(islands =>{
      this.islands = islands;
    })
  }

}
