using Microsoft.JSInterop;

namespace Blazor.FocusTrapJs;

public class FocusTrapJsProvider(IJSRuntime js)
{
    public ValueTask InitTrap(string id, DotNetObjectReference<FocusTrapComponent> dotObj, FocusTrapSettings settings)
    {
        return js.InvokeVoidAsync("blazorFocusTrap.initFocusTrap", id, dotObj, settings);
    }

    public ValueTask ActivateTrap(string id)
    {
        return js.InvokeVoidAsync("blazorFocusTrap.activateFocusTrap", id);
    }

    public ValueTask RemoveTrap(string id)
    {
        return js.InvokeVoidAsync("blazorFocusTrap.disposeTrap", id);
    }
}