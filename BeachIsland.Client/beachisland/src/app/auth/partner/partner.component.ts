import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/user.service';

@Component({
  selector: 'app-partner',
  templateUrl: './partner.component.html',
  styleUrls: ['./partner.component.css']
})
export class PartnerComponent implements OnInit {

  errorMessage: string = '';

  partnerForm: FormGroup = this.formBuilder.group({
    name: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(30)]),
    phoneNumber: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(20)])
  });

  constructor(private formBuilder: FormBuilder, private userService: UserService, private router: Router) { }

  ngOnInit(): void {
  }

  becomePartner() :void{
    this.userService.becomePartner$(this.partnerForm.value).subscribe({
      next: () =>{
        localStorage.setItem('isPartner', JSON.stringify(true));
        this.router.navigate(['/']);
      },
      error: (err) =>{
        this.errorMessage = err.error.message;
      }
    })
  }

}
