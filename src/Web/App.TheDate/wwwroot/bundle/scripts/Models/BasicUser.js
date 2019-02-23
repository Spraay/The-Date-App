"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var BasicUser = /** @class */ (function () {
    function BasicUser(Id, FirstName, LastName, ProfileImgSrc) {
        var _this = this;
        this.getFullName = function () { return _this.FirstName + " " + _this.LastName; };
        this.Id = Id || "";
        this.FirstName = FirstName || "";
        this.LastName = LastName || "";
        this.ProfileImgSrc = ProfileImgSrc || "";
    }
    return BasicUser;
}());
exports.BasicUser = BasicUser;
//# sourceMappingURL=BasicUser.js.map