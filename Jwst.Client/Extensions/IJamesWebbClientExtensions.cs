// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Extensions;

public static class IJamesWebbClientExtensions
{
    /// <summary>
    /// Gets all of the observations grouped by each program.
    /// </summary>
    /// <param name="client">The <see cref="IJamesWebbClient"/> instance to query.</param>
    /// <param name="perPage">[Default: 100] An optional items per page number, used as a query string parameter.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to cancel the request.
    /// </param>
    /// <returns>
    /// A representation of all observations grouped by their program, as an
    /// <see cref="IAsyncEnumerable{T}"/> where <c>T</c> is a tuple of
    /// (<see cref="ListedProgram"/>, <see cref="ObservationDetails"/>).
    /// </returns>
    public static async IAsyncEnumerable<(ListedProgram, ObservationDetails)> GetAllByProgramAsAsyncEnumerable(
        this IJamesWebbClient client,
        int perPage = 100,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        // Get the list of programs
        var programs = await client.GetProgramListAsync(cancellationToken);

        // Get the details for each program
        foreach (var program in programs.Body)
        {
            // Page over each program's observations, in chunks starting on page 1.
            var hasMorePages = true;
            var page = 1;

            while (hasMorePages)
            {
                var response = await client.GetByProgramIdAsync(
                    program.Program, page, perPage, cancellationToken);

                if (response is { StatusCode: 200 })
                {
                    if (response is null or { Body.Length: 0 })
                    {
                        break;
                    }

                    foreach (var observation in response.Body)
                    {
                        if (observation is null)
                        {
                            continue;
                        }

                        yield return (program, observation);
                    }

                    ++ page;
                }
                else
                {
                    hasMorePages = false;
                }
            }
        }
    }

    /// <summary>
    /// Gets all of the observations grouped by each suffix.
    /// </summary>
    /// <param name="client">The <see cref="IJamesWebbClient"/> instance to query.</param>
    /// <param name="perPage">[Default: 100] An optional items per page number, used as a query string parameter.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to cancel the request.
    /// </param>
    /// <returns>
    /// A representation of all observations grouped by their suffix, as an
    /// <see cref="IAsyncEnumerable{T}"/> where <c>T</c> is a tuple of
    /// (<see cref="SuffixDetails"/>, <see cref="ObservationDetails"/>).
    /// </returns>
    public static async IAsyncEnumerable<(SuffixDetails, ObservationDetails)> GetAllBySuffixAsAsyncEnumerable(
        this IJamesWebbClient client,
        int perPage = 100,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        // Get the list of programs
        var suffixList = await client.GetSuffixListAsync(cancellationToken);

        // Get the details for each program
        foreach (var suffix in suffixList.Body)
        {
            // Page over each program's observations, in chunks starting on page 1.
            var hasMorePages = true;
            var page = 1;

            while (hasMorePages)
            {
                var response = await client.GetAllBySuffixAsync(
                    suffix.Suffix, page, perPage, cancellationToken);

                if (response is { StatusCode: 200 })
                {
                    if (response is null or { Body: null } or { Body.Length: 0 })
                    {
                        break;
                    }

                    foreach (var observation in response.Body)
                    {
                        if (observation is null)
                        {
                            continue;
                        }

                        yield return (suffix, observation);
                    }

                    ++page;
                }
                else
                {
                    hasMorePages = false;
                }
            }
        }
    }
}
