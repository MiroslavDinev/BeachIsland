import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IslandService } from 'src/app/services/island.service';
import { IIslandRegions } from '../../interfaces/IIslandRegions';
import { IIslandSizes } from '../../interfaces/IIslandSizes';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-createisland',
  templateUrl: './createisland.component.html',
  styleUrls: ['./createisland.component.css']
})
export class CreateislandComponent implements OnInit {

  public formData = new FormData();

  islandSizes : IIslandSizes[];
  islandRegions: IIslandRegions[];

  islandForm: FormGroup = this.formBuilder.group({
    name: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(30)]),
    location: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    description: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(3000)]),
    size: new FormControl('', [Validators.required]),
    price : new FormControl(''),
    populationSizeId: new FormControl('',[Validators.required]),
    islandRegionId: new FormControl('',[Validators.required])
  })

  constructor(private formBuilder: FormBuilder, private islandService: IslandService, private router: Router, private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.getRegions();
    this.getSizes();
    let defaultSizeId = 1;
    this.islandForm.controls['populationSizeId'].setValue(defaultSizeId);
    let defaultRegionId = 1;
    this.islandForm.controls['islandRegionId'].setValue(defaultRegionId);
  }

  uploadFiles(file: any) {
    for (let i = 0; i < file.length; i++) {
      this.formData.append("file", file[i], file[i]['name']); 
    }
  }

  createIsland() {
    this.formData.append('details', JSON.stringify(this.islandForm.value));
    this.islandService.createIsland$(this.formData).subscribe({
      next: () =>{
        this.toastrService.success('Island successfully added. Pending administrator approval.');
        this.router.navigate(['islands']);
      },
      error: (err) =>{
        this.formData.delete('file');
      }
    }
    )
  }

  cancelChanges(){
    this.toastrService.info('Cancelled');
    this.router.navigate(['/']);
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
