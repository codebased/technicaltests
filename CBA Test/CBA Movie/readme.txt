SOFTWARE REQUIREMENT

VS.NET 2012
.NET 4.5

HIGHLIGHTED - LIBRARIES USED

WEBAPI, MVC 4.0, JQuery, JQGrid, AutoMapper, and StyleCop

ASSUMPTIONS 

Because we don't know when data is going to be updated and there is no way to know through Movie API,I am assuming that we are going store data in the cache for 1 day from first fetch.

The cache has been cleared as soon as data changes are applied. 

ALTERNATIVE TO CACHING ENTIRE MOVIE LIST INTO ONE CACHE.

Obviously, if the data source is very big then there is no point that we get all data in one go; instead we should represent each object of type MovieData as a separate entity in the cache. System will try to find specific object from the cache before it goes through Movie API.


