import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from '../services/user.service';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { FooterComponent } from './footer/footer.component';



@NgModule({
  declarations: [ 
    HeaderComponent, 
    FooterComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    HeaderComponent,
    FooterComponent
  ],
  providers: [

  ]
})
export class CoreModule { 
  static forRoot(): ModuleWithProviders<CoreModule>{
    return{
      ngModule: CoreModule,
      providers:[
        UserService
      ]
    }
  }
}
