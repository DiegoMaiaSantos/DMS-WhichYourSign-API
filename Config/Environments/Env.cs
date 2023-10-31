namespace DMS_WhichYourSign_API.Config.Environments
{
    public static class Env
    {
        public static readonly Func<string, string> Get = (
            env) => Environment.GetEnvironmentVariable(env);
    }
}
