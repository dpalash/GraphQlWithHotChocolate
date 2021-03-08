using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GraphQlWithHotChocolate.DTOs;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace GraphQlWithHotChocolate.Models
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<List<Author>>> OnAuthorGet([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            var result = await eventReceiver.SubscribeAsync<string, List<Author>>("ReturnedAuthor", cancellationToken);

            return result;
        }

        //[SubscribeAndResolve]
        //public async ValueTask<ISourceStream<BlogPost>> OnBlogPostCreate([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        //{
        //    return await eventReceiver.SubscribeAsync<string, BlogPost>("BlogPostCreated", cancellationToken);
        //}

    }
}
