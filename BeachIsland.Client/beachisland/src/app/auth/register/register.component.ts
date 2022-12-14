import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { IRegisterUser } from '../interfaces/IRegisterUser';
import { passwordMatch } from '../util';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  passwordControl = new FormControl('', [Validators.required, Validators.minLength(6)]);

  get passwordsGroup(): FormGroup {
    return this.registerForm.controls['passwords'] as FormGroup;
  }

  registerForm: FormGroup = this.formBuilder.group({
    username: new FormControl('', [Validators.required, Validators.minLength(4)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    passwords: new FormGroup({
      password: this.passwordControl,
      rePassword: new FormControl('',[passwordMatch(this.passwordControl)])
    })
  })

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router: Router, private toastrService: ToastrService) { }

  ngOnInit(): void {
  }

  shouldShowErrorForControl(controlName: string, sourceGroup: FormGroup = this.registerForm) {
    return sourceGroup.controls[controlName].touched && sourceGroup.controls[controlName].invalid
  }

  register(): void{

    const {username, email, passwords} = this.registerForm.value;

    const body: IRegisterUser = {
      Username: username,
      Email: email,
      Password : passwords.password
    }

    this.authService.register$(body).subscribe({
      next: () =>{
        this.toastrService.success('Registration success. Please login');
        this.router.navigate(['login']);
      },
      error: () =>{
        this.toastrService.error('Something went wrong, please try again later');
      }
    })
  }

  isLoggedIn(){
    return this.authService.isAuthenticated();
  }
}

