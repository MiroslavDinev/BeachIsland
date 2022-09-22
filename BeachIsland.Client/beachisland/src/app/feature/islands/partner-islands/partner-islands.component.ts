import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IslandService } from 'src/app/services/island.service';
import Swal from 'sweetalert2';
import { IPartnerOwnIslandItem } from '../../interfaces/IPartnerOwnIslandItem';

@Component({
  selector: 'app-partner-islands',
  templateUrl: './partner-islands.component.html',
  styleUrls: ['./partner-islands.component.css']
})
export class PartnerIslandsComponent implements OnInit {

  partnerIslands: IPartnerOwnIslandItem[];

  constructor(private islandsService: IslandService, private router: Router) { }

  ngOnInit(): void {
    this.fetchPartnerIslands();
  }

  fetchPartnerIslands(){
    this.islandsService.getPartnerIslands$().subscribe(partnerIslands => {
      this.partnerIslands = partnerIslands;
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
    this.islandsService.deleteIsland$(id).subscribe(res => {
      this.fetchPartnerIslands();
    })
  }

  cancelChanges(){
    this.router.navigate(['partner/islands']);
  }
}
