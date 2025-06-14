﻿// <copyright file="DemoFunctionPerFeatureHooks.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Testing.AzureFunctions.ReqnRoll.Demo.Specs;

using System.Threading.Tasks;

using Corvus.Testing.AzureFunctions;
using Corvus.Testing.AzureFunctions.ReqnRoll;

using Microsoft.Extensions.Logging;

using Reqnroll;

[Binding]
public static class DemoFunctionPerFeatureHooks
{
    [BeforeFeature("usingInProcessDemoFunctionPerFeature")]
    public static Task StartInProcessFunctionsAsync(FeatureContext featureContext)
    {
        FunctionsController functionsController = FunctionsBindings.GetFunctionsController(featureContext);
        FunctionConfiguration functionConfiguration = FunctionsBindings.GetFunctionConfiguration(featureContext);

        return functionsController.StartFunctionsInstanceAsync(
            "Corvus.Testing.AzureFunctions.Demo.InProcess",
            7075,
            "net8.0",
            configuration: functionConfiguration);
    }

    [BeforeFeature("usingIsolatedDemoFunctionPerFeature")]
    public static Task StartIsolatedFunctionsAsync(FeatureContext featureContext)
    {
        FunctionsController functionsController = FunctionsBindings.GetFunctionsController(featureContext);
        FunctionConfiguration functionConfiguration = FunctionsBindings.GetFunctionConfiguration(featureContext);

        return functionsController.StartFunctionsInstanceAsync(
            "Corvus.Testing.AzureFunctions.Demo.Isolated",
            7075,
            "net8.0",
            configuration: functionConfiguration);
    }

    [BeforeFeature("usingInProcessDemoFunctionPerFeatureWithAdditionalConfiguration")]
    public static Task StartInProcessFunctionWithAdditionalConfigurationAsync(FeatureContext featureContext)
    {
        DemoFunctionConfig.SetupTestConfig(featureContext);
        return StartInProcessFunctionsAsync(featureContext);
    }

    [BeforeFeature("usingIsolatedDemoFunctionPerFeatureWithAdditionalConfiguration")]
    public static Task StartIsolatedFunctionWithAdditionalConfigurationAsync(FeatureContext featureContext)
    {
        DemoFunctionConfig.SetupTestConfig(featureContext);
        return StartIsolatedFunctionsAsync(featureContext);
    }

    [AfterScenario("usingInProcessDemoFunctionPerFeature", "usingIsolatedDemoFunctionPerFeature", "usingDemoFunctionPerFeatureWithAdditionalConfiguration")]
    public static void WriteOutput(FeatureContext featureContext)
    {
        FunctionsController functionsController = FunctionsBindings.GetFunctionsController(featureContext);
        featureContext.Get<ILogger>().LogAllAndClear(functionsController.GetFunctionsOutput());
    }

    [AfterFeature(
        "usingInProcessDemoFunctionPerFeature",
        "usingIsolatedDemoFunctionPerFeature",
        "usingInProcessDemoFunctionPerFeatureWithAdditionalConfiguration",
        "usingIsolatedDemoFunctionPerFeatureWithAdditionalConfiguration")]
    public static async Task StopFunctionAsync(FeatureContext featureContext)
    {
        FunctionsController functionsController = FunctionsBindings.GetFunctionsController(featureContext);
        await functionsController.TeardownFunctionsAsync().ConfigureAwait(false);
    }
}