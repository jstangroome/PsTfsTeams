using System;
using System.Management.Automation;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.Server;

namespace PSTfsTeams
{
    [Cmdlet(VerbsCommon.Add, "TfsTeamMember")]
    public class AddUserCmdlet : TeamProjectCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Team { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Member { get; set; }

        protected override void ProcessRecord()
        {
            using (var collection = new TfsTeamProjectCollection(CollectionUri))
            {
                var cssService = collection.GetService<ICommonStructureService4>();
                var projectInfo = cssService.GetProjectFromName(TeamProject);

                var teamService = collection.GetService<TfsTeamService>();
                var tfsTeam = teamService.ReadTeam(projectInfo.Uri, Team, null);
                if (tfsTeam == null)
                {
                    WriteError(new ErrorRecord(new ArgumentException(string.Format("Team '{0}' not found.", Team)), "", ErrorCategory.InvalidArgument, null));
                    return;
                }

                var identityService = collection.GetService<IIdentityManagementService>();
                var identity = identityService.ReadIdentity(IdentitySearchFactor.AccountName, Member, MembershipQuery.Direct, ReadIdentityOptions.None);
                if (identity == null)
                {
                    WriteError(new ErrorRecord(new ArgumentException(string.Format("Identity '{0}' not found.", Member)), "", ErrorCategory.InvalidArgument, null));
                    return;
                }

                identityService.AddMemberToApplicationGroup(tfsTeam.Identity.Descriptor, identity.Descriptor);
                WriteVerbose(string.Format("Identity '{0}' added to team '{1}'", Member, Team));
            }
        }
    }

}