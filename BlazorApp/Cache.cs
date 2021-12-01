using BlazorApp.Dtos;

namespace BlazorApp
{
    public static class Cache
    {
        private static List<ProjectDto>? Projects { get; set; }

        public static List<ProjectDto> GetProjects()
        {
            if(Projects == null) Projects = new List<ProjectDto>();

            return Projects;
        }

        public static void SetProjects(List<ProjectDto> projects)
        {
            Projects = projects;
        }
    }
}
