import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateislandComponent } from './createisland/createisland.component';
import { ReactiveFormsModule } from '@angular/forms';
import { IslandsRoutingModule } from './islands-routing.module';
import { ListIslandsComponent } from './list-islands/list-islands.component';
import { IslandDetailsComponent } from './island-details/island-details.component';



@NgModule({
  declarations: [
    CreateislandComponent,
    ListIslandsComponent,
    IslandDetailsComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    IslandsRoutingModule
  ]
})
export class IslandsModule { }
