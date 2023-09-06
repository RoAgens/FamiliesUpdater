
namespace FamiliesUpdater.Extensions
{
    public static class BooleanExtension
    {
        public static string GetBool(this bool boolean)
                          => boolean ? "true" : "false";
    }
}
