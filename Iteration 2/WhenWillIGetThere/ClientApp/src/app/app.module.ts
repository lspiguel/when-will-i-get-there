import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './common/nav-menu/nav-menu.component';
import { HomeComponent } from './common/home/home.component';
import { CounterComponent } from './guidance/counter/counter.component';
import { FetchDataComponent } from './guidance/fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { ErrorPageComponent } from "./common/error-page/error-page.component";
import { GuidanceHomeComponent } from './guidance/guidance-home.component';
import { GuidanceComponent } from './guidance/guidance.component';
import { CommutesComponent } from './commutes/commutes.component';
import { CommuteListComponent } from './commutes/commute-list/commute-list.component';
import { CommuteItemComponent } from './commutes/commute-item/commute-item.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    GuidanceComponent,
    GuidanceHomeComponent,
    CounterComponent,
    FetchDataComponent,
    CommutesComponent,
    CommuteListComponent,
    CommuteItemComponent,
    ErrorPageComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    AppRoutingModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
