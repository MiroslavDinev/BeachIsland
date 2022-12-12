import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthService } from './services/auth.service';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http'
import { CoreModule } from './core/core.module';
import { PagesModule } from './feature/pages/pages.module';
import { AuthModule } from './auth/auth.module';
import { RouterModule } from '@angular/router';
import { TokenInterceptor } from './core/token.interceptor';
import { HeaderComponent } from './core/header/header.component';
import { FooterComponent } from './core/footer/footer.component';
import { IslandsModule } from './feature/islands/islands.module';
import { IslandService } from './services/island.service';
import { NgxScrollTopModule } from 'ngx-scrolltop';
import { ErrorInterceptor } from './core/error.interceptor';
import { UserService } from './services/user.service';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    RouterModule,
    CoreModule,
    AppRoutingModule,
    PagesModule,
    AuthModule,
    IslandsModule,
    NgxScrollTopModule,
    ToastrModule.forRoot()
  ],
  providers: 
  [
    AuthService,
    IslandService,
    UserService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true,
    },
  ],
  bootstrap: 
  [
    AppComponent,
    HeaderComponent,
    FooterComponent
  ]
})
export class AppModule { }
