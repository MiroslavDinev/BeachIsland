import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup = this.formBuilder.group({
    username: new FormControl('', [Validators.required, Validators.minLength(4)]),
    email: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    // pswRepeat: new FormControl('',[Validators.required])
  })

  constructor(private formBuilder: FormBuilder, private authService: AuthService) { }

  ngOnInit(): void {
  }

  register(): void{
    this.authService.register$(this.registerForm.value).subscribe(data => {
      console.log(data)
    })
  }
}
