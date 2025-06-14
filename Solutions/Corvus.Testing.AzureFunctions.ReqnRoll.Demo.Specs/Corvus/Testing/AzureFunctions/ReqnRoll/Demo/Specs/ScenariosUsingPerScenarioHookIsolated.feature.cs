﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
using Reqnroll;
namespace Corvus.Testing.AzureFunctions.ReqnRoll.Demo.Specs
{
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Feature using per-scenario hook isolated")]
    [NUnit.Framework.FixtureLifeCycleAttribute(NUnit.Framework.LifeCycle.InstancePerTestCase)]
    [NUnit.Framework.CategoryAttribute("usingIsolatedDemoFunctionPerScenario")]
    public partial class FeatureUsingPer_ScenarioHookIsolatedFeature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "usingIsolatedDemoFunctionPerScenario"};
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new global::System.Globalization.CultureInfo("en-US"), "Corvus/Testing/AzureFunctions/ReqnRoll/Demo/Specs", "Feature using per-scenario hook isolated", "\tIn order to test my Azure functions\r\n\tAs a developer\r\n\tI want to be able to star" +
                "t an Azure function for each scenario using a hook", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
#line 1 "ScenariosUsingPerScenarioHookIsolated.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public static async global::System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public static async global::System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async global::System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            try
            {
                if (((testRunner.FeatureContext != null) 
                            && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
                {
                    await testRunner.OnFeatureEndAsync();
                }
            }
            finally
            {
                if (((testRunner.FeatureContext != null) 
                            && testRunner.FeatureContext.BeforeFeatureHookFailed))
                {
                    throw new global::Reqnroll.ReqnrollException("Scenario skipped because of previous before feature hook error");
                }
                if ((testRunner.FeatureContext == null))
                {
                    await testRunner.OnFeatureStartAsync(featureInfo);
                }
            }
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async global::System.Threading.Tasks.Task TestTearDownAsync()
        {
            if ((testRunner == null))
            {
                return;
            }
            try
            {
                await testRunner.OnScenarioEndAsync();
            }
            finally
            {
                global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
                testRunner = null;
            }
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async global::System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async global::System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A Get request including a name in the querystring is successful")]
        public async global::System.Threading.Tasks.Task AGetRequestIncludingANameInTheQuerystringIsSuccessful()
        {
            string[] tagsOfScenario = ((string[])(null));
            global::System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new global::System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("A Get request including a name in the querystring is successful", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 9
 await testRunner.WhenAsync("I send a GET request to \'http://localhost:7075/?name=Jon\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 10
 await testRunner.ThenAsync("I receive a 200 response code", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 11
 await testRunner.AndAsync("the response body contains the text \'Hello, Jon\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A Get request without providing a name in the querystring fails.")]
        public async global::System.Threading.Tasks.Task AGetRequestWithoutProvidingANameInTheQuerystringFails_()
        {
            string[] tagsOfScenario = ((string[])(null));
            global::System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new global::System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("A Get request without providing a name in the querystring fails.", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 13
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 14
 await testRunner.WhenAsync("I send a GET request to \'http://localhost:7075/\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 15
 await testRunner.ThenAsync("I receive a 400 response code", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A Post request including a name in the querystring is successful")]
        public async global::System.Threading.Tasks.Task APostRequestIncludingANameInTheQuerystringIsSuccessful()
        {
            string[] tagsOfScenario = ((string[])(null));
            global::System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new global::System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("A Post request including a name in the querystring is successful", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 17
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 18
 await testRunner.WhenAsync("I send a POST request to \'http://localhost:7075/?name=Jon\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 19
 await testRunner.ThenAsync("I receive a 200 response code", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 20
 await testRunner.AndAsync("the response body contains the text \'Hello, Jon\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A Post request including a name in the request body is successful")]
        public async global::System.Threading.Tasks.Task APostRequestIncludingANameInTheRequestBodyIsSuccessful()
        {
            string[] tagsOfScenario = ((string[])(null));
            global::System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new global::System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("A Post request including a name in the request body is successful", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 22
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table7 = new global::Reqnroll.Table(new string[] {
                            "PropertyName",
                            "Value"});
                table7.AddRow(new string[] {
                            "name",
                            "Jon"});
#line 23
 await testRunner.WhenAsync("I send a POST request to \'http://localhost:7075/\' with data in the request body", ((string)(null)), table7, "When ");
#line hidden
#line 26
 await testRunner.ThenAsync("I receive a 200 response code", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 27
 await testRunner.AndAsync("the response body contains the text \'Hello, Jon\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A Post request including names in the querystring and request body uses the name " +
            "in the querystring")]
        public async global::System.Threading.Tasks.Task APostRequestIncludingNamesInTheQuerystringAndRequestBodyUsesTheNameInTheQuerystring()
        {
            string[] tagsOfScenario = ((string[])(null));
            global::System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new global::System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("A Post request including names in the querystring and request body uses the name " +
                    "in the querystring", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 29
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table8 = new global::Reqnroll.Table(new string[] {
                            "PropertyName",
                            "Value"});
                table8.AddRow(new string[] {
                            "name",
                            "Jonathan"});
#line 30
 await testRunner.WhenAsync("I send a POST request to \'http://localhost:7075/?name=Jon\' with data in the reque" +
                        "st body", ((string)(null)), table8, "When ");
#line hidden
#line 33
 await testRunner.ThenAsync("I receive a 200 response code", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 34
 await testRunner.AndAsync("the response body contains the text \'Hello, Jon\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A Post request without a querystring or request body fails")]
        public async global::System.Threading.Tasks.Task APostRequestWithoutAQuerystringOrRequestBodyFails()
        {
            string[] tagsOfScenario = ((string[])(null));
            global::System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new global::System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("A Post request without a querystring or request body fails", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 36
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 37
 await testRunner.WhenAsync("I send a POST request to \'http://localhost:7075/\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 38
 await testRunner.ThenAsync("I receive a 400 response code", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
