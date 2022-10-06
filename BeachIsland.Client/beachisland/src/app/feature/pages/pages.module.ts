import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from './home-page/home-page.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ContactPageComponent } from './contact-page/contact-page.component';
import { ReactiveFormsModule } from '@angular/forms';
import { PrivacyPageComponent } from './privacy-page/privacy-page.component';
import { FaqPageComponent } from './faq-page/faq-page.component';



@NgModule({
  declarations: [
    HomePageComponent,
    PageNotFoundComponent,
    ContactPageComponent,
    PrivacyPageComponent,
    FaqPageComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports:[
    HomePageComponent
  ]
})
export class PagesModule { }
