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

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { PagesModule } from '../pages/pages.module';


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
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatIconModule,
    PagesModule,
    SweetAlert2Module.forRoot()
  ]
})
export class IslandsModule { }
