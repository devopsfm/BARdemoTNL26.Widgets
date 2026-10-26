using Microsoft.Extensions.Logging;

namespace BARdemoTNL26.Widgets;

/// <summary>
/// A widget. It has a name and it can be spun. That is the whole product.
/// </summary>
public sealed class Widget(string name)
{
    public string Name { get; } = name;

    public int Spins { get; private set; }

    public void Spin(ILogger? logger = null)
    {
        Spins++;
        logger?.LogInformation("Widget {Name} spun {Spins} time(s)", Name, Spins);
    }
}
