import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateislandComponent } from './createisland/createisland.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IslandsRoutingModule } from './islands-routing.module';
import { ListIslandsComponent } from './list-islands/list-islands.component';
import { IslandDetailsComponent } from './island-details/island-details.component';
import { EditIslandComponent } from './edit-island/edit-island.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { AdminIslandComponent } from './admin-island/admin-island.component';
import { PartnerIslandsComponent } from './partner-islands/partner-islands.component';


@NgModule({
  declarations: [
    CreateislandComponent,
    ListIslandsComponent,
    IslandDetailsComponent,
    EditIslandComponent,
    AdminIslandComponent,
    PartnerIslandsComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    IslandsRoutingModule,
    FormsModule,
    SweetAlert2Module.forRoot()
  ]
})
export class IslandsModule { }
