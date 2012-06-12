using System;
using System.Management.Automation;

namespace PSTfsTeams
{
    public abstract class TeamProjectCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public Uri CollectionUri { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string TeamProject { get; set; }
    }
}
