using Elsa.Workflows.Activities;
using Elsa.Workflows.Memory;
using Elsa.Workflows.Models;

namespace Elsa.Workflows;

/// <summary>
/// A workflow pipelineBuilder collects information about a workflow to be built programmatically.
/// </summary>
public interface IWorkflowBuilder
{
    /// <summary>
    /// The definition ID to use for the workflow being built.
    /// </summary>
    string? DefinitionId { get; set; }
    
    /// <summary>
    /// The version ID to use for the workflow being built.
    /// </summary>
    string? Id { get; set; }

    /// <summary>
    /// The ID of the tenant associated with the workflow being built.
    /// </summary>
    string? TenantId { get; set; }

    /// <summary>
    /// The version of the workflow being built.
    /// </summary>
    int Version { get; set; }
    
    /// <summary>
    /// The name of the workflow.
    /// </summary>
    string? Name { get; set; }
    
    /// <summary>
    /// A description of the workflow.
    /// </summary>
    string? Description { get; set; }
    
    /// <summary>
    /// WorkflowDefinition is readonly.
    /// </summary>
    bool IsReadonly { get; set; }
    
    /// <summary>
    /// WorkflowDefinition is readonly.
    /// </summary>
    bool IsSystem { get; set; }

    /// <summary>
    /// Options for the workflow being built.
    /// </summary>
    WorkflowOptions WorkflowOptions { get; }
    
    /// <summary>
    /// The activity to execute when the workflow is run. 
    /// </summary>
    IActivity? Root { get; set; }
    
    /// <summary>
    /// The workflow variables to store with the workflow being built.
    /// </summary>
    ICollection<Variable> Variables { get; set; }
    
    /// <summary>
    /// Gets or sets the inputs.
    /// </summary>
    ICollection<InputDefinition> Inputs { get; set; }
    
    /// <summary>
    /// Gets or sets the outputs.
    /// </summary>
    ICollection<OutputDefinition> Outputs { get; set; }
    
    /// <summary>
    /// Gets or sets the outcomes.
    /// </summary>
    ICollection<string> Outcomes { get; set; }

    /// <summary>
    /// An internal variable used to get and set the result of the workflow.
    /// </summary>
    public Variable? Result { get; set; }

    /// <summary>
    /// A set of properties that can be used for storing application-specific information about the workflow being built.
    /// </summary>
    [Obsolete("Use PropertyBag instead")]
    IDictionary<string, object> CustomProperties { get; }
    
    /// <summary>
    /// A fluent method for setting the <see cref="DefinitionId"/> property.
    /// </summary>
    /// <param name="definitionId">The definition ID to use for the workflow being built.</param>
    IWorkflowBuilder WithDefinitionId(string definitionId);

    /// <summary>
    /// A fluent method for setting the <see cref="TenantId"/> property.
    /// </summary>
    /// <param name="tenantId">The tenant ID to use for the workflow being built.</param>
    IWorkflowBuilder WithTenantId(string tenantId);

    /// <summary>
    /// A fluent method for adding a variable to <see cref="Variables"/>.
    /// </summary>
    Variable<T> WithVariable<T>();
    
    /// <summary>
    /// A fluent method for adding a variable to <see cref="Variables"/>.
    /// </summary>
    Variable<T> WithVariable<T>(string name, T value);
    
    /// <summary>
    /// A fluent method for adding a variable to <see cref="Variables"/>.
    /// </summary>
    Variable<T> WithVariable<T>(T value);
    
    /// <summary>
    /// A fluent method for adding a variable to <see cref="Variables"/>.
    /// </summary>
    IWorkflowBuilder WithVariable<T>(Variable<T> variable);
    
    /// <summary>
    /// A fluent method for adding a variable to <see cref="Variables"/>.
    /// </summary>
    IWorkflowBuilder WithVariable(Variable variable);
    
    /// <summary>
    /// A fluent method for adding a variable to <see cref="Variables"/>.
    /// </summary>
    IWorkflowBuilder WithVariables(params Variable[] variables);
    
    /// <summary>
    /// A fluent method for adding an input to <see cref="Inputs"/>.
    /// </summary>
    InputDefinition WithInput<T>(string name, string? description = default);
    
    /// <summary>
    /// A fluent method for adding an input to <see cref="Inputs"/>.
    /// </summary>
    InputDefinition WithInput(string name, Type type, string? description = default);
    
    /// <summary>
    /// A fluent method for adding an input to <see cref="Inputs"/>.
    /// </summary>
    InputDefinition WithInput(string name, Type type, Action<InputDefinition>? setup = default);
    
    /// <summary>
    /// A fluent method for adding an input to <see cref="Inputs"/>.
    /// </summary>
    InputDefinition WithInput(Action<InputDefinition> setup);
    
    /// <summary>
    /// A fluent method for adding an input to <see cref="Inputs"/>.
    /// </summary>
    IWorkflowBuilder WithInput(InputDefinition inputDefinition);
    
    /// <summary>
    /// A fluent method for adding an output to <see cref="Outputs"/>.
    /// </summary>
    OutputDefinition WithOutput<T>(string name, string? description = default);
    
    /// <summary>
    /// A fluent method for adding an output to <see cref="Outputs"/>.
    /// </summary>
    OutputDefinition WithOutput(string name, Type type, string? description = default);
    
    /// <summary>
    /// A fluent method for adding an output to <see cref="Outputs"/>.
    /// </summary>
    OutputDefinition WithOutput(string name, Type type, Action<OutputDefinition>? setup = default);
    
    /// <summary>
    /// A fluent method for adding an output to <see cref="Outputs"/>.
    /// </summary>
    OutputDefinition WithOutput(Action<OutputDefinition> setup);
    
    /// <summary>
    /// A fluent method for adding an output to <see cref="Outputs"/>.
    /// </summary>
    OutputDefinition WithOutput(OutputDefinition outputDefinition);

    /// <summary>
    /// A fluent method for adding a property to <see cref="CustomProperties"/>.
    /// </summary>
    IWorkflowBuilder WithCustomProperty(string name, object value);

    /// <summary>
    /// Configure the workflow to use the specified <see cref="IWorkflowActivationStrategy"/> type.
    /// </summary>
    IWorkflowBuilder WithActivationStrategyType<T>() where T : IWorkflowActivationStrategy;

    /// <summary>
    /// Marks the workflow as readonly.
    /// </summary>
    IWorkflowBuilder AsReadonly();
    
    /// <summary>
    /// Marks the workflow as a system workflow.
    /// </summary>
    IWorkflowBuilder AsSystemWorkflow();

    /// <summary>
    /// Build a new <see cref="Workflow"/> instance using the information collected in this pipelineBuilder.
    /// </summary>
    Task<Workflow> BuildWorkflowAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Creates a new <see cref="Workflow"/> instance using the specified <see cref="IWorkflow"/> definition.
    /// </summary>
    Task<Workflow> BuildWorkflowAsync(IWorkflow workflowDefinition, CancellationToken cancellationToken = default);
}