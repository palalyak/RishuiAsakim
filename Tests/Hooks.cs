using BoDi;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace Tests
{


    [Binding]
    public sealed class Hooks : TechTalk.SpecFlow.Steps
    {
        ScenarioContext _scenarioContext;
        private static IConfigurationRoot _configuration;
  

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }

        [BeforeScenario]
        public void BeforeTestRun()
        {
            _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            _scenarioContext.Set(_configuration);



            //IConfiguration config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .Build();
            //_container.RegisterInstanceAs<IConfiguration>(config);

        }

        [BeforeScenario("ser003")]
        public void BeforeScenarioWithTag()
        {
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping

        }

        //[BeforeScenario(Order = 1)]
        //public void FirstBeforeScenario()
        //{
        //    // Example of ordering the execution of hooks
        //    // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

        //    //TODO: implement logic that has to run before executing each scenario
        //}

        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    //TODO: implement logic that has to run after executing each scenario
        //}
    }
}