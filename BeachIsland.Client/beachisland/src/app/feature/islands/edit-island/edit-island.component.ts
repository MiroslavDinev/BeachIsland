import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { map, mergeMap } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';
import { IslandService } from 'src/app/services/island.service';
import { IIslandDetails } from '../../interfaces/IIslandDetails';
import { IIslandRegions } from '../../interfaces/IIslandRegions';
import { IIslandSizes } from '../../interfaces/IIslandSizes';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-island',
  templateUrl: './edit-island.component.html',
  styleUrls: ['./edit-island.component.css']
})
export class EditIslandComponent implements OnInit {

  public formData = new FormData();

  islandForm: FormGroup;
  id: any;
  island: IIslandDetails;
  islandSizes : IIslandSizes[];
  islandRegions: IIslandRegions[];

  constructor(private formBuilder: FormBuilder, private route: ActivatedRoute, private islandService: IslandService, private router: Router, private authService: AuthService, private toastrService: ToastrService) { 
    this.islandForm = this.formBuilder.group({
      'id' : [''],
      name: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(30), Validators.pattern(/^[A-Za-z\s]*$/)]),
      location: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50), Validators.pattern(/^[A-Za-z\s]*$/)]),
      description: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(3000)]),
      size: new FormControl('', [Validators.required]),
      price : new FormControl(''),
      populationSizeId: new FormControl('',[Validators.required]),
      islandRegionId: new FormControl('',[Validators.required])
    })
  }

  ngOnInit(): void {
    this.getRegions();
    this.getSizes();
    this.fetchData();
  }

  fetchData() {
    this.route.params.pipe(map(params =>{
      const id = params['id'];
      return id
    }), mergeMap(id => this.islandService.getIslandDetails$(id))).subscribe(res => {
      this.island = res;
        this.islandForm = this.formBuilder.group({
          'id' : [this.island.id],
          name: [this.island.name],
          location: [this.island.location],
          description: [this.island.description],
          size: [this.island.size],
          price : [this.island.price],
          populationSizeId: [this.island.populationSizeId],
          islandRegionId: [this.island.islandRegionId]
    })
  })
  }

  uploadFiles(file: any) {
    for (let i = 0; i < file.length; i++) {
      this.formData.append("file", file[i], file[i]['name']); 
    }
  }

  cancelChanges(){
    this.toastrService.info('Cancelled');
    this.router.navigate(['islands']);
  }

  editIsland(){
    this.formData.append('details', JSON.stringify(this.islandForm.value));
    this.islandService.editIsland$(this.formData).subscribe({
      next: () =>{
        if(this.getPartnerStatus()){
          this.toastrService.success('Island successfully edited. Pending administrator approval.');
          this.router.navigate(['partner/islands']);
        }
        else{
          this.toastrService.success('Island successfully edited.');
          this.router.navigate(['islands']);
        }
      },
      error: () =>{
        this.formData.delete('file');
      }     
    })
  }

  getSizes() {
    this.islandService.getSizes$().subscribe(sizes => {
      this.islandSizes = sizes;
    })
  }

  getRegions() {
    this.islandService.getRegions$().subscribe(regions => {
      this.islandRegions = regions;
    })
  }

  getPartnerStatus(){
    return this.authService.getPartnerStatus();
  }
}
