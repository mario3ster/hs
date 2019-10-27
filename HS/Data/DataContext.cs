namespace HS.Data
{
    using System.Collections.Generic;
    using System.IO;
    using HS.Models;
    using Newtonsoft.Json;

    public class DataContext
    {
        public IEnumerable<TEntity> GetEntities<TEntity>() where TEntity : class
        {
            string fileNameDerivedFromTEntity = typeof(TEntity).Name;
            string entitiesJson = File.ReadAllText($"../../../Data/" + fileNameDerivedFromTEntity + "s.json");

            return JsonConvert.DeserializeObject<IEnumerable<TEntity>>(entitiesJson);
        }
    }
}
