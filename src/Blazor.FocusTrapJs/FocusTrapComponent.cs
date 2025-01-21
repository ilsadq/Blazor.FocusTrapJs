using System.ComponentModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.FocusTrapJs;

public abstract class FocusTrapComponent : ComponentBase
{
    protected FocusTrapSettings Settings = new();
    protected DotNetObjectReference<FocusTrapComponent> DotObj = null!;

    #region Props

    [Parameter]
    [DefaultValue(false)]
    public bool AutoActivate
    {
        get => Settings.AutoActivate;
        set => Settings.AutoActivate = value;
    }

    [Parameter]
    [DefaultValue(true)]
    public bool EscapeDeactivates
    {
        get => Settings.EscapeDeactivates;
        set => Settings.EscapeDeactivates = value;
    }

    [Parameter]
    [DefaultValue(false)]
    public bool ClickOutsideDeactivates
    {
        get => Settings.ClickOutsideDeactivates;
        set => Settings.ClickOutsideDeactivates = value;
    }

    [Parameter]
    [DefaultValue(false)]
    public bool AllowOutsideClick
    {
        get => Settings.AllowOutsideClick;
        set => Settings.AllowOutsideClick = value;
    }

    [Parameter]
    [DefaultValue(false)]
    public bool ReturnFocusOnDeactivate
    {
        get => Settings.ReturnFocusOnDeactivate;
        set => Settings.ReturnFocusOnDeactivate = value;
    }

    [Parameter]
    [DefaultValue(null)]
    public string? SetReturnFocusId
    {
        get => Settings.SetReturnFocusId;
        set => Settings.SetReturnFocusId = value;
    }

    [Parameter]
    [DefaultValue(true)]
    public bool PreventScroll
    {
        get => Settings.PreventScroll;
        set => Settings.PreventScroll = value;
    }

    [Parameter]
    [DefaultValue(false)]
    public bool DelayInitialFocus
    {
        get => Settings.DelayInitialFocus;
        set => Settings.DelayInitialFocus = value;
    }

    [Parameter]
    [DefaultValue(false)]
    public bool IsKeyBackward
    {
        get => Settings.IsKeyBackward;
        set => Settings.IsKeyBackward = value;
    }

    [Parameter]
    [DefaultValue(false)]
    public bool IsKeyForward
    {
        get => Settings.IsKeyForward;
        set => Settings.IsKeyForward = value;
    }

    #endregion

    protected override void OnParametersSet()
    {
        DotObj = DotNetObjectReference.Create(this);
        base.OnParametersSet();
    }

    #region Handlers

    /// <summary>
    /// A function that will be called before sending focus to the target element upon activation.
    /// </summary>
    /// <returns></returns>
    [JSInvokable]
    public abstract ValueTask OnActivate();

    /// <summary>
    /// A function that will be called after sending focus to the target element upon activation.
    /// </summary>
    /// <returns></returns>
    [JSInvokable]
    public virtual ValueTask OnPostActivate()
    {
        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// A function that will be called immediately after the trap's state is updated to be paused.
    /// </summary>
    /// <returns></returns>
    [JSInvokable]
    public virtual ValueTask OnPause()
    {
        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// A function that will be called after the trap has been completely paused and is no longer managing/trapping focus.
    /// </summary>
    /// <returns></returns>
    [JSInvokable]
    public virtual ValueTask OnPostPause()
    {
        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// A function that will be called immediately after the trap's state is updated to be active again,
    /// but prior to updating its knowledge of what nodes are tabbable within its containers,
    /// and prior to actively managing/trapping focus.
    /// </summary>
    /// <returns></returns>
    [JSInvokable]
    public virtual ValueTask OnUnpause()
    {
        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// A function that will be called after the trap has been completely unpaused and is once again managing/trapping focus.
    /// </summary>
    /// <returns></returns>
    [JSInvokable]
    public virtual ValueTask OnPostUnpause()
    {
        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// A function that will be called before returning focus to the node that had focus prior to activation (or configured with the setReturnFocus option) upon deactivation.
    /// </summary>
    /// <returns></returns>
    [JSInvokable]
    public abstract ValueTask OnDeactivate();

    /// <summary>
    /// A function that will be called after the trap is deactivated, after onDeactivate.
    /// If the returnFocus deactivation option was set, it will be called after returning
    /// focus to the node that had focus prior to activation (or configured with the setReturnFocus option)
    /// upon deactivation; otherwise, it will be called after deactivation completes.
    /// </summary>
    /// <returns></returns>
    [JSInvokable]
    public virtual ValueTask OnPostDeactivate()
    {
        return ValueTask.CompletedTask;
    }

    #endregion
}