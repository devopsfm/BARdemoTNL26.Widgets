using Xunit;
using BARdemoTNL26.Widgets;

namespace BARdemoTNL26.Widgets.Tests;

public class WidgetTests
{
    [Fact]
    public void Spin_IncrementsSpins()
    {
        var widget = new Widget("demo");

        widget.Spin();
        widget.Spin();

        Assert.Equal(2, widget.Spins);
    }
}
