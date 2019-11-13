import { Injectable } from '@angular/core';
import { Route } from '../models/route';
import { Commute } from '../models/commute';

@Injectable({
  providedIn: 'root'
})
export class CommutesService {
    private _routes: Route[] = [
        new Route(1, 'b1b42c1f-28bc-40b1-b8ec-1be3bf0c0a62', '<Default>')
    ];
    private _commutes: Commute[] = [
        new Commute(1, 1, new Date(2019, 11, 11, 9, 0, 0), new Date(2019, 11, 11, 9, 5, 0)),
        new Commute(2, 1, new Date(2019, 11, 11, 10, 5, 0), new Date(2019, 11, 11, 10, 7, 0)),
        new Commute(3, 1, new Date(2019, 11, 11, 11, 0, 0), null)
    ];
    private _user: string;

    constructor() { }

    get routes(): Route[] {
        return this._routes.slice();
    }

    get commutes(): Commute[] {
        return this._commutes.slice();
    }

    setUser(user: string) {
        this._user = user;
    }
}
