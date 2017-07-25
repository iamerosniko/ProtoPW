"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t;
    return { next: verb(0), "throw": verb(1), "return": verb(2) };
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = y[op[0] & 2 ? "return" : op[0] ? "throw" : "next"]) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [0, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
var core_1 = require("@angular/core");
var auth_1 = require("./entities/auth");
var tempuser_1 = require("./entities/tempuser");
var team_service_1 = require("./services/team.service");
var leader_service_1 = require("./services/leader.service");
var tempuser_service_1 = require("./services/tempuser.service");
var WelcomeComponent = (function () {
    function WelcomeComponent(teamService, leaderService, tempuserService) {
        this.teamService = teamService;
        this.leaderService = leaderService;
        this.tempuserService = tempuserService;
        this.user = new auth_1.Auth(true, '', '');
        this.cv = new core_1.EventEmitter();
        this.teams = [];
        this.leaders = [];
        this.tempuser = new tempuser_1.TempUser(0, "", "", "", 0, "", 0, 0, true);
        this.photo = 'ProjectWorkplace/Resources/Images/background.png';
        this.getTeams();
        this.getLeaders();
    }
    WelcomeComponent.prototype.ngOnInit = function () {
    };
    WelcomeComponent.prototype.getTeams = function () {
        var _this = this;
        this.teamService.getTeams().then(function (teams) { return _this.teams = teams; });
    };
    WelcomeComponent.prototype.getLeaders = function () {
        var _this = this;
        this.leaderService.getLeaders().then(function (leaders) { return _this.leaders = leaders; });
    };
    WelcomeComponent.prototype.submitUser = function () {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                if (this.tempuser.FirstName == "" ||
                    this.tempuser.LastName == "" ||
                    this.tempuser.TeamID == "" ||
                    this.tempuser.LeaderID == 0) {
                    alert("Some fields are not supplied.");
                }
                else {
                    this.tempuser.UserName = this.user.userName;
                    this.tempuserService.postTempUser(this.tempuser).then(function () {
                        _this.tempuserService.getLatestUser().then(function (users) {
                            _this.latestUser = users[0].ID;
                            document.cookie = _this.latestUser.toString();
                        });
                    });
                    this.changeView();
                }
                return [2 /*return*/];
            });
        });
    };
    WelcomeComponent.prototype.changeView = function () {
        this.cv.emit();
    };
    return WelcomeComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", auth_1.Auth)
], WelcomeComponent.prototype, "user", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], WelcomeComponent.prototype, "cv", void 0);
WelcomeComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'welcome-user',
        templateUrl: 'welcome.html',
        styleUrls: ['welcome.css']
    }),
    __metadata("design:paramtypes", [team_service_1.TeamService,
        leader_service_1.LeaderService,
        tempuser_service_1.TempUserService])
], WelcomeComponent);
exports.WelcomeComponent = WelcomeComponent;
