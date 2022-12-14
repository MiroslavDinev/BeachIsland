import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  logoutHandler() :void{
    this.authService.logout();
  }

  loggedIn(){
    return this.authService.getToken();
  }

  getUsername(){
    return this.authService.getUsername();
  }

  getPartnerStatus(){
    return this.authService.getPartnerStatus();
  }

  getAdminStatus(){
    return this.authService.getAdminStatus();
  }
}
