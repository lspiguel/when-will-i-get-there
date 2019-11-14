"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var error_page_component_1 = require("./common/error-page/error-page.component");
var authorize_guard_1 = require("../api-authorization/authorize.guard");
var home_component_1 = require("./common/home/home.component");
var guidance_component_1 = require("./guidance/guidance.component");
var guidance_home_component_1 = require("./guidance/guidance-home.component");
var counter_component_1 = require("./guidance/counter/counter.component");
var fetch_data_component_1 = require("./guidance/fetch-data/fetch-data.component");
var commutes_component_1 = require("./commutes/commutes.component");
var routes = [
    { path: '', component: home_component_1.HomeComponent, pathMatch: 'full' },
    { path: 'commutes', component: commutes_component_1.CommutesComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    {
        path: 'guidance', component: guidance_component_1.GuidanceComponent,
        children: [
            { path: '', component: guidance_home_component_1.GuidanceHomeComponent },
            { path: 'counter', component: counter_component_1.CounterComponent },
            { path: 'fetch-data', component: fetch_data_component_1.FetchDataComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
        ]
    },
    { path: 'not-found', component: error_page_component_1.ErrorPageComponent, data: { message: 'Page not found!' } },
    { path: '**', redirectTo: '/not-found' }
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        core_1.NgModule({
            imports: [router_1.RouterModule.forRoot(routes)],
            exports: [router_1.RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
exports.AppRoutingModule = AppRoutingModule;
//# sourceMappingURL=app-routing.module.js.map