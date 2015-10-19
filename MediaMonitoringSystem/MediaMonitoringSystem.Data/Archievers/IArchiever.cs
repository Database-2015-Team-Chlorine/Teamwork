﻿namespace MediaMonitoringSystem.Data.Archievers
{
    using System;
    using System.Linq;

    public interface IArchiever
    {
        void SendToArchieve(string rootFolder, string zipPath);

        void UnArchieve(string zipPath, string exportFolder);

    }
}
