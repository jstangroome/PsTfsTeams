using System.Management.Automation;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;

namespace PSTfsTeams
{
    [Cmdlet(VerbsCommon.Get, "TfsTeam")]
    public class ListTeamCmdlet : TeamProjectCmdlet
    {
        protected override void ProcessRecord()
        {
            using (var collection = new TfsTeamProjectCollection(CollectionUri))
            {

                var teamService = collection.GetService<TfsTeamService>();

                var cssService = collection.GetService<ICommonStructureService4>();
                var projectInfo = cssService.GetProjectFromName(TeamProject);

                var teams = teamService.QueryTeams(projectInfo.Uri);
                foreach (var team in teams)
                {
                    WriteObject(new TfsTeam(CollectionUri, TeamProject, team.Name, team.Description));
                }

            }
        }
    }
}