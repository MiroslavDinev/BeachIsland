import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

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

  constructor(private formBuilder: FormBuilder, private authService: AuthService) { }

  ngOnInit(): void {
  }

  login() :void{
    this.authService.login$(this.loginForm.value).subscribe(data =>{
      console.log(data)
    })
  }
}
