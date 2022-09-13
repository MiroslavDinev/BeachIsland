import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateislandComponent } from './createisland/createisland.component';
import { ReactiveFormsModule } from '@angular/forms';
import { IslandsRoutingModule } from './islands-routing.module';



@NgModule({
  declarations: [
    CreateislandComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    IslandsRoutingModule
  ]
})
export class IslandsModule { }
