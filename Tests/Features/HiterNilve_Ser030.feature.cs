﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("HiterNilve_Ser030")]
    public partial class HiterNilve_Ser030Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "HiterNilve_Ser030.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "HiterNilve_Ser030", "A short summary of the feature", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("חידוש_היתר_לילה")]
        [NUnit.Framework.CategoryAttribute("Test")]
        [NUnit.Framework.TestCaseAttribute("5", "2", "\'23:55\'", "\'-01-11-00T00:00\'", "\'+01-00-00T00:00\'", null)]
        [NUnit.Framework.TestCaseAttribute("10", "7", "\'23:00\'", "\'-00-11-00T00:00\'", "\'+00-03-00T00:00\'", null)]
        [NUnit.Framework.TestCaseAttribute("10", "1", "\'23:00\'", "\'-00-11-29T00:00\'", "\'+00-12-00T00:00\'", null)]
        [NUnit.Framework.TestCaseAttribute("10", "1", "\'23:00\'", "\'-00-11-29T00:00\'", "\'+00-03-00T00:00\'", null)]
        [NUnit.Framework.TestCaseAttribute("10", "1", "\'23:00\'", "\'-00-12-29T00:00\'", "\'+00-12-00T00:00\'", null)]
        [NUnit.Framework.TestCaseAttribute("10", "1", "\'23:00\'", "\'-00-12-29T00:00\'", "\'+00-03-00T00:00\'", null)]
        [NUnit.Framework.TestCaseAttribute("10", "1", "\'23:00\'", "\'-00-12-00T00:00\'", "\'+00-12-00T00:00\'", null)]
        [NUnit.Framework.TestCaseAttribute("10", "1", "\'23:00\'", "\'-00-12-00T00:00\'", "\'+00-03-00T00:00\'", null)]
        [NUnit.Framework.TestCaseAttribute("10", "1", "\'23:00\'", "\'-01-01-00T00:00\'", "\'+00-03-00T00:00\'", null)]
        public virtual void חידוש_היתר_לילה(string kodMahutRashit, string sugIter, string requestEndHour, string hodashimLifneiHidush, string tkufatHiter, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Test"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("kodMahutRashit", kodMahutRashit);
            argumentsOfScenario.Add("SugIter", sugIter);
            argumentsOfScenario.Add("requestEndHour", requestEndHour);
            argumentsOfScenario.Add("hodashimLifneiHidush", hodashimLifneiHidush);
            argumentsOfScenario.Add("tkufatHiter", tkufatHiter);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("חידוש_היתר_לילה", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 12
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 13
 testRunner.Given("valid access token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 14
 testRunner.And(string.Format("default tik rishuy with parameters for mahut: 1, 2, {0}, 0, 10", kodMahutRashit), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
#line 16
 testRunner.And("update objects creation date \'-03-00-00T00:00\', \'essek\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
#line 17
 testRunner.When("create draft license with parameters: 7, \"2022-02-18T10:00:00.100Z\", \"2034-02-19T" +
                        "10:00:00.100Z\", 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 19
 testRunner.Then("validate hiter nilve: 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 20
 testRunner.Given(string.Format("run Ser028 create additional permit with parameters: {0}, 0, 0, 1", sugIter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 22
 testRunner.And("run Ser029 permit update with parameters: 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
#line 24
 testRunner.Then("hiter nilve created in DB: \'Yes\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 25
 testRunner.Then("validate hiter nilve: 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 27
 testRunner.Given(string.Format("update objects creation date {0}, \'hiter_nilve\'", hodashimLifneiHidush), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 28
 testRunner.Given(string.Format("run Ser062 check additional permit possibility with parameters: {0}", sugIter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 29
 testRunner.When(string.Format("run Ser030 renew additional permit {0}, {1}, 0", requestEndHour, tkufatHiter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 30
 testRunner.When("run Ser066 get business data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 31
 testRunner.Then("validate hiter nilve: 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
