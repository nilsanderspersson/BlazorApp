using BlazorApp.Dtos;

namespace BlazorApp
{
    public static class Cache
    {
        private static List<ProjectDto>? Projects { get; set; }
        private static List<TodoDto>? Todos { get; set; }

        public static List<ProjectDto> GetProjects()
        {
            if(Projects == null) Projects = new List<ProjectDto>();
            return Projects;
        }

        public static List<TodoDto> GetTodo()
        {
            if(Todos == null) Todos = new List<TodoDto>();
            return Todos;
        }

        public static void SetProjects(List<ProjectDto> projects)
        {
            Projects = projects;
        }

        public static void SetTodos(List<TodoDto> todos)
        {
            Todos = todos;
        }
    }
}
