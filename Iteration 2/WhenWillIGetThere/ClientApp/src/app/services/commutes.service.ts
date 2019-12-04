import { Injectable, Inject } from '@angular/core';
import { Route } from '../models/route';
import { Commute } from '../models/commute';
import { HttpClient } from '@angular/common/http';
import { Routes } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CommutesService {
    private _routes: Route[];
    //private _routes: Route[] = [
    //    new Route(1, 'b1b42c1f-28bc-40b1-b8ec-1be3bf0c0a62', '<Default>')
    //];
    private _commutes: Commute[];
    //private _commutes: Commute[] = [
    //    new Commute(1, 1, new Date(2019, 11, 11, 9, 0, 0), new Date(2019, 11, 11, 9, 5, 0)),
    //    new Commute(2, 1, new Date(2019, 11, 11, 10, 5, 0), new Date(2019, 11, 11, 10, 7, 0)),
    //    new Commute(3, 1, new Date(2019, 11, 11, 12, 0, 0), null)
    //];
    private _user: string;
    private _appUrl: string = "";

    constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._appUrl = baseUrl;
    }  

    get routes(): Route[] {
        return this._routes.slice();
    }

    get commutes(): Commute[] {
        return this._commutes.slice();
    }

    refresh() {
        this.refreshRoutes();
        this.refreshCommutes();
    }

    refreshRoutes() {
        this._http.get<Route[]>(this._appUrl + 'api/Routes').subscribe(result => {
            this._routes = result;
        }, error => console.error(error));
    }

    refreshCommutes() {
        this._http.get<Commute[]>(this._appUrl + 'api/Commutes').subscribe(result => {
            this._commutes = result;
        }, error => console.error(error));
    }

    setUser(user: string) {
        this._user = user;
    }
}
