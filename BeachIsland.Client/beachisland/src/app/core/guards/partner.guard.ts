import { Injectable } from '@angular/core';
import { CanActivate, Router} from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class PartnerGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router, private toastrService: ToastrService) { }

  canActivate() :boolean{
    if(this.authService.getPartnerStatus()){
      return true;
    }else{
      this.toastrService.info('Only partners can access this functionality');
      if(this.authService.getAdminStatus()){
        this.router.navigate(['/']);
        return false;
      }
      this.router.navigate(['/partner']);
      return false;
    }
  }
  
}
