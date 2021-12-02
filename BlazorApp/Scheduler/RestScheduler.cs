using BlazorApp.Dtos;
using Tiny.RestClient;

namespace BlazorApp.Scheduler
{
    public class RestScheduler
    {
        public async Task GetTodos()
        {
            var client = new TinyRestClient(new HttpClient(), "https://jsonplaceholder.typicode.com/");
            var todos =  await client.GetRequest("todos").ExecuteAsync<List<TodoDto>>();
            Cache.SetTodos(todos);
        }
    }
}
