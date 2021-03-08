using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GraphQlWithHotChocolate.DTOs;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
// ReSharper disable UnusedMember.Global

namespace GraphQlWithHotChocolate.Models
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<List<Author>>> OnAuthorCreate([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            var result = await eventReceiver.SubscribeAsync<string, List<Author>>("AuthorCreated", cancellationToken);

            return result;
        }
    }
}
