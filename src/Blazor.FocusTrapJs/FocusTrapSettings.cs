using System.ComponentModel;

namespace Blazor.FocusTrapJs;

public class FocusTrapSettings
{
    /// <summary>
    /// If true, the activation process will run immediately after the initialization completes.
    /// </summary>
    [DefaultValue(false)]
    public bool AutoActivate { get; set; }

    /// <summary>
    /// If false or returns false, the Escape key will not trigger deactivation of the focus trap.
    /// This can be useful if you want to force the user to make a decision instead of allowing an easy way out.
    /// Note that if a function is given, it's only called if the ESC key was pressed.
    /// </summary>
    [DefaultValue(true)]
    public bool EscapeDeactivates { get; set; } = true;

    /// <summary>
    /// If true or returns true, a click outside the focus trap will immediately deactivate the focus trap
    /// and allow the click event to do its thing (i.e. to pass-through to the element that was clicked).
    /// This option takes precedence over allowOutsideClick when it's set to true.
    /// </summary>
    [DefaultValue(false)]
    public bool ClickOutsideDeactivates { get; set; }

    /// <summary>
    /// If set and is or returns true, a click outside the focus trap will not be prevented
    /// (letting focus temporarily escape the trap, without deactivating it), even if clickOutsideDeactivates=false.
    /// </summary>
    [DefaultValue(false)]
    public bool AllowOutsideClick { get; set; }

    /// <summary>
    /// If false, when the trap is deactivated, focus will not return to the element that had focus before activation.
    /// </summary>
    [DefaultValue(false)]
    public bool ReturnFocusOnDeactivate { get; set; }

    /// <summary>
    /// By default, on deactivation, if returnFocusOnDeactivate=true (or if returnFocus=true in the deactivation options),
    /// focus will be returned to the element that was focused just before activation.
    /// With this option, you can specify another element to programmatically receive focus after deactivation.
    /// It can be a DOM node, a selector string (which will be passed to document.querySelector() to find the DOM node upon deactivation),
    /// or a function that returns any of these to call upon deactivation (i.e. the selector and function options are only executed at the time the trap is deactivated).
    /// Can also be false (or return false) to leave focus where it is at the time of deactivation.
    /// </summary>
    [DefaultValue(null)]
    public string? SetReturnFocusId { get; set; }

    /// <summary>
    /// By default, focus() will scroll to the element if not in viewport.
    /// It can produce unintended effects like scrolling back to the top of a modal. If set to true, no scroll will happen.
    /// </summary>
    [DefaultValue(true)]
    public bool PreventScroll { get; set; } = true;

    /// <summary>
    /// Delays the autofocus to the next execution frame when the focus trap is activated.
    /// This prevents elements within the focusable element from capturing the event that triggered the focus trap activation.
    /// </summary>
    [DefaultValue(false)]
    public bool DelayInitialFocus { get; set; }

    /// <summary>
    /// Determines if the given keyboard event is a "tab backward" event that will move the focus to the previous trapped
    /// element in tab order. Defaults to the SHIFT+TAB key. Use this to override the trap's behavior if you want to use arrow
    /// keys to control keyboard navigation within the trap, for example.
    /// </summary>
    [DefaultValue(false)]
    public bool IsKeyBackward { get; set; }

    /// <summary>
    /// Determines if the given keyboard event is a "tab forward" event that will move the focus to the next trapped element in tab order.
    /// Defaults to the TAB key. Use this to override the trap's behavior if you want to use arrow keys to control
    /// keyboard navigation within the trap, for example.
    /// </summary>
    [DefaultValue(false)]
    public bool IsKeyForward { get; set; }
}