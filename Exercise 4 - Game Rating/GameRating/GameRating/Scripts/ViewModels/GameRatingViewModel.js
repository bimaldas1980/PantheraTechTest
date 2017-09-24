ko.bindingHandlers.readonlyRating =
     {
         init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
             var value = ko.utils.unwrapObservable(valueAccessor());
             var starSize = allBindings.get('size') || 'xl';

             // Initialize the rating with the desired options
             $(element).rating(); //{ size: starSize, disabled:true, showClear:false, showCaption:false });
         },
         update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
             // Get the data we are bound to...
             var value = valueAccessor();
             var valueUnwrapped = ko.unwrap(value);

             var starSize = allBindings.get('size') || 'xxl';

             $(element).rating('refresh', { size: starSize });
             $(element).rating('update', valueUnwrapped);
         },
         change: function (params) {
             alert(params[0]);
         }
     };

var gameRatingViewModel = function GameRating(gameId, gameName, gameDescription, gameRating) {
    var self = this;

    self.GameID = ko.observable(gameId);
    self.GameName = ko.observable(gameName);
    self.GameDescription = ko.observable(gameDescription);
    self.GameRating = ko.observable(gameRating);
    self.gameList = ko.observableArray([]);
        
    self.getGames = function () {
        self.gameList.removeAll();
       
        $.getJSON('api/gamerating/getall', function (data) {
            self.gameList(data);
        });
    };

    //self.updateRating = function (gameRating) {
    //    document.location.href = "/Item?id=" + gameRating.GameID;
    //}
    // data-bind="click: $root.updateRating"
}

$(document).ready(function () {
    var gr = new gameRatingViewModel();
    ko.applyBindings(gr, document.getElementById('gameRatingListContainer'));
    gr.getGames();
});

