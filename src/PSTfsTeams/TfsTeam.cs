using System;

namespace PSTfsTeams
{
    public class TfsTeam
    {
        private readonly Uri _collectionUri;
        private readonly string _teamProject;
        private readonly string _name;
        private readonly string _description;

        public TfsTeam(Uri collectionUri, string teamProject, string name, string description)
        {
            _collectionUri = collectionUri;
            _teamProject = teamProject;
            _name = name;
            _description = description;
        }

        public Uri CollectionUri
        {
            get { return _collectionUri; }
        }

        public string TeamProject
        {
            get { return _teamProject; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }
    }
}