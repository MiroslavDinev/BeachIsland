import { RouterModule, Routes } from '@angular/router';
import { FaqPageComponent } from './feature/pages/faq-page/faq-page.component';
import { HomePageComponent } from './feature/pages/home-page/home-page.component';
import { PageNotFoundComponent } from "./feature/pages/page-not-found/page-not-found.component";
import { PrivacyPageComponent } from './feature/pages/privacy-page/privacy-page.component';

const routes: Routes = [
  {
    path:'',
    pathMatch: 'full',
    redirectTo: 'home'
  },
  {
    path: 'home',
    component: HomePageComponent
  },
  {
    path: 'privacy',
    component: PrivacyPageComponent
  },
  {
    path: 'faq',
    component: FaqPageComponent
  },
  {
    path: '**',
    component: PageNotFoundComponent
  }
];

export const AppRoutingModule = RouterModule.forRoot(routes);
