// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.5.0.0
//      Runtime Version:4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace ServerSpecs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.5.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Schedule Evaluator")]
    public partial class ScheduleEvaluatorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ScheduleEvaluator.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Schedule Evaluator", "In determine when next to execute a task\nAs a developer\nI want to be told what th" +
                    "e next execution time should be", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Determine the next execution of a default every hour schedule")]
        public virtual void DetermineTheNextExecutionOfADefaultEveryHourSchedule()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Determine the next execution of a default every hour schedule", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
 testRunner.Given("I have last execute time of \'2011-03-09 00:01:02.000\'");
#line 13
 testRunner.And("I have a schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\'");
#line 14
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs every \'1\'" +
                    " \'hr\'");
#line 15
 testRunner.When("I get the next execution date for the schedule with the id of \'1FF02F94-ED9C-43D4" +
                    "-B5DD-96C13C6C607A\'");
#line 16
 testRunner.Then("I should have an execution date of \'2011-03-09 01:01:02.000\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Determine the next execution of an every 20 minutes schedule")]
        public virtual void DetermineTheNextExecutionOfAnEvery20MinutesSchedule()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Determine the next execution of an every 20 minutes schedule", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
 testRunner.Given("I have last execute time of \'2011-03-09 00:01:02.000\'");
#line 20
 testRunner.And("I have a schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\'");
#line 21
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs every \'20" +
                    "\' \'mm\'");
#line 22
 testRunner.When("I get the next execution date for the schedule with the id of \'1FF02F94-ED9C-43D4" +
                    "-B5DD-96C13C6C607A\'");
#line 23
 testRunner.Then("I should have an execution date of \'2011-03-09 00:21:02.000\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Determine the next execution of an every 12 hour schedule")]
        public virtual void DetermineTheNextExecutionOfAnEvery12HourSchedule()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Determine the next execution of an every 12 hour schedule", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
 testRunner.Given("I have last execute time of \'2011-03-09 00:01:02.000\'");
#line 27
 testRunner.And("I have a schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\'");
#line 28
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs every \'12" +
                    "\' \'hr\'");
#line 29
 testRunner.When("I get the next execution date for the schedule with the id of \'1FF02F94-ED9C-43D4" +
                    "-B5DD-96C13C6C607A\'");
#line 30
 testRunner.Then("I should have an execution date of \'2011-03-09 12:01:02.000\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Determine the next execution of once a day schedule that runs prior to the normal" +
            " start time")]
        public virtual void DetermineTheNextExecutionOfOnceADayScheduleThatRunsPriorToTheNormalStartTime()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Determine the next execution of once a day schedule that runs prior to the normal" +
                    " start time", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
 testRunner.Given("I have last execute time of \'2011-03-09 00:01:02.000\'");
#line 34
 testRunner.And("I have a schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\'");
#line 35
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs every \'1\'" +
                    " day");
#line 36
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs at the sp" +
                    "ecific time of \'02:00:00\'");
#line 37
 testRunner.When("I get the next execution date for the schedule with the id of \'1FF02F94-ED9C-43D4" +
                    "-B5DD-96C13C6C607A\'");
#line 38
 testRunner.Then("I should have an execution date of \'2011-03-09 02:00:00.000\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Determine the next execution of once a day schedule that runs on schedule")]
        public virtual void DetermineTheNextExecutionOfOnceADayScheduleThatRunsOnSchedule()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Determine the next execution of once a day schedule that runs on schedule", ((string[])(null)));
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
 testRunner.Given("I have last execute time of \'2011-03-09 02:01:02.000\'");
#line 42
 testRunner.And("I have a schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\'");
#line 43
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs every \'1\'" +
                    " day");
#line 44
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs at the sp" +
                    "ecific time of \'02:00:00\'");
#line 45
 testRunner.When("I get the next execution date for the schedule with the id of \'1FF02F94-ED9C-43D4" +
                    "-B5DD-96C13C6C607A\'");
#line 46
 testRunner.Then("I should have an execution date of \'2011-03-10 02:00:00.000\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Determine the next execution of once a day schedule that runs at a list times")]
        public virtual void DetermineTheNextExecutionOfOnceADayScheduleThatRunsAtAListTimes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Determine the next execution of once a day schedule that runs at a list times", ((string[])(null)));
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
 testRunner.Given("I have last execute time of \'2011-03-09 02:01:02.000\'");
#line 50
 testRunner.And("I have a schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\'");
#line 51
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs every \'1\'" +
                    " day");
#line 52
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs at this l" +
                    "ist of times \'02:00, 12:00, 18:00\'");
#line 53
 testRunner.When("I get the next execution date for the schedule with the id of \'1FF02F94-ED9C-43D4" +
                    "-B5DD-96C13C6C607A\'");
#line 54
 testRunner.Then("I should have an execution date of \'2011-03-09 12:00:00.000\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Determine the next execution of once a day schedule that runs at a list times tha" +
            "t ran for the last time for the day")]
        public virtual void DetermineTheNextExecutionOfOnceADayScheduleThatRunsAtAListTimesThatRanForTheLastTimeForTheDay()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Determine the next execution of once a day schedule that runs at a list times tha" +
                    "t ran for the last time for the day", ((string[])(null)));
#line 56
this.ScenarioSetup(scenarioInfo);
#line 57
 testRunner.Given("I have last execute time of \'2011-03-09 18:01:02.000\'");
#line 58
 testRunner.And("I have a schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\'");
#line 59
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs every \'1\'" +
                    " day");
#line 60
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs at this l" +
                    "ist of times \'02:00, 12:00, 18:00\'");
#line 61
 testRunner.When("I get the next execution date for the schedule with the id of \'1FF02F94-ED9C-43D4" +
                    "-B5DD-96C13C6C607A\'");
#line 62
 testRunner.Then("I should have an execution date of \'2011-03-10 02:00:00.000\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Determine the next execution of an every 2 day schedule that runs at a list times" +
            " that ran for the last time for the day")]
        public virtual void DetermineTheNextExecutionOfAnEvery2DayScheduleThatRunsAtAListTimesThatRanForTheLastTimeForTheDay()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Determine the next execution of an every 2 day schedule that runs at a list times" +
                    " that ran for the last time for the day", ((string[])(null)));
#line 64
this.ScenarioSetup(scenarioInfo);
#line 65
 testRunner.Given("I have last execute time of \'2011-03-09 18:01:02.000\'");
#line 66
 testRunner.And("I have a schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\'");
#line 67
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs every \'2\'" +
                    " day");
#line 68
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs at this l" +
                    "ist of times \'02:00, 12:00, 18:00\'");
#line 69
 testRunner.When("I get the next execution date for the schedule with the id of \'1FF02F94-ED9C-43D4" +
                    "-B5DD-96C13C6C607A\'");
#line 70
 testRunner.Then("I should have an execution date of \'2011-03-11 02:00:00.000\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Determine the next execution of an every 2 day schedule that runs at a list times" +
            "")]
        public virtual void DetermineTheNextExecutionOfAnEvery2DayScheduleThatRunsAtAListTimes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Determine the next execution of an every 2 day schedule that runs at a list times" +
                    "", ((string[])(null)));
#line 72
this.ScenarioSetup(scenarioInfo);
#line 73
 testRunner.Given("I have last execute time of \'2011-03-09 02:01:02.000\'");
#line 74
 testRunner.And("I have a schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\'");
#line 75
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs every \'2\'" +
                    " day");
#line 76
 testRunner.And("the schedule with the id of \'1FF02F94-ED9C-43D4-B5DD-96C13C6C607A\' runs at this l" +
                    "ist of times \'02:00, 12:00, 18:00\'");
#line 77
 testRunner.When("I get the next execution date for the schedule with the id of \'1FF02F94-ED9C-43D4" +
                    "-B5DD-96C13C6C607A\'");
#line 78
 testRunner.Then("I should have an execution date of \'2011-03-09 12:00:00.000\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
