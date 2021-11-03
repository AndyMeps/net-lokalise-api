using Lokalise.Api.Collections.Branches.Responses;
using Lokalise.Api.Extensions;
using System;

namespace Lokalise.Api.Models
{
    public class Branch
    {
        /// <summary>
        /// A unique identifier of the branch.
        /// </summary>
        public long BranchId { get; }

        /// <summary>
        /// Branch name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Date of branch creation.
        /// </summary>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// An identifier of a user who has created the branch.
        /// </summary>
        public long CreatedBy { get; }

        /// <summary>
        /// An e-mail of a user who has created the branch.
        /// </summary>
        public string CreatedByEmail { get; }

        internal Branch(BranchResponse branchResponse)
        {
            BranchId = branchResponse.BranchId;
            Name = branchResponse.Name;
            CreatedAt = branchResponse.CreatedAtTimestamp.ToUtcDateTime();
            CreatedBy = CreatedBy;
            CreatedByEmail = CreatedByEmail;
        }
    }
}
