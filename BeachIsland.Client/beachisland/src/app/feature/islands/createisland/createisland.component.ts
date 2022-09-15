import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IslandService } from 'src/app/services/island.service';

@Component({
  selector: 'app-createisland',
  templateUrl: './createisland.component.html',
  styleUrls: ['./createisland.component.css']
})
export class CreateislandComponent implements OnInit {

  public formData = new FormData();

  islandForm: FormGroup = this.formBuilder.group({
    name: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(30)]),
    location: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    description: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(3000)]),
    size: new FormControl('', [Validators.required]),
    price : new FormControl(''),
    populationSizeId: new FormControl('',[Validators.required]),
    islandRegionId: new FormControl('',[Validators.required])
  })

  constructor(private formBuilder: FormBuilder, private islandService: IslandService, private router: Router) { }

  ngOnInit(): void {
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
        this.router.navigate(['islands']);
      },
      error: (err) =>{
        console.log(err);
      }
    }
    )
  }

  cancelChanges(){
    this.router.navigate(['/']);
  }
}
