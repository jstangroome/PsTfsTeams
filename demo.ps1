[CmdletBinding()]
param (
    [Parameter(Mandatory=$true)]
    [string]
    $CollectionUri,

    [Parameter(Mandatory=$true)]
    [string]
    $ProjectName,

    [string]
    $NewTeamName = 'foo'
)

$PSScriptRoot = Split-Path -Path $MyInvocation.MyCommand.Path

$PSTfsTeamsModulePath = Join-Path -Path $PSScriptRoot -ChildPath src\PSTfsTeams\bin\debug\PSTfsTeams

Import-Module -Name $PSTfsTeamsModulePath

'Module:'
Get-Module -Name PsTfsTeams | Format-List

'Commands:'
Get-Command -Module PsTfsTeams | Format-Table -Property Name

'Teams:'
Get-TfsTeam -CollectionUri $CollectionUri -TeamProject $ProjectName |
    Tee-Object -Variable Teams

'Add member:'
Add-TfsTeamMember -CollectionUri $CollectionUri -TeamProject $ProjectName -Team $Teams[0].Name -Member $Env:USERNAME -Verbose

'New team:'
New-TfsTeam -CollectionUri $CollectionUri -TeamProject $ProjectName -Name $NewTeamName -Description "Placeholder description of $NewTeamName"
