# FocusTrapJs

All documentation on this site and parameters were taken from this documentation.

[Visit FocusTrapJs website](https://github.com/focus-trap/focus-trap)

### Installation

`dotnet add package Blazor.FocusTrapJs`

Program.cs

`builder.Services.AddScoped<FocusTrapJsProvider>();`

### Description

This is a basic library that provides access to the `focus-trap` library and makes it easy to capture focus within a DOM node.

There may come a time when you find it important to catch focus inside a DOM node - so that when the user presses Tab or Shift+Tab or clicks the mouse, the user cannot escape from a particular loop of focused elements.

### Examples

The template must have `tabindex` otherwise nothing will work.

```razor
@inherits FocusTrapComponent
@implements IAsyncDisposable

<div id="@_id">
    <div tabindex="0"></div>
</div>

@code {
    
    private string _id => $"F{GetHashCode()}";
    
    [Inject] public required FocusTrapJsProvider FocusTrap { get; set; }
    
    [Parameter] public EventCallback<bool> OnFocusChanged { get; set; }
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await FocusTrap.InitTrap(_id, DotObj, Settings);
        }

        await base.OnAfterRenderAsync(firstRender);
    }
    
    [JSInvokable]
    public override async ValueTask OnActivate()
    {
        await OnFocusChanged.InvokeAsync(true);
    }

    [JSInvokable]
    public override async ValueTask OnDeactivate()
    {
        await OnFocusChanged.InvokeAsync(false);
    }
 
    public async ValueTask DisposeAsync()
    {
        await FocusTrap.RemoveTrap(_id);
    }
}

```
