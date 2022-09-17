import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IslandService } from 'src/app/services/island.service';
import Swal from 'sweetalert2';
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

  editIsland(id: number){
    this.router.navigate(["islands/" + id + "/update"]);
  }

  deleteIsland(id: number){
    Swal.fire(
      'Deleted!',
      'Your file has been deleted.',
      'success'
    )
    this.islandService.deleteIsland$(id).subscribe(res => {
      this.fetchIslands();
    })
  }

  cancelChanges(){
    this.router.navigate(['islands']);
  }
}
