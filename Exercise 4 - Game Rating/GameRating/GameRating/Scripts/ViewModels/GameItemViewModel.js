var gameItemViewModel = function GameRating(gameId, gameName, gameDescription, gameRating) {
    var self = this;

    self.GameID = ko.observable(gameId);
    self.GameName = ko.observable(gameName);
    self.GameDescription = ko.observable(gameDescription);
    self.GameRating = ko.observable(gameRating);

    self.addRating = function () {

        $.ajax({
            url: 'api/gamerating/addrating',
            type: 'post',
            data: { gameId: self.GameID, rating: self.GameRating },
            contentType: 'application/json',
            success: function (data) {

            }
        });
    };

    self.getGame = function () {
        $.ajax({
            url: 'api/gamerating/getbyid',
            type: 'get',
            data: { gameId: $.urlParam('id') },
            contentType: 'application/json',
            success: function (data) {
                self = data;
            }
        });
    };

    $.urlParam = function (name) {
        var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
        return results[1] || 0;
    }
}

$(document).ready(function () {
    var gr = new gameItemViewModel();
    ko.applyBindings(gr, $("#gameItemContainer"));
    gr.getGame();
});

