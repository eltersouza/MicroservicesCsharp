using Aplication.DTOs;
using Aplication.Interfaces.Messaging;
using Confluent.Kafka;
using Core.FinanceService.Application.Configurations;
using Core.FinanceService.Application.Interfaces.UseCases;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Core.FinanceService.Infrastructure.Messaging
{
    public class EnrollmentConsumerService: IEnrollmentConsumerService
    {
        public readonly KafkaConfiguration _KafkaConfiguration;
        public readonly IEnrollStudentToCourse _enrollStudentToCourse;

        public EnrollmentConsumerService(IOptions<KafkaConfiguration> options, IEnrollStudentToCourse enrollStudentToCourse)
        {
            _KafkaConfiguration = options.Value;
            _enrollStudentToCourse = enrollStudentToCourse;
        }

        public async Task StartConsumerLoop()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _KafkaConfiguration.BootstrapServers,
                GroupId = _KafkaConfiguration.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true; // prevent the process from terminating.
                cts.Cancel();
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe(_KafkaConfiguration.Topic);

                try
                {
                    while (true)
                    {
                        var cr = consumer.Consume(cts.Token);
                        Console.WriteLine($"Consumed event from topic {_KafkaConfiguration.Topic}: key = {cr.Message.Key,-10} value = {cr.Message.Value}");

                        Enrollment? enrollment = JsonConvert.DeserializeObject<Enrollment>(cr.Message.Value);

                        if (enrollment != null)
                            await _enrollStudentToCourse.EnrollmentAsync(enrollment);
                    }
                }
                catch (OperationCanceledException)
                {
                    // Ctrl-C was pressed.
                }
                finally
                {
                    consumer.Close();
                }
            }
        }
    }
}
