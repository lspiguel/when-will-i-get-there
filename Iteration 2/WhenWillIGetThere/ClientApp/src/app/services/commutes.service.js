"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var CommutesService = /** @class */ (function () {
    function CommutesService(_http, baseUrl) {
        this._http = _http;
        this._appUrl = "";
        this._appUrl = baseUrl;
    }
    Object.defineProperty(CommutesService.prototype, "routes", {
        get: function () {
            return this._routes.slice();
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(CommutesService.prototype, "commutes", {
        get: function () {
            return this._commutes.slice();
        },
        enumerable: true,
        configurable: true
    });
    CommutesService.prototype.refresh = function () {
        this.refreshRoutes();
        this.refreshCommutes();
    };
    CommutesService.prototype.refreshRoutes = function () {
        var _this = this;
        this._http.get(this._appUrl + 'api/Routes').subscribe(function (result) {
            _this._routes = result;
        }, function (error) { return console.error(error); });
    };
    CommutesService.prototype.refreshCommutes = function () {
        var _this = this;
        this._http.get(this._appUrl + 'api/Commutes').subscribe(function (result) {
            _this._commutes = result;
        }, function (error) { return console.error(error); });
    };
    CommutesService.prototype.setUser = function (user) {
        this._user = user;
    };
    CommutesService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        }),
        __param(1, core_1.Inject('BASE_URL'))
    ], CommutesService);
    return CommutesService;
}());
exports.CommutesService = CommutesService;
//# sourceMappingURL=commutes.service.js.map