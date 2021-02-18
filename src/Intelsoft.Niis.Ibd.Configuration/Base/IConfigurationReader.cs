namespace Intelsoft.Niis.Ibd.Configuration.Base
{
    public interface IConfigurationReader<out TConfiguration> where TConfiguration : IConfiguration
    {
        TConfiguration Read(string sectionName);
    }
}