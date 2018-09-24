// <copyright file="IPlugin.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Plugin.Interface
{
    public interface IPlugin
    {
        string Description { get; }

        Status Status { get; set; }

        void Start(string message);
    }
}
