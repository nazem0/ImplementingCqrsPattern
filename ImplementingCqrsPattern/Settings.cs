using ImplementingCqrsPattern.Constants;

namespace ImplementingCqrsPattern;

public class Settings(IConfiguration configuration)
{
    public string ConnectionString = configuration.GetConnectionString(AppConstants.ConnectionStringName)!;
}
