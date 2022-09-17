import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IslandService } from 'src/app/services/island.service';
import { IIslandDetails } from '../../interfaces/IIslandDetails';
import { IIslandRegions } from '../../interfaces/IIslandRegions';
import { IIslandSizes } from '../../interfaces/IIslandSizes';

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

  constructor(private formBuilder: FormBuilder, private route: ActivatedRoute, private islandService: IslandService, private router: Router) { 
    this.islandForm = this.formBuilder.group({
      'id' : [''],
      name: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(30)]),
      location: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
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
    this.route.params.subscribe(params =>{
      this.id = params['id'];
      this.islandService.getIslandDetails$(this.id).subscribe(res =>{
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
    })
  }

  uploadFiles(file: any) {
    for (let i = 0; i < file.length; i++) {
      this.formData.append("file", file[i], file[i]['name']); 
    }
  }

  cancelChanges(){
    this.router.navigate(['islands']);
  }

  editIsland(){
    this.formData.append('details', JSON.stringify(this.islandForm.value));
    this.islandService.editIsland$(this.formData).subscribe(res =>{
      this.router.navigate(['islands']);
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
}
