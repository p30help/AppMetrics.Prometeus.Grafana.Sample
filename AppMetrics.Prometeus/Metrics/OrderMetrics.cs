using App.Metrics;

namespace AppMetrics.Prometues.Metrics
{
    public class OrderMetrics : IOrderMetrics
    {
        private readonly IMetrics _metrics;

        public OrderMetrics(IMetrics metrics)
        {
            _metrics = metrics;
        }

        public void IncreamentCreateOrder()
        {
            _metrics.Measure.Counter.Increment(new App.Metrics.Counter.CounterOptions()
            {
                Name = "Create Order",
                Context = "Orders",
                MeasurementUnit = Unit.Calls,
            });
        }

        public void IncreamentGetOrder()
        {
            _metrics.Measure.Counter.Increment(new App.Metrics.Counter.CounterOptions()
            {
                Name = "Get Orders",
                Context = "Orders",
                MeasurementUnit = Unit.Calls,
            });
        }
    }
}
