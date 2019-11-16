import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ErrorPageComponent } from "./common/error-page/error-page.component";
import { AuthorizeGuard } from '../api-authorization/authorize.guard';

import { HomeComponent } from './common/home/home.component';

import { GuidanceComponent } from './guidance/guidance.component';
import { GuidanceHomeComponent } from './guidance/guidance-home.component';
import { CounterComponent } from './guidance/counter/counter.component';
import { FetchDataComponent } from './guidance/fetch-data/fetch-data.component';

import { RecordComponent } from './record/record.component';
import { CommutesComponent } from './commutes/commutes.component';
import { StartComponent } from './record/start/start.component';
import { StopComponent } from './record/stop/stop.component';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    {
        path: 'record', component: RecordComponent, canActivate: [AuthorizeGuard],
        children: [
            { path: 'start', component: StartComponent },
            { path: 'stop', component: StopComponent }
        ]
    },
    { path: 'commutes', component: CommutesComponent, canActivate: [AuthorizeGuard] },
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
