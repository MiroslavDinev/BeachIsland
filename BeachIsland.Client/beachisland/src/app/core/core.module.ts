import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from './user.service';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [ 
    HeaderComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    HeaderComponent
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
