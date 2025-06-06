using Elsa.Workflows.Memory;

namespace Elsa.Workflows.Models;

/// <summary>
/// Represents a work item that can be scheduled for execution.
/// </summary>
public class ActivityWorkItem
{
    /// <summary>
    /// Creates a new instance of the <see cref="ActivityWorkItem"/> class.
    /// </summary>
    public ActivityWorkItem(
        IActivity activity,
        ActivityExecutionContext? owner = null,
        object? tag = null,
        IEnumerable<Variable>? variables = null,
        ActivityExecutionContext? existingActivityExecutionContext = null,
        IDictionary<string, object>? input = null)
    {
        Activity = activity;
        Owner = owner;
        Tag = tag;
        Variables = variables;
        ExistingActivityExecutionContext = existingActivityExecutionContext;
        Input = input ?? new Dictionary<string, object>();
    }

    /// <summary>
    /// The activity to be executed.
    /// </summary>
    public IActivity Activity { get; }

    /// <summary>
    /// The activity execution context that owns this work item, if any.
    /// </summary>
    public ActivityExecutionContext? Owner { get; set; }

    /// <summary>
    /// A tag that can be used to identify the work item.
    /// </summary>
    public object? Tag { get; set; }

    /// <summary>
    /// A set of variables to be created as part of the activity execution context.
    /// </summary>
    public IEnumerable<Variable>? Variables { get; set; }

    /// <summary>
    /// An existing activity execution context to schedule, if any.
    /// </summary>
    public ActivityExecutionContext? ExistingActivityExecutionContext { get; set; }

    /// <summary>
    /// Optional input to pass to the activity.
    /// </summary>
    public IDictionary<string, object> Input { get; set; }
}