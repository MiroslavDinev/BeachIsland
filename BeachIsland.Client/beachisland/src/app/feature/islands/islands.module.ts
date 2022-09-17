import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateislandComponent } from './createisland/createisland.component';
import { ReactiveFormsModule } from '@angular/forms';
import { IslandsRoutingModule } from './islands-routing.module';
import { ListIslandsComponent } from './list-islands/list-islands.component';
import { IslandDetailsComponent } from './island-details/island-details.component';
import { EditIslandComponent } from './edit-island/edit-island.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';



@NgModule({
  declarations: [
    CreateislandComponent,
    ListIslandsComponent,
    IslandDetailsComponent,
    EditIslandComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    IslandsRoutingModule,
    SweetAlert2Module.forRoot()
  ]
})
export class IslandsModule { }
