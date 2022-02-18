namespace Pets.Platform.Permissions.Core.Interfaces;

public class PermissionResult
{
    public bool Granted { get; }
    public bool Rejected => !Granted;
    
    public string ErrorMessage { get; }

    protected PermissionResult(bool isGranted, string errorMessage)
    {
        Granted = isGranted;
        ErrorMessage = errorMessage;
    }

    public static PermissionResult Reject(string errorMessage) => new(false, errorMessage);

    public static PermissionResult Grant() => new(true, null);
    
    public static PermissionResult OnAll(params Func<PermissionResult>[] results)
    {
        foreach (var pResult in results)
        {
            var res = pResult();
            if (res.Rejected)
            {
                return res;
            }
        }

        return Grant();
    }
}