using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Threading.Tasks;
using AppV_Api.Models;

namespace AppV_Api.Services
{
    public class PackagesService
    {
        public async Task<List<PackageModel>> GetPackages()
        {
            return await Task.Run(() =>
            {
                var packageList = new List<PackageModel>();

                InitialSessionState initial = InitialSessionState.CreateDefault();
                Runspace runspace = RunspaceFactory.CreateRunspace(initial);

                runspace.Open();

                PowerShell ps = PowerShell.Create();
                ps.Runspace = runspace;

                ps.Commands.AddScript("Get-AppvClientPackage -All");

                var results = ps.Invoke();

                foreach (PSObject result in results)
                {
                    var package = new PackageModel();

                    /*
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

                    package.PackageId = result.Members["PackageId"].Value.ToString();
                    package.VersionId = result.Members["VersionId"].Value.ToString();
                    package.Name = result.Members["Name"].Value.ToString();
                    package.Version = result.Members["Version"].Value.ToString();
                    package.Path = result.Members["Path"].Value.ToString();
                    package.IsPublishedToUser = result.Members["IsPublishedToUser"].Value.ToString() != "False";
                    package.UserPending = result.Members["UserPending"].Value.ToString() != "False";
                    package.IsPublishedGlobally = result.Members["IsPublishedGlobally"].Value.ToString() != "False";
                    package.InUse = result.Members["InUse"].Value.ToString() != "False";
                    package.InUseByCurrentUser = result.Members["InUseByCurrentUser"].Value.ToString() != "False";
                    package.PackageSize = Convert.ToUInt64(result.Members["PackageSize"].Value.ToString());
                    package.PercentLoaded = Convert.ToUInt16(result.Members["PercentLoaded"].Value.ToString());
                    package.IsLoading = result.Members["IsLoading"].Value.ToString() != "False";
                    package.HasAssetIntelligence = result.Members["HasAssetIntelligence"].Value.ToString() != "False";



                    packageList.Add(package);

                }

                return packageList;
            });
        }

        public async Task<PackageModel> GetPackage(string packageName)
        {
            return await Task.Run(() =>
            {
                var package = new PackageModel();

                InitialSessionState initial = InitialSessionState.CreateDefault();
                Runspace runspace = RunspaceFactory.CreateRunspace(initial);

                runspace.Open();

                PowerShell ps = PowerShell.Create();
                ps.Runspace = runspace;

                ps.Commands.AddScript($"Get-AppvClientPackage -Name \"{packageName}\" -All");

                var results = ps.Invoke();
                
                foreach (PSObject result in results)
                {

                    /*
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

                    package.PackageId = result.Members["PackageId"].Value.ToString();
                    package.VersionId = result.Members["VersionId"].Value.ToString();
                    package.Name = result.Members["Name"].Value.ToString();
                    package.Version = result.Members["Version"].Value.ToString();
                    package.Path = result.Members["Path"].Value.ToString();
                    package.IsPublishedToUser = result.Members["IsPublishedToUser"].Value.ToString() != "False";
                    package.UserPending = result.Members["UserPending"].Value.ToString() != "False";
                    package.IsPublishedGlobally = result.Members["IsPublishedGlobally"].Value.ToString() != "False";
                    package.InUse = result.Members["InUse"].Value.ToString() != "False";
                    package.InUseByCurrentUser = result.Members["InUseByCurrentUser"].Value.ToString() != "False";
                    package.PackageSize = Convert.ToUInt64(result.Members["PackageSize"].Value.ToString());
                    package.PercentLoaded = Convert.ToUInt16(result.Members["PercentLoaded"].Value.ToString());
                    package.IsLoading = result.Members["IsLoading"].Value.ToString() != "False";
                    package.HasAssetIntelligence = result.Members["HasAssetIntelligence"].Value.ToString() != "False";
                }

                return package;
            });
        }

    }
}
