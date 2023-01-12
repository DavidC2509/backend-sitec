using Data.Database;
using Domain.Entities;
using Domain.Entities.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using TechTalk.SpecFlow;

namespace SystemCore.Spec.StepDefinitions
{
    [Binding]
    class ConvertStepDefinitions
    {
        private readonly ScenarioContext _context;

        public ConvertStepDefinitions(ScenarioContext scenarioContext)
        {
            _context = scenarioContext;
        }

        [Given(@"la siguiente entidad ""(.*)"" registrada")]
        public void GivenLaSiguienteEntidadRegistrada(string entityName, string data)
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(_context.Get<string>("DB_Key"))
                .Options;

            using (var context = new DataBaseContext(options,null))
            {
                switch (entityName)
                {
                    case "Producto":
                        StoreProduct(context, data);
                        break;
                   
                }
            }
        }

       
        private void StoreProduct(DataBaseContext db, string data)
        {
            var parse = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(data);

            db.Products.Add(parse);
            db.SaveChanges();

            _context.Set(parse.Id.ToString(), "RecordId");
        }

       
    }
}
