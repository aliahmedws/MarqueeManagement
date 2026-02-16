using MarqueeManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace MarqueeManagement.Permissions;

public class MarqueeManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MarqueeManagementPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(MarqueeManagementPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MarqueeManagementResource>(name);
    }
}
