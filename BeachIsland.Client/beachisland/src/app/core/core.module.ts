import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from './user.service';



@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule
  ],
  exports: [

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
