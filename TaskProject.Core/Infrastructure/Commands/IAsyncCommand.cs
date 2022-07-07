using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskProject.Core.Infrastructure.Commands
{
    public interface IAsyncCommand : ICommand
    {
        bool CanExecute();

        Task ExecuteAsync();
    }

    public interface IAsyncCommand<T> : ICommand
    {
        bool CanExecute(T parameter);

        Task ExecuteAsync(T parameter);
    }
}
