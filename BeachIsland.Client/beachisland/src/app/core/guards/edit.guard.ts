import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class EditGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router, private toastrService: ToastrService) { }

  canActivate() :boolean{
    if(this.authService.getPartnerStatus() || this.authService.getAdminStatus()){
      return true;
    }else{
      this.toastrService.info('Unsufficient user privileges!');
      this.router.navigate(['/']);        
      return false;
    }
  }
  
}
