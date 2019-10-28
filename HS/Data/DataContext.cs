namespace HS.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    
    public class DataContext
    {
        public IEnumerable<TEntity> GetEntities<TEntity>() where TEntity : class
        {
            string fileNameDerivedFromTEntity = typeof(TEntity).Name;
            string entitiesJson = File.ReadAllText($"./Data/" + fileNameDerivedFromTEntity + "s.json");

            return JsonSerializer.Deserialize<IEnumerable<TEntity>>(entitiesJson);
        }
    }
}
