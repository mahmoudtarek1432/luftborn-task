using SharedKernel.Configurations;

namespace luftborn_task.Extentions
{
    public static class ConfigExtentions
    {
        public static ConnectionStrings GetConnectionStrings(this IConfiguration configuration)
        {
            var section = configuration?.GetSection("ConnectionStrings");
            var data = new ConnectionStrings();
            section.Bind(data);

            return data;
        }
    }
}
