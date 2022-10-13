import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-contact-page',
  templateUrl: './contact-page.component.html',
  styleUrls: ['./contact-page.component.css']
})
export class ContactPageComponent implements OnInit {

  contactForm: FormGroup = this.formBuilder.group({
    name: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(30)]),
    email: new FormControl('', [Validators.required]),
    subject: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]),
    content: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(1000)])
  })

  constructor(private userService: UserService, private formBuilder: FormBuilder, private router: Router, private toastrService: ToastrService) { }

  ngOnInit(): void {
  }

  contactUs() :void{
    this.userService.contact$(this.contactForm.value).subscribe({
      next: () => {
        this.toastrService.success('Sent');
        this.router.navigate(['/']);
      },
      error: () => {
        this.router.navigate(['/islands']);
      }
    })
  }

  cancelChanges(): void{
    this.toastrService.info('Cancelled');
    this.router.navigate(['/islands']);
  }
}
