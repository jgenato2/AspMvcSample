namespace AspMvcSample.Application.CQRS.Interfaces
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}