﻿namespace Sigfox.Api.Groups.ViewModels
{
    using Enums;

    public class MinimalGroup
    {
        #region Constructor

        public MinimalGroup(string id, string name, GroupTypes type, int level, string[] actions)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Level = level;
            this.Actions = actions;
        }

        #endregion Constructor

        #region Properties

        public string Id { get; }
        public string Name { get; }
        public GroupTypes Type { get; }
        public int Level { get; }
        public string[] Actions { get; }

        #endregion Properties
    }
}
