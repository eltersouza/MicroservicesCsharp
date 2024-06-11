using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CourseService.Infrastructure.Messaging
{
    public class EnrollmentDataPublisher
    {
        //public bool Publish(UserData userData, KafkaConfiguration kafkaConfiguration)
        //{
        //    bool result = false;

        //    if (userData == null || string.IsNullOrEmpty(userData.IpAddress))
        //        return result;

        //    var config = new ProducerConfig
        //    {
        //        BootstrapServers = kafkaConfiguration.BootstrapServers
        //    };

        //    using var producer = new ProducerBuilder<Null, string>(config).Build();

        //    var message = new Message<Null, string> { Value = userData.ToString() };

        //    producer.Produce(kafkaConfiguration.Topic, message, deliveryReport => {
        //        Console.WriteLine(deliveryReport.Message.Value);
        //        result = !deliveryReport.Error.IsError;
        //    });
        //    producer.Flush();

        //    return result;
        //}
    }
}
