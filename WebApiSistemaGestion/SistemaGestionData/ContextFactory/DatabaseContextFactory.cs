using Entities.dataBase;
using SistemaGestionData.Interfaces;

namespace SistemaGestionData.ContextFactory
{
    public class DatabaseContextFactory : IDatabaseContextFactory
    {
        public CoderContext CreateDbContext()
        {
            return new CoderContext();
        }
    }
}
