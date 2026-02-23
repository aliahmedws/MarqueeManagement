using MarqueeManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MarqueeManagement.Permissions;

public class MarqueeManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //var myGroup = context.AddGroup(MarqueeManagementPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(MarqueeManagementPermissions.MyPermission1, L("Permission:MyPermission1"));
        var marqueeGroup = context.AddGroup(MarqueeManagementPermissions.GroupName,
            L("Permission:MarqueeManagement")
        );

        var marqueePermission = marqueeGroup.AddPermission(MarqueeManagementPermissions.Marquees.Default,
            L("Permission:Marquees")
        );

        marqueePermission.AddChild(
            MarqueeManagementPermissions.Marquees.Create, L("Permission:Marquees.Create")
        );
        marqueePermission.AddChild(
            MarqueeManagementPermissions.Marquees.Edit, L("Permission:Marquees.Edit")
        );
        marqueePermission.AddChild(
            MarqueeManagementPermissions.Marquees.Delete,
            L("Permission:Marquees.Delete")
        );

        var customerPermission = marqueeGroup.AddPermission(
    MarqueeManagementPermissions.Customers.Default,
    L("Permission:Customers")
);

        customerPermission.AddChild(
            MarqueeManagementPermissions.Customers.Create,
            L("Permission:Customers.Create")
        );
        customerPermission.AddChild(
            MarqueeManagementPermissions.Customers.Edit,
            L("Permission:Customers.Edit")
        );
        customerPermission.AddChild(
            MarqueeManagementPermissions.Customers.Delete,
            L("Permission:Customers.Delete")
        );
        var menuItemPermission = marqueeGroup.AddPermission(
    MarqueeManagementPermissions.MenuItems.Default, L("Permission:MenuItems")
);

        menuItemPermission.AddChild(
            MarqueeManagementPermissions.MenuItems.Create,
            L("Permission:MenuItems.Create")
        );
        menuItemPermission.AddChild(
            MarqueeManagementPermissions.MenuItems.Edit,
            L("Permission:MenuItems.Edit")
        );

        menuItemPermission.AddChild(
            MarqueeManagementPermissions.MenuItems.Delete,
            L("Permission:MenuItems.Delete")
        );
    }


    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MarqueeManagementResource>(name);
    }
}
