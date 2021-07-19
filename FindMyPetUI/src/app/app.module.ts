import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LoggerModule, NgxLoggerLevel } from "ngx-logger";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { Ng2OrderModule } from 'ng2-order-pipe';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { CustomerComponent } from './customer/customer.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { Globals } from './globals';
import { LoginFormComponent } from './login-form/login-form.component';
import { GenderComponent } from './gender/gender.component';
import { CategoryComponent } from './category/category.component';
import { AggressionComponent } from './aggression/aggression.component';
import { PetRegistrationComponent } from './pet-registration/pet-registration.component';
import { ForumHeaderComponent } from './forum-header/forum-header.component';
import { ForumComponent } from './forum/forum.component';
import { ForumListComponent } from './forum-list/forum-list.component';
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
    GenderComponent,
    CategoryComponent,
    AggressionComponent,
    PetRegistrationComponent,
    ForumHeaderComponent,
    ForumComponent,
    ForumListComponent,
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
    HttpClientModule,
    NgbModule,
    Ng2OrderModule,
    Ng2SearchPipeModule,
    NgxPaginationModule
    
  ],
  providers: [],
  bootstrap: [AppComponent, Globals]
})
export class AppModule { }
