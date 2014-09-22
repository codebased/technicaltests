/*! stringextensions - v1.0 - 18/2/2014
* Copyright CM (c) 2014 codebased@hotmail.com; Licensed MIT */

$(function () {

    // -- DOM is ready to action on.

    /*
   Summary: startsWith should take a single argument and return true if the provided string is a
            prefix of this.
   */
    if (typeof String.prototype.startsWith !== 'function') {

        // checked and there is no startsWith (pre-defined) method.
        String.prototype.startsWith = function (prefix) {
            return this.indexOf(prefix) == 0;
        };
    } else {

        // raise the log message for the developer.
        raiseLog("startsWith prototype is already defined. Unable to attach StringExtensinos.js.startsWith");
    }

    /*
    Summary: endsWith should take a single argument and return true if the provided string is a
             postfix of this.
    */
    if (typeof String.prototype.endsWith !== 'function') {

        // checked and there is no endsWith (pre-defined) method.
        String.prototype.endsWith = function (postfix) {
            return this.indexOf(postfix, this.length - postfix.length) !== -1;
        };
    } else {

        // raise the log message for the developer.
        raiseLog("endsWith prototype is already defined. Unable to attach StringExtensinos.js.endsWith");
    }


    /*
    Summary: This method should remove all html/xml tags from this. 
    */
    if (typeof String.prototype.stripHtml !== 'function') {
        // checked and there is o stripHtml (pre-defined) method.
        String.prototype.stripHtml = function () {
            // By wrapping around p tag we have made 
            // sure that it is actually a valid html. 
            return jQuery('<p>' + this + '</p>').text();
        };
    } else {

        // raise the log message for the developer.
        raiseLog("stripHtml prototype is already defined. Unable to attach StringExtensinos.js.stripHtml");
    }

    // raise the log to the console. This tool is handy for Mr. developer - F12
    function raiseLog(message) {

        // ensure that we have a console function available.
        // later we may move this object into more jquery form and add a plugin.
        if (typeof console == "object" && typeof console.log == 'function') {
            console.log(message);
        }
    }
});