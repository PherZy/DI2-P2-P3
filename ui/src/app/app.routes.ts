import { Routes } from '@angular/router';
import { PasswordListComponent } from './components/password-list/password-list.component';
import { AddPasswordComponent } from './components/add-password/add-password.component';
import { ApplicationListComponent } from './components/application-list/application-list.component';

export const routes: Routes = [
    {path: '', redirectTo: '/passwords', pathMatch: 'full'},
    {path: 'passwords', component: PasswordListComponent},
    {path: 'passwords/add', component: AddPasswordComponent},
    {path: 'applications', component: ApplicationListComponent},
    {path: '**', redirectTo: '/passwords'}
];
