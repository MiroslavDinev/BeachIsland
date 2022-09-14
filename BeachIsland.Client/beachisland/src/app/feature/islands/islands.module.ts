import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateislandComponent } from './createisland/createisland.component';
import { ReactiveFormsModule } from '@angular/forms';
import { IslandsRoutingModule } from './islands-routing.module';
import { ListIslandsComponent } from './list-islands/list-islands.component';



@NgModule({
  declarations: [
    CreateislandComponent,
    ListIslandsComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    IslandsRoutingModule
  ]
})
export class IslandsModule { }
