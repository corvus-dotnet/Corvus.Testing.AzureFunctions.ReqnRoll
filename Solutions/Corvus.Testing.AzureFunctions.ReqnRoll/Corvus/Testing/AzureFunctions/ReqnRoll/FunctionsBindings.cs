﻿// <copyright file="FunctionsBindings.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Testing.AzureFunctions.ReqnRoll;

using System.Threading.Tasks;

using Corvus.Testing.AzureFunctions;
using Corvus.Testing.ReqnRoll;

using Microsoft.Extensions.Logging;

using Reqnroll;

/// <summary>
/// ReqnRoll bindings to support Azure Functions.
/// </summary>
[Binding]
public class FunctionsBindings
{
    private static readonly ILoggerFactory Log = LoggerFactory.Create(builder => builder.AddConsole());

    private readonly ScenarioContext scenarioContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="FunctionsBindings"/> class.
    /// </summary>
    /// <param name="scenarioContext">The current scenario context.</param>
    public FunctionsBindings(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
    }

    /// <summary>
    /// Retrieves the current functions controller from the supplied context.
    /// </summary>
    /// <param name="context">The ReqnRoll context to retrieve from.</param>
    /// <returns>The FunctionsController.</returns>
    /// <remarks>
    /// If the controller hasn't already been added to the context, this method will create
    /// and add a new instance.
    /// </remarks>
    public static FunctionsController GetFunctionsController(ReqnrollContext context)
    {
        if (!context.TryGetValue(out ILogger logger))
        {
            logger = Log.CreateLogger<FunctionsController>();
            context.Set(logger);
        }

        if (!context.TryGetValue(out FunctionsController controller))
        {
            controller = new FunctionsController(logger);
            context.Set(controller);
        }

        return controller;
    }

    /// <summary>
    /// Retrieves the <see cref="FunctionConfiguration"/> from the context.
    /// </summary>
    /// <param name="context">The context in which the configuration is stored.</param>
    /// <returns>The <see cref="FunctionConfiguration"/>.</returns>
    /// <remarks>
    /// If a <see cref="FunctionConfiguration"/> hasn't already been added to the context,
    /// this method will create and add a new instance.
    /// </remarks>
    public static FunctionConfiguration GetFunctionConfiguration(ReqnrollContext context)
    {
        if (!context.TryGetValue(out FunctionConfiguration value))
        {
            value = new FunctionConfiguration();
            context.Set(value);
        }

        return value;
    }

    /// <summary>
    /// Start a functions instance.
    /// </summary>
    /// <param name="path">The location of the functions project.</param>
    /// <param name="port">The port on which to start the functions instance.</param>
    /// <returns>A task that completes once the function instance has started.</returns>
    [Given(@"I start a functions instance for the local project '([^']*)' on port (\d*)")]
    public Task StartAFunctionsInstance(string path, int port)
    {
        return GetFunctionsController(this.scenarioContext)
            .StartFunctionsInstanceAsync(path, port, "net8.0");
    }

    /// <summary>
    ///     Start a functions instance.
    /// </summary>
    /// <param name="path">The location of the functions project.</param>
    /// <param name="port">The port on which to start the functions instance.</param>
    /// <param name="runtime">The id of the runtime to use.</param>
    /// <returns>A task that completes once the function instance has started.</returns>
    [Given(@"I start a functions instance for the local project '([^']*)' on port (\d*) with runtime '([^']*)'")]
    public Task StartAFunctionsInstance(string path, int port, string runtime)
    {
        FunctionConfiguration configuration = FunctionsBindings.GetFunctionConfiguration(this.scenarioContext);
        return GetFunctionsController(this.scenarioContext)
            .StartFunctionsInstanceAsync(path, port, runtime, "csharp", configuration);
    }

    /// <summary>
    ///     Tear down the running functions instances for the scenario.
    /// </summary>
    /// <returns>A task that completes once the functions instances have been torn down.</returns>
    [AfterScenario]
    public async Task TeardownFunctionsAfterScenario()
    {
        await this.scenarioContext.RunAndStoreExceptionsAsync(async () => await GetFunctionsController(this.scenarioContext).TeardownFunctionsAsync().ConfigureAwait(false));
    }
}