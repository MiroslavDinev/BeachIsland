import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, mergeMap } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';
import { IslandService } from 'src/app/services/island.service';
import Swal from 'sweetalert2';
import { IIslandDetails } from '../../interfaces/IIslandDetails';

@Component({
  selector: 'app-island-details',
  templateUrl: './island-details.component.html',
  styleUrls: ['./island-details.component.css']
})
export class IslandDetailsComponent implements OnInit {

  island: IIslandDetails;

  constructor(private islandService: IslandService, private route: ActivatedRoute, private authService: AuthService, private router: Router) { }

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

  getAdminStatus(){
    return this.authService.getAdminStatus();
  }

  changeStatus(id: any){
    this.islandService.changeIslandStatus$(id).subscribe(res => {
      this.router.navigate(['admin/islands']);
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
      this.router.navigate(['islands']);
    })
  }

  cancelChanges(){
    this.router.navigate(['islands']);
  }

  toggleDescription() {
    var x = document.getElementById("myDIV");
  if (x!.style.display === "none") {
    x!.style.display = "block";
  } else {
    x!.style.display = "none";
  }
  }
}
