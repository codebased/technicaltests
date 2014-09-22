/*! jQuery anchormaaster Plugin - v1.0 - 18/2/2014
* Copyright CM (c) 2014 codebased@hotmail.com; Licensed MIT */

(function ($) {

    // function that go through each link available in the given html object/
    // and connect click event for opening a link to the new window.
    $.fn.linkExtender = function (options) {

        // default settings are merged with options parameter.
        var settings = $.extend({
            channelmode: 0,
            fullscreen: 0,
            height: 600,
            left: 50,
            location: 0,
            menubar: 0,
            resizable: 1,
            scrollbars: 0,
            status: 1,
            titlebar: 1,
            toolbar: 1,
            top: 100,
            width: 800
        }, options || {});

        var winprop = JSON.stringify(settings).replace(/}|{|"/g, '').replace(/:/g, "=");

        // loop through all a link that has been within 
        return this.find("a").each(function () {
            
            $(this).click(function () {

                // it did not worked as expected by sending settings object.
                // window.open($(this).attr('href'), "anchormasterwinpop", settings);
                // hence I'd to use winprop - string based value.
                window.open($(this).attr('href'), "anchormasterwinpop", winprop);

                // STOP THE CLICK BUBLE!!!
                return false;
            });
        });
    };
})(jQuery);