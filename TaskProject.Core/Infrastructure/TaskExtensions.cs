using System;
using System.Threading.Tasks;

namespace TaskProject.Core.Infrastructure
{
    public static class TaskExtensions
    {
        public static async void FireAndForgetSafeAsync(this Task task)
        {
            try
            {
                await task;
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}