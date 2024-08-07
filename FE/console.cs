using Microsoft.JSInterop;

namespace FE;

public class console
{
    private readonly IJSRuntime _runtime;

    public console(IJSRuntime runtime)
    {
        _runtime = runtime;
    }
    
    public void log(object o)
        => _runtime.InvokeVoidAsync("console.log", o);
}