
namespace Verbum.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(VerbumDbContext context) {
            context.Database.EnsureCreated();
        }
    }
}
