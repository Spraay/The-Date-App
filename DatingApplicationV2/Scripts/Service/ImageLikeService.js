"use strict";
exports.__esModule = true;
var request = require("request");
var ImageLikeService = /** @class */ (function () {
    function ImageLikeService() {
    }
    ImageLikeService.prototype.GetImageLikes = function (id) {
        request.get(APIUri.uri + "ImageLike/GetImageLikes/" + id + "/", function (response) {
            return response;
        });
        throw new Error("Response from GetImageLikes is not a number!");
    };
    return ImageLikeService;
}());
exports.ImageLikeService = ImageLikeService;
