using Elasticsearch.Net;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;
using WebLibraryApp.Options;

namespace WebLibraryApp.Helpers
{
    public static class ElasticsearchSinkHelper
    {
        public static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string? environment)
        {
            var options = configuration
                .GetSection(ElasticsearchOptions.Section)
                .Get<ElasticsearchOptions>();

            var nodes = options.Nodes.Select(e => new Uri(e));
            var appName = options.ApplicationName?.ToLower() ?? GetApplicationNameFromAssembly();
            var environmentTag = environment?.ToLower().Replace(".", "-");
            var indexFormat = $"{appName}-logs-{environmentTag}-{{0:yyyy-MM}}";

            Console.WriteLine(
                $"--> Elastic Settings:\n" +
                $"--> Nodes                -- {string.Join(", ", options.Nodes)}\n" +
                $"--> Application Name     -- {appName}\n" +
                $"--> Username             -- {options.ConnectionUsername}\n" +
                $"--> Password             -- {options.ConnectionPassword}\n" +
                $"--> Environment          -- {environmentTag}\n" +
                $"--> Index format sample  -- {indexFormat}");

            return new ElasticsearchSinkOptions(nodes)
            {
                IndexFormat = indexFormat,
                TypeName = null,
                AutoRegisterTemplate = true,
                BatchAction = ElasticOpType.Create,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                ModifyConnectionSettings = ModifyConnectionSettings,
                FailureCallback = e => Console.WriteLine($"Unable to submit event: {e.MessageTemplate}\\nException message:\\n{e.Exception.Message}"),
                EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog,
                CustomFormatter = new ExceptionAsObjectJsonFormatter(renderMessage: true)
            };

            ConnectionConfiguration ModifyConnectionSettings(ConnectionConfiguration connectionSettings)
            {
                return connectionSettings.BasicAuthentication(options.ConnectionUsername, options.ConnectionPassword);
            }

            static string? GetApplicationNameFromAssembly()
            {
                return Assembly.GetExecutingAssembly().GetName().Name?.ToLower().Replace(".", "-");
            }
        }
    }
}