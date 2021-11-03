using Lokalise.Api.Collections.Files.Responses;
using Lokalise.Api.Extensions;
using System;

namespace Lokalise.Api.Models
{
    public class QueuedProcess
    {
        public string ProcessId { get; }

        public string Type { get; }

        public string Status { get; }

        public string Message { get; }

        public long CreatedBy { get; }

        public string CreatedByEmail { get; }

        public DateTime CreatedAt { get; }

        public override string ToString()
        {
            return ProcessId;
        }

        internal QueuedProcess(QueuedProcessResponse response)
        {
            ProcessId = response.ProcessId;
            Type = response.Type;
            Status = response.Status;
            Message = response.Message;
            CreatedBy = response.CreatedBy;
            CreatedByEmail = response.CreatedByEmail;
            CreatedAt = response.CreatedAtTimestamp.ToUtcDateTime();
        }
    }
}