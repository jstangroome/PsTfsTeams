# PSTfsTeams

A PowerShell module alternative to the ALM Rangers' Quick Response Sample "Command line utility to manage Team Foundation Server Teams and Users".

[Quick Response Sample – Command line utility to manage Team Foundation Server Teams and Users](http://blogs.msdn.com/b/visualstudioalm/archive/2012/06/11/quick-response-sample-command-line-utility-to-manage-team-foundation-server-teams-and-users.aspx)

[Quick Response Sample Solutions downloads](http://vsarguidance.codeplex.com/releases/view/96222)

## Usage

Download and extract the PSTfsTeams.zip file from the
[Releases](https://github.com/jstangroome/PsTfsTeams/releases) page. 
The contents should be extracted to a folder on the PowerShell PSModulePath, 
for example `%USERPROFILE%\Documents\WindowsPowerShell\Modules\`, ie `C:\Users\Jason\Documents\Windows\PowerShell\Modules\`.

The zip file should be extracted so that the DLL file exists within a folder of the same name, eg:
`.\Modules\PSTfsTeams\PSTfsTeams.dll`.

The module can then be imported:

    Import-Module -Name PSTfsTeams

A list of teams for a given Team Project can be retrieved:

    Get-TfsTeam -CollectionUri http://tfsserver:8080/tfs/DefaultCollection -TeamProject YourProject

A new team can be created:

    New-TfsTeam -CollectionUri http://tfsserver:8080/tfs/DefaultCollection `
      -TeamProject YourProject `
      -Name 'New team name' `
      -Description 'Description of new team'

Add a member to an existing team:

    Add-TfsTeamMember -CollectionUri http://tfsserver:8080/tfs/DefaultCollection `
      -TeamProject YourProject `
      -Team 'A team name' `
      -Member 'New member user name'
