import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

loginForm: FormGroup = this.formBuilder.group({
  username: new FormControl('',[Validators.required, Validators.minLength(4)]),
  password: new FormControl('',[Validators.required, Validators.minLength(6)])
});

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router: Router, private toastrService: ToastrService) { }

  ngOnInit(): void {
  }

  login() :void{
    this.authService.login$(this.loginForm.value).subscribe(data =>{
      this.authService.saveToken(data);
      this.authService.saveUsername(data);
      this.authService.savePartnerStatus(data);
      this.authService.saveAdminStatus(data);
      this.toastrService.info('Logged in successfully');
      this.router.navigate(['/']);
    })
  }

  isLoggedIn(){
    return this.authService.isAuthenticated();
  }
}
