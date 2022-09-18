import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map, mergeMap } from 'rxjs';
import { IslandService } from 'src/app/services/island.service';
import { IIslandDetails } from '../../interfaces/IIslandDetails';

@Component({
  selector: 'app-island-details',
  templateUrl: './island-details.component.html',
  styleUrls: ['./island-details.component.css']
})
export class IslandDetailsComponent implements OnInit {

  island: IIslandDetails;

  constructor(private islandService: IslandService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.fetchData();
  }

  fetchData() {
    this.route.params.pipe(map(params => {
      const id = params['id'];
      return id
    }), mergeMap(id => this.islandService.getIslandDetails$(id))).subscribe(res =>{
      this.island = res;
    })
  }
}
