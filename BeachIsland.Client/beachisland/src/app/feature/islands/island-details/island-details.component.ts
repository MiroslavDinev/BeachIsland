import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IslandService } from 'src/app/services/island.service';
import { IIslandDetails } from '../../interfaces/IIslandDetails';

@Component({
  selector: 'app-island-details',
  templateUrl: './island-details.component.html',
  styleUrls: ['./island-details.component.css']
})
export class IslandDetailsComponent implements OnInit {

  id: any;
  island: IIslandDetails;

  constructor(private islandService: IslandService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(res =>{
      this.id = res['id'];
      this.islandService.getIslandDetails$(this.id).subscribe(island =>{
        this.island = island;
      })
    })
  }

}
