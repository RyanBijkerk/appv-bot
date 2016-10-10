using System;

namespace AppV_Bot.Models
{
    public class PackageModel
    {
        /*
        Command: Get-AppVPackage -All
        PackageId            : 5d6bcdb1-126e-410f-b090-0086e1b4489f
        VersionId            : 735b1d4b-162e-4184-abd3-c100106468e2
        Name                 : Freemind
        Version              : 0.0.0.1
        Path                 : \\infra.local.lab\content$\Freemind\Freemind.appv
        IsPublishedToUser    : False
        UserPending          : False
        IsPublishedGlobally  : False
        GlobalPending        : False
        InUse                : False
        InUseByCurrentUser   : False
        PackageSize          : 41931614
        PercentLoaded        : 1
        IsLoading            : False
        HasAssetIntelligence : True
        */

        public string PackageId { get; set; }
        public string VersionId { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Path { get; set; }
        public bool IsPublishedToUser { get; set; }
        public bool UserPending { get; set; }
        public bool IsPublishedGlobally { get; set; }
        public bool GlobalPending { get; set; }
        public bool InUse { get; set; }
        public bool InUseByCurrentUser { get; set; }
        public UInt64 PackageSize { get; set; }
        public int PercentLoaded { get; set; }
        public bool IsLoading { get; set; }
        public bool HasAssetIntelligence { get; set; }
    }
}