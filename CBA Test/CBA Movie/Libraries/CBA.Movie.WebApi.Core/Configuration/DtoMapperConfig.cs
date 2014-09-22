//-----------------------------------------------------------------------
// <copyright file="DtoMapperConfig.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.WebApi.Core.Configuration
{
    using System;
    using AutoMapper;
    using MoviesLibrary;

    /// <summary>
    /// This class is to configure Dto object mapping.
    /// </summary>
    public static class DtoMapperConfig
    {
        /// <summary>
        /// Create map in the mapper.
        /// </summary>
        public static void CreateMaps()
        {
            // I prefer to use ID as a column where required.
            Mapper.CreateMap<Dto.MovieDto, MovieData>().ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.ID));
            Mapper.CreateMap<MovieData, Dto.MovieDto>().ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.MovieId));
        }
    }
}
