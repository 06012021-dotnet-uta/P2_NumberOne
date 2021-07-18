import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { CustomerComponent } from './customer/customer.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { GenderComponent } from './gender/gender.component';
import { CategoryComponent } from './category/category.component';
import { AggressionComponent } from './aggression/aggression.component';
import { PetRegistrationComponent } from './pet-registration/pet-registration.component';
import { ForumComponent } from './forum/forum.component';

const routes: Routes = 
[
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'login', component: LoginComponent },
  { path: 'customer', component: CustomerComponent },
  { path: 'sign-up', component: SignUpComponent },
  { path: 'gender', component: GenderComponent },
  { path: 'category', component: CategoryComponent },
  { path: 'aggression', component: AggressionComponent },
  { path: 'pet-registration', component: PetRegistrationComponent },
  { path: 'forum', component: ForumComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
