
using System;
using Microsoft.Extensions.DependencyInjection;
using AspMvcSample.Application.CQRS.Interfaces;

namespace AspMvcSample.Application.CQRS
{

    public interface IMediator
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
        TResult Query<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }

    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            handler.Handle(command);
        }

        public TResult Query<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return handler.Handle(query);
        }
    }
}