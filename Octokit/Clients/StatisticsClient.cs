﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Octokit
{
    public class StatisticsClient : ApiClient, IStatisticsClient
    {
        /// <summary>
        /// Instantiates a new GitHub Statistics API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public StatisticsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Returns a list of <see cref="Contributor"/> for the given repository
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="repositoryName">The name of the repository</param>
        /// <returns>A list of <see cref="Contributor"/></returns>
        public async Task<IEnumerable<Contributor>> GetContributors(string owner, string repositoryName)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(repositoryName, "repositoryName");

            var endpoint = "/repos/{0}/{1}/stats/contributors".FormatUri(owner, repositoryName);

            var response = await Connection.GetAsync<IList<Contributor>>(endpoint, null, null);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                return await GetContributors(owner, repositoryName);
            }
            return response.BodyAsObject;
        }

        /// <summary>
        /// Returns a list of last year of commit activity by <see cref="WeeklyCommitActivity"/>. 
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="repositoryName">The name of the repository</param>
        /// <returns>A list of <see cref="WeeklyCommitActivity"/></returns>
        public async Task<IEnumerable<WeeklyCommitActivity>> GetCommitActivityForTheLastYear(string owner, string repositoryName)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(repositoryName, "repositoryName");

            var endpoint = "/repos/{0}/{1}/stats/commit_activity".FormatUri(owner, repositoryName);

            var response = await Connection.GetAsync<IList<WeeklyCommitActivity>>(endpoint, null, null);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                return await GetCommitActivityForTheLastYear(owner, repositoryName);
            }
            return response.BodyAsObject;
        }

        /// <summary>
        /// Returns a weekly aggregate of the number of additions and deletions pushed to a repository. 
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="repositoryName">The name of the repository</param>
        /// <returns>Returns a weekly aggregate of the number additions and deletion</returns>
        public async Task<IEnumerable<int[]>> GetAdditionsAndDeletionsPerWeek(string owner, string repositoryName)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(repositoryName, "repositoryName");

            var endpoint = "/repos/{0}/{1}/stats/code_frequency".FormatUri(owner, repositoryName);

            var response = await Connection.GetAsync<IList<int[]>>(endpoint, null, null);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                return await GetAdditionsAndDeletionsPerWeek(owner, repositoryName);
            }
            return response.BodyAsObject;
        }

        /// <summary>
        /// Returns the total commit counts for the owner and total commit counts in total. 
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="repositoryName">The name of the repository</param>
        /// <returns>Returns <see cref="WeeklyCommitCounts"/>from oldest week to now</returns>
        public async Task<WeeklyCommitCounts> GetCommitCountsPerWeek(string owner, string repositoryName)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(repositoryName, "repositoryName");

            var endpoint = "/repos/{0}/{1}/stats/participation".FormatUri(owner, repositoryName);

            var response = await Connection.GetAsync<WeeklyCommitCounts>(endpoint, null, null);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                return await GetCommitCountsPerWeek(owner, repositoryName);
            }
            return response.BodyAsObject;
        }

        /// <summary>
        /// Returns a list of the number of commits per hour in each day
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="repositoryName">The name of the repository</param>
        /// <returns>Returns commit counts per hour in each day</returns>
        public async Task<IEnumerable<int[]>> GetCommitPerHour(string owner, string repositoryName)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(repositoryName, "repositoryName");

            var endpoint = "/repos/{0}/{1}/stats/punch_card".FormatUri(owner, repositoryName);

            var response = await Connection.GetAsync<IEnumerable<int[]>>(endpoint, null, null);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                return await GetCommitPerHour(owner, repositoryName);
            }
            return response.BodyAsObject;
        }
    }
}