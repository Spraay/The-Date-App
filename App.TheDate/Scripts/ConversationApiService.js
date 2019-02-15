"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var request = require("request");
var ConversationApiService = /** @class */ (function () {
    function ConversationApiService() {
    }
    ConversationApiService.prototype.getConversationInfo = function (conversationId) {
        request.get("/api/MessagesApi/conversation/" + conversationId, null, function (response) {
            console.log(response);
        });
    };
    return ConversationApiService;
}());
exports.ConversationApiService = ConversationApiService;
//# sourceMappingURL=ConversationApiService.js.map