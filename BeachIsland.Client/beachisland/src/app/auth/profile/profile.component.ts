import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/user.service';
import { IUserProfile } from '../interfaces/IUserProfile';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  userProfile: IUserProfile;

  profileForm: FormGroup = this.formBuilder.group({
    nickname: new FormControl('', [Validators.minLength(2), Validators.maxLength(30)]),
    occupationalField: new FormControl('', [Validators.minLength(3), Validators.maxLength(30)])
  });

  constructor(private userService: UserService, private router: Router, private formBuilder: FormBuilder, private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.userService.getProfile$().subscribe({
      next: (user) =>{
        this.userProfile = user;
      },
      error: () => {
        this.router.navigate(['login']);
      }
    })
  }

  updateProfile() {
    this.userService.updateProfile$(this.profileForm.value).subscribe({
      next: (data) =>{
        this.toastrService.info('Profile updated');
        this.router.navigate(['/']);
      },
      error: (err) =>{
        console.error(err);
      }
    })
  }

  cancelChanges() {
    this.toastrService.info('Cancelled');
    this.router.navigate(['/']);
  }
}
