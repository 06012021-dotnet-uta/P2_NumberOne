import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LoggerModule, NgxLoggerLevel } from "ngx-logger";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { CustomerComponent } from './customer/customer.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { Globals } from './globals';
import { LoginFormComponent } from './login-form/login-form.component';
import { ForumPostsListComponent } from './forum-posts-list/forum-posts-list.component';
import { ForumPostsListItemComponent } from './forum-posts-list-item/forum-posts-list-item.component';
import { ForumPostFormComponent } from './forum-post-form/forum-post-form.component';
import { OlCoordMapComponent } from './ol-coord-map/ol-coord-map.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    LoginComponent,
    CustomerComponent,
    SignUpComponent,
    LoginFormComponent,
    ForumPostsListComponent,
    ForumPostsListItemComponent,
    ForumPostFormComponent,
    OlCoordMapComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    LoggerModule.forRoot({serverLoggingUrl: '/api/logs', level: NgxLoggerLevel.DEBUG, serverLogLevel: NgxLoggerLevel.ERROR}),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent, Globals]
})
export class AppModule { }
