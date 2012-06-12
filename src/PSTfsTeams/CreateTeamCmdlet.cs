using System.Management.Automation;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;

namespace PSTfsTeams
{
    [Cmdlet(VerbsCommon.New, "TfsTeam")]
    public class CreateTeamCmdlet : TeamProjectCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Description { get; set; }

        protected override void ProcessRecord()
        {
            using (var collection = new TfsTeamProjectCollection(CollectionUri))
            {
                var cssService = collection.GetService<ICommonStructureService4>();
                var projectInfo = cssService.GetProjectFromName(TeamProject);

                var teamService = collection.GetService<TfsTeamService>();
                var team = teamService.CreateTeam(projectInfo.Uri, Name, Description, null);

                WriteObject(new TfsTeam(CollectionUri, TeamProject, team.Name, team.Description));
            }
        }
    }
}