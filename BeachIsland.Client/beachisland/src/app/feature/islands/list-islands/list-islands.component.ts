import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime, startWith, switchMap } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';
import { IslandService } from 'src/app/services/island.service';
import { IIslandItem } from '../../interfaces/IIslandItem';

@Component({
  selector: 'app-list-islands',
  templateUrl: './list-islands.component.html',
  styleUrls: ['./list-islands.component.css']
})
export class ListIslandsComponent implements OnInit {

  islands: IIslandItem[];
  p: number = 1;

  searchControl= new FormControl();

  constructor(private islandService: IslandService, private authService: AuthService) { }

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

  isPartner(){
    return this.authService.getPartnerStatus();
  }
}
