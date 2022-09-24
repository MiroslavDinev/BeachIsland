import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime, mergeMap, startWith, switchMap } from 'rxjs';
import { IslandService } from 'src/app/services/island.service';
import { IIslandItem } from '../../interfaces/IIslandItem';

@Component({
  selector: 'app-list-islands',
  templateUrl: './list-islands.component.html',
  styleUrls: ['./list-islands.component.css']
})
export class ListIslandsComponent implements OnInit {

  islands: IIslandItem[];

  searchControl= new FormControl();

  constructor(private islandService: IslandService) { }

  ngOnInit(): void {
    this.searchControl.valueChanges.pipe(
      startWith(''),
      debounceTime(300),
      switchMap(searchValue => this.islandService.getIslands$(searchValue))
      )
      .subscribe(islands =>{
        this.islands = islands;
    });
  }
}
