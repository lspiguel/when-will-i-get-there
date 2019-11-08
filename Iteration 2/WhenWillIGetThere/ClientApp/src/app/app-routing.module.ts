import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ErrorPageComponent } from "./common/error-page/ErrorPageComponent";

import { HomeComponent } from './common/home/home.component';

import { GuidanceComponent } from './guidance/guidance.component';
import { GuidanceHomeComponent } from './guidance/guidance-home.component';
import { CounterComponent } from './guidance/counter/counter.component';
import { FetchDataComponent } from './guidance/fetch-data/fetch-data.component';

import { AuthorizeGuard } from '../api-authorization/authorize.guard';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    {
        path: 'guidance', component: GuidanceComponent,
        children: [
            { path: '', component: GuidanceHomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
        ]
    },
    { path: 'not-found', component: ErrorPageComponent, data: { message: 'Page not found!' } },
    { path: '**', redirectTo: '/not-found' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
