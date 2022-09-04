using App.Metrics.Formatters.Prometheus;
using AppMetrics.Prometues.Metrics;

/////////////////////////////////////////////////////////
// Run [docker-compose up] and then visit under links
// http://localhost:9090/targets Prometues Targets 
// http://localhost:8585 Metrics App
// http://localhost:3000 Grafana 
// note: If you want to remove contrainers and volumes just run [docker-compose down -v]


var builder = WebApplication.CreateBuilder(args);

// Add Metrics
builder.Host.UseMetricsWebTracking();
builder.Host.UseMetricsEndpoints(options =>
{
    options.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
    options.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
    options.EnvironmentInfoEndpointEnabled = false;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Metrics services
builder.Services.AddMetrics();
builder.Services.AddScoped<IOrderMetrics, OrderMetrics>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//////////////////////////////////////////////
// For more information read this links
// https://medium.com/@niteshsinghal85/opentelemetry-with-jaeger-in-net-core-9b1e009a73dc
// https://www.youtube.com/watch?v=tIvHAxs8Fec
// https://grafana.com/docs/grafana-cloud/quickstart/docker-compose-linux/
// https://github.com/vegasbrianc/prometheus/blob/master/prometheus/prometheus.yml
// https://github.com/vegasbrianc/prometheus
// https://www.youtube.com/watch?v=sM7D8biBf4k&t=9s
// https://grafana.com/docs/grafana-cloud/quickstart/docker-compose-linux/
// https://citizix.com/how-to-run-prometheus-with-docker-and-docker-compose/
// https://medium.com/aeturnuminc/configure-prometheus-and-grafana-in-dockers-ff2a2b51aa1d
// https://www.youtube.com/watch?v=EH9Wokoi5l0
// https://levelup.gitconnected.com/metrics-reliably-configuring-prometheus-and-grafana-with-docker-2077541c8e6d
// https://grafana.com/grafana/dashboards/2204-app-metrics-web-monitoring-prometheus/ (App metrics Grafana dashboard)
