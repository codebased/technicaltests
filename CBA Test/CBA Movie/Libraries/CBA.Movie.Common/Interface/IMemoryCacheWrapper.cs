//-----------------------------------------------------------------------
// <copyright file="IMemoryCacheWrapper.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.Data.Interface
{
    using System;
    using System.Runtime.Caching;

    /// <summary>
    /// Memory cache wrapper.
    /// </summary>
    /// <typeparam name="T">Type of cache - for generic set object</typeparam>
    public interface IMemoryCacheWrapper<T>
    {
        /// <summary>
        /// Gets the name of a cache.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets  cache memory limit in bytes.
        /// </summary>
        long CacheMemoryLimitInBytes { get; }

        /// <summary>
        /// Gets physical memory limit.
        /// </summary>
        long PhysicalMemoryLimit { get; }

        /// <summary>
        /// Gets polling interval.
        /// </summary>
        TimeSpan PollingInterval { get; }

        /// <summary>
        /// Gets or sets cache policy.
        /// </summary>
        CacheItemPolicy CacheItemPolicy { get; set; }

        /// <summary>
        /// Gets a value indicating whether the object is disposed.
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// Gets a count on number of cache item.
        /// </summary>
        long Count { get; }

        /// <summary>
        /// Add or update the cache.
        /// </summary>
        /// <param name="key">Cache Key</param>
        /// <param name="value">Cache value</param>
        void AddOrUpdate(string key, T value);

        /// <summary>
        /// Try to get the value from the Cache.
        /// </summary>
        /// <param name="key">Cache key</param>
        /// <param name="value">Reference to cache value.</param>
        /// <returns>on success return true.</returns>
        bool TryGetValue(string key, out T value);

        /// <summary>
        /// Try to remove the value from the cache and set cache value in the out object.
        /// </summary>
        /// <param name="key">Cache key</param>
        /// <param name="value">Reference to cache value.</param>
        /// <returns>on success return true.</returns>
        bool TryRemove(string key, out T value);

        /// <summary>
        /// Remove the cache item.
        /// </summary>
        /// <param name="key">cache key</param>
        void Remove(string key);

        /// <summary>
        /// Check if the cache contains a key.
        /// </summary>
        /// <param name="key">Cache key.</param>
        /// <returns>On success return true.</returns>
        bool ContainsKey(string key);

        /// <summary>
        /// Dispose item.
        /// </summary>
        void Dispose();
    }
}
